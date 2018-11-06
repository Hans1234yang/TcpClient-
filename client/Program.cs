using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建Socket对象并且绑定IP和端口号
            TcpClient client = new TcpClient("192.168.43.67", 9999);

            //2.创建网络流和服务端形成交换
            NetworkStream stream = client.GetStream();

            //5.将3步骤写入一个死循环中可以让用户重复输入需要的信息，重复循环
            while (true)
            {
                //3.然后写入需要交换的数据
                string message = Console.ReadLine();    //输入想要通信的字符串
                byte[] data = Encoding.UTF8.GetBytes(message);  //把输入的字符串转化到能够写入的byte类型
                stream.Write(data, 0, data.Length); //1.这里是写入需要传递给服务端的数据,第一个参数是传入的字符数组，第二个是从哪个开始的偏移量，第三个是写入的数据大小长度
            }

            //4.关闭流
            stream.Close();
            client.Close();
            Console.ReadKey();
        }
    }
}
      