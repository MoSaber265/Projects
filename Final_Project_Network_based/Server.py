import socket
import threading

# إعدادات السيرفر
SERVER_IP = '127.0.0.1' 
PORT = 5555
clients = []

def broadcast(message, _client_socket):
    for client in clients:
        # بنبعت الرسالة لكل الناس ماعدا اللي بعتها [cite: 51, 94]
        if client != _client_socket:
            try:
                client.send(message)
            except:
                clients.remove(client)

def handle_client(client):
    while True:
        try:
            # نستقبل البيانات كـ Bytes [cite: 37]
            data = client.recv(1024)
            if not data: break
            broadcast(data, client)
        except:
            clients.remove(client)
            break

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM) # TCP Socket [cite: 5]
server.bind((SERVER_IP, PORT))
server.listen()

print("Server is running...")
while True:
    client_socket, addr = server.accept()
    clients.append(client_socket)
    threading.Thread(target=handle_client, args=(client_socket,)).start()