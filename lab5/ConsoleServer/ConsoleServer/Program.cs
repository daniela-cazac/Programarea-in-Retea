using System;
using System.Text;
using System.Net.Sockets;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener serverSocket = new TcpListener( 8888);
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine(" >> Server Started");
            clientSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine(" >> Accept connection from client");
            while ((true))
            {
                try
                {
                   
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine(" >> Data from client - " + dataFromClient);
                    string serverResponse = "";

                    bool flag = false;
                    if (dataFromClient.CompareTo("/help") == 0){
                        serverResponse = @"/help - description of available commands; /time - get current server time; /hello - text to sent";
                        flag = true;
                    }
                    if (dataFromClient.CompareTo("/time") == 0)
                    {
                        var time = DateTime.Now;
                        serverResponse = time.ToString();
                        flag = true;
                    }
                    if (dataFromClient.Trim().StartsWith("/hello") == true)
                    {
                        if (dataFromClient.Trim().Length <= 6)
                            serverResponse = "Comanda /hello asteapta text dupa ea";
                        else
                            serverResponse = dataFromClient.Remove(0, 6);
                        flag = true;
                    }
                    if (flag == false )
                        serverResponse = "Comanda invalida - " + dataFromClient;

                        Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
               
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }

    }
}
