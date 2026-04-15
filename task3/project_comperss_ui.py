import os
from tkinter import *
from tkinter import filedialog, messagebox, ttk
from PIL import Image
from moviepy import VideoFileClip

def update_ui_for_media(*args):
    """Updates the slider label and range based on selected media type."""
    if media_type.get() == "Image":
        quality_label.config(text="4. Image Quality (1-95):")
        quality_slider.config(from_=10, to=95)
        quality_slider.set(60)
    else:
        quality_label.config(text="4. Video Bitrate (Kbps):")
        quality_slider.config(from_=500, to=5000)
        quality_slider.set(1500)

def compress_media():
    input_file = file_path_var.get()
    output_name = output_name_var.get()
    file_type = media_type.get()
    
    if not input_file or not output_name:
        messagebox.showwarning("Warning", "Please select a file and enter an output name.")
        return

    try:
        directory = os.path.dirname(input_file)
        btn_start.config(text="Processing...", state=DISABLED)
        root.update()

        if file_type == "Image":
            save_path = os.path.join(directory, f"{output_name}.jpg")
            with Image.open(input_file) as img:
                if img.mode != "RGB":
                    img = img.convert("RGB")
                img.save(save_path, "JPEG", quality=int(quality_slider.get()))
        else:
            save_path = os.path.join(directory, f"{output_name}.mp4")
            clip = VideoFileClip(input_file)
            # Use slider value as video bitrate
            bitrate_val = f"{int(quality_slider.get())}k"
            clip.write_videofile(save_path, bitrate=bitrate_val, codec="libx264", audio_codec="aac")
            clip.close()

        messagebox.showinfo("Success", f"Task Completed Successfully!\nFile saved in:\n{directory}")
    except Exception as e:
        messagebox.showerror("Error", f"An error occurred: {str(e)}")
    finally:
        btn_start.config(text="START COMPRESSING", state=NORMAL)

def select_file():
    path = filedialog.askopenfilename()
    if path:
        file_path_var.set(path)

# --- UI Setup ---
root = Tk()
root.title("Multimedia Compressor Pro")
root.geometry("600x450")
root.configure(bg="#1e1e2e")

# UI Theme Colors
PRIMARY_COLOR = "#313244"
ACCENT_COLOR = "#89b4fa"
TEXT_COLOR = "#cdd6f4"

file_path_var = StringVar()
output_name_var = StringVar(value="compressed_output")

# Variable Tracer for Dynamic UI
media_type = StringVar(value="Image")
media_type.trace("w", update_ui_for_media)

# Main Title
Label(root, text="MEDIA COMPRESSOR", font=("Segoe UI", 20, "bold"), bg="#1e1e2e", fg=ACCENT_COLOR).pack(pady=20)

# Main Container
main_frame = Frame(root, bg=PRIMARY_COLOR, padx=20, pady=20, highlightthickness=1, highlightbackground=ACCENT_COLOR)
main_frame.pack(pady=10, padx=30, fill="both", expand=True)

# 1. Media Type Selection
Label(main_frame, text="1. Select Media Type:", bg=PRIMARY_COLOR, fg=TEXT_COLOR, font=("Segoe UI", 10, "bold")).grid(row=0, column=0, sticky="w", pady=10)
radio_frame = Frame(main_frame, bg=PRIMARY_COLOR)
radio_frame.grid(row=0, column=1, columnspan=2, sticky="w")
Radiobutton(radio_frame, text="Image", variable=media_type, value="Image", bg=PRIMARY_COLOR, fg=ACCENT_COLOR, selectcolor="#1e1e2e", activebackground=PRIMARY_COLOR).pack(side=LEFT, padx=10)
Radiobutton(radio_frame, text="Video", variable=media_type, value="Video", bg=PRIMARY_COLOR, fg=ACCENT_COLOR, selectcolor="#1e1e2e", activebackground=PRIMARY_COLOR).pack(side=LEFT, padx=10)

# 2. File Selection
Label(main_frame, text="2. Source File:", bg=PRIMARY_COLOR, fg=TEXT_COLOR, font=("Segoe UI", 10, "bold")).grid(row=1, column=0, sticky="w", pady=10)
Entry(main_frame, textvariable=file_path_var, width=35, bg="#45475a", fg="white", borderwidth=0).grid(row=1, column=1, padx=5)
Button(main_frame, text="Browse", command=select_file, bg=ACCENT_COLOR, fg="#1e1e2e", relief=FLAT, font=("Segoe UI", 9, "bold")).grid(row=1, column=2)

# 3. Output Configuration
Label(main_frame, text="3. Output Name:", bg=PRIMARY_COLOR, fg=TEXT_COLOR, font=("Segoe UI", 10, "bold")).grid(row=2, column=0, sticky="w", pady=10)
Entry(main_frame, textvariable=output_name_var, width=35, bg="#45475a", fg="white", borderwidth=0).grid(row=2, column=1, padx=5, sticky="w")

# 4. Dynamic Quality/Bitrate Slider
quality_label = Label(main_frame, text="4. Image Quality (1-95):", bg=PRIMARY_COLOR, fg=TEXT_COLOR, font=("Segoe UI", 10, "bold"))
quality_label.grid(row=3, column=0, sticky="w", pady=10)

quality_slider = Scale(main_frame, from_=10, to=95, orient=HORIZONTAL, bg=PRIMARY_COLOR, fg=ACCENT_COLOR, highlightthickness=0, troughcolor="#45475a")
quality_slider.set(60)
quality_slider.grid(row=3, column=1, columnspan=2, sticky="ew")

# Execution Button
btn_start = Button(root, text="START COMPRESSING", bg=ACCENT_COLOR, fg="#1e1e2e", font=("Segoe UI", 12, "bold"), relief=FLAT, command=compress_media, cursor="hand2", width=30)
btn_start.pack(pady=20)

root.mainloop()