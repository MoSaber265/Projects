# 🖥️ TCP Bidirectional Chat System (Python)

### 🌐 Project Overview
This project is a high-performance **Client-Server communication system** built using Python's `socket` library. It demonstrates the core principles of the **TCP/IP protocol**, including connection handshaking, data stream handling, and synchronized bidirectional messaging.

---

## 🚀 Key Technical Features
- **Reliable Networking:** Uses `SOCK_STREAM` (TCP) to guarantee that packets are delivered in the correct order without data loss.
- **Full-Duplex Logic:** Designed to allow both the server and client to send and receive messages in a structured loop.
- **Dynamic Port Binding:** The server is configured to listen on `0.0.0.0`, making it accessible across a local network, not just `localhost`.
- **Safe Termination:** Integrated logic to detect the `exit` command, ensuring sockets are closed properly on both ends to prevent port hanging.

---

## 🛠️ Architecture & Workflow
1. **The Server:** - Initializes an IPv4 socket.
   - Binds to port `15000`.
   - Enters a "Listening" state.
   - Upon `accept()`, it establishes a dedicated connection channel.
2. **The Client:** - Initiates a 3-way handshake with the server.
   - Encodes string messages into **UTF-8 bytes** for transmission.
   - Waits for a server response before sending the next input.

---

## 💻 How to Launch
To experience the communication flow, follow these steps in your terminal:

### 1. Start the Server
```bash
python server.py


Open a second terminal window and run:
python client.py