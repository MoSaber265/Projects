import socket, threading, os, io, time
from tkinter import *
from tkinter import filedialog
from PIL import Image, ImageTk # ImageTk ضرورية لعرض الصور في الواجهة

# 1. إعدادات الاتصال والبروتوكول الخاص
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(('127.0.0.1', 5555))
SEPARATOR = b"<SEP>"
EOF = b"<END>"

# لستة لحفظ مراجع الصور عشان متختفيش من الواجهة (Garbage Collection)
image_refs = []

# 2. وظائف معالجة البيانات (Media Processing)
def compress_img(path):
    """ضغط الصورة بجودة 20% قبل الإرسال"""
    img = Image.open(path)
    if img.mode != 'RGB': img = img.convert('RGB')
    out = io.BytesIO()
    img.save(out, format='JPEG', quality=20) 
    return out.getvalue()

def send_data(type_flag, data):
    """تغليف البيانات بالهيدر وعلامة النهاية"""
    packet = type_flag.encode() + SEPARATOR + data + EOF
    client.sendall(packet)

# 3. وظائف الإرسال والعرض
def display_msg(msg, align, is_image=False, img_bytes=None):
    """تنسيق الرسائل (نصوص أو صور) يمين ويسار"""
    side = E if align == "right" else W
    color = "#dcf8c6" if align == "right" else "#ffffff"
    
    if is_image and img_bytes:
        try:
            # تحويل البايتات المستلمة لصورة يمكن عرضها
            img_data = Image.open(io.BytesIO(img_bytes))
            img_data.thumbnail((150, 150)) # تصغير المعاينة لشكل جمالي
            photo = ImageTk.PhotoImage(img_data)
            image_refs.append(photo) # حفظ المرجع في القائمة
            
            lbl = Label(msg_frame, image=photo, bg=color, padx=5, pady=5)
            lbl.pack(anchor=side, pady=5, padx=10)
        except:
            Label(msg_frame, text="Error loading image", bg="red").pack(anchor=side)
    else:
        lbl = Label(msg_frame, text=msg, bg=color, wraplength=250, justify=LEFT, font=("Segoe UI Emoji", 10))
        lbl.pack(anchor=side, pady=5, padx=10)
    
    chat_canvas.update_idletasks()
    chat_canvas.yview_moveto(1.0) # سكرول تلقائي لأسفل

def send_text_msg(event=None):
    msg = entry_field.get()
    if msg:
        send_data("TEXT", msg.encode('utf-8'))
        display_msg(f"You: {msg}", "right")
        entry_field.delete(0, END)

def add_emoji(emoji_char):
    entry_field.insert(END, emoji_char)

def open_emoji_window():
    emoji_window = Toplevel(root)
    emoji_window.title("Emojis")
    emojis = ["😀", "😂", "❤️", "👍", "🔥", "✨", "😊", "😎", "🙌", "🎉"]
    for i, e in enumerate(emojis):
        Button(emoji_window, text=e, font=("Segoe UI Emoji", 12),
               command=lambda char=e: add_emoji(char)).grid(row=i//5, column=i%5, padx=5, pady=5)

def select_and_send(mode):
    path = filedialog.askopenfilename()
    if not path: return
    
    if mode == "IMG":
        data = compress_img(path)
        send_data("IMGC", data)
        display_msg("You sent an image", "right", is_image=True, img_bytes=data)
    elif mode == "HD":
        with open(path, "rb") as f: 
            data = f.read()
            send_data("IMG_HD", data)
            display_msg("You sent an HD image", "right", is_image=True, img_bytes=data)
    elif mode == "FILE":
        with open(path, "rb") as f: send_data("FILE", f.read())
        display_msg(f"You sent a file", "right")

# 4. وظيفة الاستقبال (Threading)
def receive():
    buffer = b""
    while True:
        try:
            chunk = client.recv(4096)
            if not chunk: break
            buffer += chunk
            while EOF in buffer:
                msg_data, buffer = buffer.split(EOF, 1)
                header_bin, content = msg_data.split(SEPARATOR, 1)
                header = header_bin.decode()
                timestamp = time.strftime('%H:%M')
                
                if header == "TEXT":
                    display_msg(f"[{timestamp}] User: {content.decode('utf-8')}", "left")
                elif header in ["IMGC", "IMG_HD"]:
                    display_msg(f"[{timestamp}] User sent an image", "left", is_image=True, img_bytes=content)
                else:
                    display_msg(f"[{timestamp}] {header} Received", "left")
        except: break

# 5. بناء الواجهة (GUI)
root = Tk()
root.title("Chat App Pro")
root.geometry("400x600")

chat_canvas = Canvas(root, bg="#ece5dd")
msg_frame = Frame(chat_canvas, bg="#ece5dd")
scrollbar = Scrollbar(root, command=chat_canvas.yview)
chat_canvas.configure(yscrollcommand=scrollbar.set)
scrollbar.pack(side=RIGHT, fill=Y)
chat_canvas.pack(side=TOP, fill=BOTH, expand=True)
chat_canvas.create_window((0,0), window=msg_frame, anchor="nw", width=380)

input_frame = Frame(root, bg="#f0f0f0", pady=5)
input_frame.pack(side=BOTTOM, fill=X)

emoji_btn = Button(input_frame, text="😊", command=open_emoji_window, font=("Segoe UI Emoji", 12))
emoji_btn.pack(side=LEFT, padx=5)

entry_field = Entry(input_frame, font=("Arial", 12))
entry_field.bind("<Return>", send_text_msg)
entry_field.pack(side=LEFT, fill=X, expand=True, padx=5)

send_btn = Button(input_frame, text="Send", command=send_text_msg, bg="#075e54", fg="white")
send_btn.pack(side=RIGHT, padx=5)

media_frame = Frame(root, bg="#f0f0f0")
media_frame.pack(side=BOTTOM, fill=X)
Button(media_frame, text="Image", command=lambda: select_and_send("IMG")).pack(side=LEFT, padx=2)
Button(media_frame, text="HD Image", command=lambda: select_and_send("HD"), bg="#ffd700").pack(side=LEFT, padx=2)
Button(media_frame, text="File/Video", command=lambda: select_and_send("FILE")).pack(side=LEFT, padx=2)

threading.Thread(target=receive, daemon=True).start()
root.mainloop()