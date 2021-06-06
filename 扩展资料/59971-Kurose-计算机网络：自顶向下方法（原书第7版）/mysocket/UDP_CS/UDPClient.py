from socket import *
serverName='10.26.14.99'
serverPort=12000
# 客户套接字，第一个参数指示底层网络使用ipv4，第二个参数指示它是一个udp套接字
clientSocket=socket(AF_INET,SOCK_DGRAM)
message=input('Input lowercase sentence:')
#先把字符串类型转为字节类型，sendto把结果返回回来。发送分组后，客户等待服务器的数据
clientSocket.sendto(message.encode(),(serverName,serverPort))
#modifiedMessage接收数据，serverAddress接收源地址（服务器的IP，port）
modifiedMessage, serverAddress = clientSocket.recvfrom(2048)
print(modifiedMessage.decode())
clientSocket.close()
