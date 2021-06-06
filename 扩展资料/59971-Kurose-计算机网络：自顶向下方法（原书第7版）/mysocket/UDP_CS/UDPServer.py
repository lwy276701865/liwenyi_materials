from socket import *
serverPort=12000
serverSocket=socket(AF_INET,SOCK_DGRAM)
#把该服务器的套接字和端口号12000绑定
serverSocket.bind(('',serverPort))
print('The server is ready to receive')
while True:
    message,clientAddress = serverSocket.recvfrom(2048)# 接收客户端信息，同时获得客户端地址
    modifiedMessage=message.decode().upper()
    serverSocket.sendto(modifiedMessage.encode(),clientAddress)