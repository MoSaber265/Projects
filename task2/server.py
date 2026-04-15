import socket

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(('0.0.0.0', 15000))
server.listen()

print('Listening on port 15000...')

conn, addr = server.accept()
print('Connected by', addr)

with conn:
    while True:
        
        data = conn.recv(1024)
        if not data:
            print("Client disconnected")
            break

        print("Client:", data.decode())

       
        mes = input('Enter message or type exit: ')
        conn.sendall(mes.encode())

        if mes.lower() == "exit":
            print("Server closed")
            break