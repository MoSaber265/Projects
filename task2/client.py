import socket
client = socket.socket(
    socket.AF_INET,socket.SOCK_STREAM
)

client.connect(('localhost',15000))
while True:
    mes = input('enter message or exit')

    if mes.lower()=='exit':
        print('losinng')
        break
    else:
        client.sendall(mes.encode())
        data=client.recv(1024)
        print("server says:",data.decode())

    
client.close()  

