<div align="center">

# 💬 Network-Based Chat Application

### A Real-Time Desktop Chat App — Final Project | Multimedia & Networking Course

[![Python](https://img.shields.io/badge/Python-3.8+-3776AB?style=for-the-badge&logo=python&logoColor=white)](https://python.org)
[![Tkinter](https://img.shields.io/badge/GUI-Tkinter-FF6B35?style=for-the-badge&logo=python&logoColor=white)]()
[![Socket](https://img.shields.io/badge/Network-TCP%20Socket-00C851?style=for-the-badge&logo=cisco&logoColor=white)]()
[![Threading](https://img.shields.io/badge/Concurrency-Threading-9B59B6?style=for-the-badge)]()
[![Pillow](https://img.shields.io/badge/Media-Pillow%20%2F%20PIL-FF4785?style=for-the-badge)]()

<br/>

> A fully featured **desktop chat application** built from scratch using Python.  
> Supports real-time messaging, image compression, HD transfer, file sharing,  
> emoji picker — all over a **custom TCP protocol** with no size-header file detection.

<br/>

![separator](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

</div>

<br/>

## 📌 Table of Contents

- [Overview](#-overview)
- [System Architecture](#-system-architecture)
- [Features](#-features)
- [Custom Protocol Design](#-custom-protocol-design)
- [Project Structure](#-project-structure)
- [How It Works](#-how-it-works)
- [Installation & Usage](#-installation--usage)
- [Course Info](#-course-info)

<br/>

---

## 🧠 Overview

This project is the **Final Practical Project** for the Multimedia & Networking course. It implements a real-time multi-client chat system using raw TCP sockets — with **no ready-made file transfer libraries**.

The application follows a **Client–Server–Broadcast** architecture:
- The **Server** accepts connections, manages clients, and broadcasts all received data
- Each **Client** has a full Tkinter GUI for sending and receiving text, images, and files
- A **custom binary protocol** using `<SEP>` and `<END>` markers detects end-of-file **without sending file size** — satisfying the tricky constraint

<br/>

---

## 🏗️ System Architecture

```
┌─────────────────┐         ┌──────────────────────┐         ┌─────────────────┐
│    CLIENT 1     │         │        SERVER         │         │    CLIENT 2     │
│  ┌───────────┐  │         │  ┌────────────────┐   │         │  ┌───────────┐  │
│  │ Tkinter   │  │ ──────► │  │ Accept Clients │   │ ──────► │  │ Tkinter   │  │
│  │    UI     │  │         │  │ Manage List    │   │         │  │    UI     │  │
│  └───────────┘  │         │  │ Recv & Bcast   │   │         └───────────────  │
│                 │ ◄─────  │  │ Handle Disconn │   │ ◄─────  │                 │
│  Send: Text     │         │  └────────────────┘   │         │  Recv: Text     │
│  Send: Image    │         │                        │         │  Recv: Image    │
│  Send: File     │         │  All data goes through │         │  Recv: File     │
└─────────────────┘         │  server — clients do   │         └─────────────────┘
                            │  NOT connect directly  │
                            └──────────────────────┘

DATA FLOW:
  Client 1 sends  ──►  Server receives  ──►  Broadcasts to all other clients
```

<br/>

---

## ✅ Features

### Required Features
| Feature | Status | Details |
|:--------|:------:|:--------|
| TCP Socket (Client + Server) | ✅ | `socket.AF_INET, SOCK_STREAM` |
| Send Text Messages | ✅ | UTF-8 encoded, supports emoji |
| Send Images (Compressed) | ✅ | JPEG quality=20% using Pillow |
| HD Image Button | ✅ | Raw bytes, no compression (like WhatsApp) |
| Send Files / Videos | ✅ | Binary file transfer via custom protocol |
| Tkinter GUI | ✅ | WhatsApp-style chat layout |
| Message Alignment (Left/Right) | ✅ | Sent = right (green), Received = left (white) |
| Online Hosting | ✅ | Via ngrok / Railway |

### Advanced Features
| Feature | Status | Details |
|:--------|:------:|:--------|
| Custom EOF Protocol | ✅ | `<SEP>` + `<END>` markers — no file size sent |
| Multi-client Broadcasting | ✅ | Server broadcasts to all except sender |
| Threaded Receiving | ✅ | Non-blocking via `threading.Thread` |
| Timestamp on Messages | ✅ | `time.strftime('%H:%M')` |
| Emoji Picker | ✅ | WhatsApp-style popup window |

<br/>

---

## 🔐 Custom Protocol Design

> **Tricky Constraint:** File size cannot be sent before transfer. A custom protocol must detect end-of-file.

### Solution: Marker-Based Framing Protocol

Every packet sent follows this structure:

```
┌─────────────────────────────────────────────────────────┐
│  TYPE_FLAG  │  <SEP>  │      PAYLOAD (bytes)      │ <END> │
└─────────────────────────────────────────────────────────┘

Example (Text):
  b"TEXT<SEP>Hello World!<END>"

Example (Image):
  b"IMGC<SEP>\xff\xd8...(jpeg bytes)...<END>"
```

### Packet Types

| Flag | Content | Compression |
|:-----|:--------|:-----------:|
| `TEXT` | UTF-8 encoded message | — |
| `IMGC` | Compressed JPEG image | ✅ 20% quality |
| `IMG_HD` | Full quality image | ❌ Raw bytes |
| `FILE` | Any file / video | ❌ Raw bytes |

### Receiver Buffer Logic

```python
buffer = b""
while True:
    chunk = client.recv(4096)
    buffer += chunk
    while b"<END>" in buffer:
        packet, buffer = buffer.split(b"<END>", 1)   # extract one complete message
        header, content = packet.split(b"<SEP>", 1)  # split type from payload
        # process content based on header...
```

This handles **TCP stream fragmentation** — chunks may arrive split across multiple `recv()` calls.

<br/>

---

## 📁 Project Structure

```
network-chat-app/
│
├── 📄 server.py          # TCP server — accepts clients, broadcasts data
├── 📄 client.py          # TCP client — Tkinter GUI, send/receive logic
│
├── 📄 README.md          # You are here
└── 📄 requirements.txt   # Python dependencies
```

### `server.py` — Responsibilities
- Bind and listen on `127.0.0.1:5555`
- Accept new client connections → add to `clients[]`
- Spawn a `handle_client` thread per connection
- **Broadcast** received data to all clients except sender
- Handle disconnections gracefully

### `client.py` — Responsibilities
- Connect to server via TCP
- Build Tkinter chat UI (canvas + scrollable frame)
- Send: text, compressed image, HD image, file/video
- Receive in a background daemon thread
- Parse packets using the custom `<SEP>` / `<END>` protocol
- Display messages with left/right alignment and timestamps

<br/>

---

## ⚙️ How It Works

### 1. Sending a Text Message
```python
def send_text_msg():
    msg = entry_field.get()
    packet = b"TEXT" + b"<SEP>" + msg.encode('utf-8') + b"<END>"
    client.sendall(packet)
```

### 2. Sending a Compressed Image
```python
def compress_img(path):
    img = Image.open(path)
    if img.mode != 'RGB':
        img = img.convert('RGB')
    out = io.BytesIO()
    img.save(out, format='JPEG', quality=20)  # 20% quality = ~5x smaller
    return out.getvalue()
```

### 3. Server Broadcasting
```python
def broadcast(message, sender_socket):
    for client in clients:
        if client != sender_socket:   # don't echo back to sender
            try:
                client.send(message)
            except:
                clients.remove(client)
```

### 4. Threaded Receiving (Non-blocking)
```python
threading.Thread(target=receive, daemon=True).start()
# daemon=True → thread dies automatically when main window closes
```

<br/>

---

## 🚀 Installation & Usage

### Requirements

```bash
pip install pillow
```

> `socket`, `threading`, `tkinter`, `io`, `time`, `os` are all built-in Python modules.

Or install from file:
```bash
pip install -r requirements.txt
```

**`requirements.txt`:**
```
Pillow>=9.0.0
```

### Run the Application

```bash
# Step 1 — Start the server (run this first)
python server.py

# Step 2 — Start Client 1 (in a new terminal)
python client.py

# Step 3 — Start Client 2 (in another terminal)
python client.py
```

> Both clients connect to `127.0.0.1:5555` by default.  
> To run over the internet, replace `127.0.0.1` with your **ngrok / Railway** public address.

### Online Hosting with ngrok

```bash
# Install ngrok, then:
ngrok tcp 5555

# Copy the forwarded address e.g.: 0.tcp.ngrok.io:12345
# Update in client.py:
client.connect(('0.tcp.ngrok.io', 12345))
```

<br/>

---

## 🖥️ UI Preview

```
┌────────────────────────────────────────┐
│              Chat App                  │
├────────────────────────────────────────┤
│                                        │
│   [14:32] User: Hello!       ░░░░░░░  │
│                                        │
│  ░░░░░░░░░░  You: Hi there! 👋        │
│                                        │
│   [14:33] User: Send me that file     │
│                                        │
│  ░░░░░░░░  You: FILE Sent ✅          │
│                                        │
├────────────────────────────────────────┤
│ 😊 │ [Type a message...    ] │ Send   │
├────────────────────────────────────────┤
│ [Image] [HD Image] [File/Video]        │
└────────────────────────────────────────┘
```

- 🟢 **Green bubbles** → your sent messages (right-aligned)
- ⚪ **White bubbles** → received messages (left-aligned)
- 🕐 **Timestamps** shown on every received message
- 😊 **Emoji picker** → WhatsApp-style popup

<br/>

---

## 📚 Course Info

| Field | Details |
|:------|:--------|
| **Course** | Multimedia & Networking (Network-Based MM) |
| **Project Type** | Final Practical Project |
| **Language** | Python 3.8+ |
| **Key Concepts** | TCP Sockets · Threading · GUI · Image Compression · Custom Protocol |

<br/>

---

<div align="center">

![separator](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

*Network-Based Multimedia — Final Project*

**Built with Python 🐍 | TCP Sockets 🔌 | Tkinter 🖼️ | Pillow 🖼️**

</div>
