import socket, threading, os, io, time
from tkinter import *
from tkinter import filedialog
from PIL import Image

# 1. إعدادات الاتصال والبروتوكول الخاص (End of File)
# TCP Socket [cite: 5, 89]
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(('127.0.0.1', 5555))
SEPARATOR = b"<SEP>"
EOF = b"<END>" # بروتوكول خاص لاكتشاف نهاية الملف بدون إرسال الحجم [cite: 26]

# 2. وظائف معالجة البيانات (Media Processing)
def compress_img(path):
    """ضغط الصورة بجودة 20% قبل الإرسال [cite: 7, 65, 85]"""
    img = Image.open(path)
    if img.mode != 'RGB': img = img.convert('RGB')
    out = io.BytesIO()
    img.save(out, format='JPEG', quality=20) 
    return out.getvalue()

def send_data(type_flag, data):
    """تغليف البيانات بالهيدر وعلامة النهاية [cite: 49]"""
    packet = type_flag.encode() + SEPARATOR + data + EOF
    client.sendall(packet)

# 3. وظائف الإرسال (Send Modules)
def send_text_msg(event=None):
    """إرسال النصوص بتشفير UTF-8 لدعم الإيموجي [cite: 6, 74]"""
    msg = entry_field.get()
    if msg:
        send_data("TEXT", msg.encode('utf-8'))
        display_msg(f"You: {msg}", "right")
        entry_field.delete(0, END)

def add_emoji(emoji_char):
    """إضافة الإيموجي المختار لخانة الكتابة"""
    entry_field.insert(END, emoji_char)

def open_emoji_window():
    """نافذة اختيار الإيموجي (WhatsApp Style)"""
    emoji_window = Toplevel(root)
    emoji_window.title("Emojis")
    emojis = ["😀", "😂", "❤️", "👍", "🔥", "✨", "😊", "😎", "🙌", "🎉"]
    for i, e in enumerate(emojis):
        Button(emoji_window, text=e, font=("Segoe UI Emoji", 12),
               command=lambda char=e: add_emoji(char)).grid(row=i//5, column=i%5, padx=5, pady=5)

def select_and_send(mode):
    """إرسال صور (مضغوطة/HD) أو ملفات وفيديو [cite: 7, 8, 9, 60, 80]"""
    path = filedialog.askopenfilename()
    if not path: return
    
    if mode == "IMG":
        data = compress_img(path) # ضغط الصورة [cite: 7]
        send_data("IMGC", data)
    elif mode == "HD":
        with open(path, "rb") as f: send_data("IMG_HD", f.read()) # بدون ضغط (HD Button) [cite: 8]
    elif mode == "FILE":
        with open(path, "rb") as f: send_data("FILE", f.read()) # ملفات/فيديو [cite: 9]
    
    display_msg(f"Sent {mode} file", "right")

# 4. واجهة المستخدم وتنسيق الرسائل (GUI & Alignment)
def display_msg(msg, align):
    """تنسيق الرسائل يمين ويسار [cite: 11]"""
    side = E if align == "right" else W
    color = "#dcf8c6" if align == "right" else "#ffffff"
    lbl = Label(msg_frame, text=msg, bg=color, wraplength=250, justify=LEFT, font=("Segoe UI Emoji", 10))
    lbl.pack(anchor=side, pady=5, padx=10)
    chat_canvas.update_idletasks()
    chat_canvas.yview_moveto(1.0) # سكرول تلقائي [cite: 17]

def receive():
    """الاستقبال في خيط منفصل (Threading) [cite: 58, 68, 72, 91]"""
    buffer = b""
    while True:
        try:
            chunk = client.recv(4096)
            if not chunk: break
            buffer += chunk
            while EOF in buffer:
                msg_data, buffer = buffer.split(EOF, 1)
                header, content = msg_data.split(SEPARATOR, 1)
                timestamp = time.strftime('%H:%M') # ميزة الوقت [cite: 18]
                
                if header.decode() == "TEXT":
                    display_msg(f"[{timestamp}] User: {content.decode('utf-8')}", "left")
                else:
                    display_msg(f"[{timestamp}] {header.decode()} Received", "left")
        except: break

# 5. بناء الواجهة (Tkinter Setup) [cite: 10, 42, 46, 90]
root = Tk()
root.title("Chat App")
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