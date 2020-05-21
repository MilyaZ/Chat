using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommonNet
{
    public class User
    {
        String X { get; set; }

        public User(String x)
        {
            X = x;
        }
        public String GetName() { return X; }
    }


    public class NetMessaging
    {
        public static List<User> users;
        public delegate void Receiving(String command, String data);
        public delegate void Comment(String data);
        public delegate void Error(int val);
        private Socket cSocket;
        public event Receiving LoginCmdReceived;
        public event Receiving MessageCmdReceived;
        public event Receiving UserListCmdReceived;
        public event Receiving StartCmdReceived;
        public event Error EventError;
        public event Comment EventComment;

        public NetMessaging(Socket s)
        {
            cSocket = s;
           if(users!=null) users = new List<User>();
        }
        public void SendData(String command, String data)
        {
            if (cSocket != null)
            {
                try
                {
                    if (data.Trim().Equals("") || command.Trim().Equals("")) return;
                    var b = Encoding.UTF8.GetBytes(command + "=" + data + "\n");
                    Console.WriteLine("Отправка сообщения...");
                    EventComment?.Invoke("Отправка сообщения...");
                    bool ecqually = true;
                    if (command == "LOGIN" && data!="?")
                    {
                        foreach (var b1 in ConnectedClient.clients)
                        {
                            

                            if (b1.GetName() == data)
                            {
                                ecqually = false;
                                EventError?.Invoke(0);

                            }
                        }
                        if (ecqually)
                        {
                            User s = new User(data);
                            users.Add(s);
                        }
                    }
                    if (ecqually)
                    {
                        
                        cSocket.Send(b);
                        Console.WriteLine("Сообщение успешно отправлено!");
                        EventComment?.Invoke("Сообщение успешно отправлено!");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось отправить сообщение :(");
                        EventComment?.Invoke("Не удалось отправить сообщение :(");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось отправить сообщение :(");
                    EventComment?.Invoke("Не удалось отправить сообщение :(");
                }
            }
        }

        public String ReceiveData()
        {
            String res = "";
            if (cSocket != null)
            {
                var b = new byte[65536];
                Console.WriteLine("Ожидание данных...");
                EventComment?.Invoke("Ожидание данных...");
                var i = 0;
                do
                {
                    var cnt = cSocket.Receive(b);

                    Console.WriteLine("Получена порция данных №{0}", ++i);
                    EventComment?.Invoke("Получена порция данных № " + (++i).ToString());
                    var r = Encoding.UTF8.GetString(b, 0, cnt);
                    res += r;
                } while (res[res.Length - 1] != '\n');
                Console.WriteLine("Данные успешно получены");
                EventComment?.Invoke("Данные успешно получены");

            }
            return res.Trim();
        }

        public void Communicate()
        {
            if (cSocket != null)
            {
                Console.WriteLine("Начало общения...");
                EventComment?.Invoke("Начало общения...");
                while (true)
                {
                    String d = ReceiveData();
                    Parse(d);
                }
            }
        }

        private void Parse(string s)
        {
            // КОМАНДА=ЗНАЧЕНИЕ (LOGIN=Иван)
            char[] sep = { '=' };
            var cd = s.Split(sep, 2);
            switch (cd[0])
            {
                case "LOGIN":
                    {
                        LoginCmdReceived?.Invoke(cd[0], cd[1]);
                        break;
                    }
                case "MESSAGE":
                    {
                        MessageCmdReceived?.Invoke(cd[0], cd[1]);
                        break;
                    }
                case "USERLIST":
                    {
                        UserListCmdReceived?.Invoke(cd[0], cd[1]);
                        break;
                    }
                case "START":
                    {
                        StartCmdReceived?.Invoke(cd[0], cd[1]);
                        break;
                    }
            }
        }
    }
}


