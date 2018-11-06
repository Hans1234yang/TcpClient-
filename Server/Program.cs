using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建Socket对象并绑定IP和端口号
            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.43.67"), 9999); //这个TcpListener是将Socket创建对象的方式封装起来存储在这个类中
                                                                                              
            //2.开始监听
            listener.Start(100);
            //3.等待客户端连接过来
            TcpClient client = listener.AcceptTcpClient();
            //4.取得客户端发送过来的数据
            NetworkStream stream = client.GetStream(); //用于接受和发送数据，得到一个网络流，通过这个网络流来接受和发送数据
                                                       
            //5.读取接收到的数据
            byte[] data = new byte[1024]; //5.2.创建一个容器用于接受数据并传入到第一步的第一个位置的参数
                                          //8.将我们需要读数据和输出数据的代码放入一个死循环中去
            while (true)
            {
                int length = stream.Read(data, 0, 1024); //5.1.建立读数据，需要传入三个参数和一个返回值。容器、从哪个位置开始、读取的最大数据、返回值为实际读取的参数
                                                         
                //6.输出接收到的这个数据
                string message = Encoding.UTF8.GetString(data, 0, length); //6.1.先将接收到的数据转化可输出的字符串类型
                Console.WriteLine("收到消息：" + message); //6.2.输出收到的信息
            }

            //7.输出完数据以后我们需要释放这些数据
            stream.Close(); //1.先释放流的数据
            client.Close(); //2.再释放客户端的连接数据
            listener.Stop(); //3.关闭监听
            Console.ReadKey();
        }
    }
}
