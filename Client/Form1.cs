using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonNet;

namespace Client
{
    public partial class Form1 : Form
    {
        private String serverHost;
        private Socket cSocket;
        private int port = 8034;
        private NetMessaging net;

        public delegate void Comment (String value);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChatTB.AppendText("Старт работы клиента..." + Environment.NewLine);
            ChatTB.AppendText("Введите адрес сервера или нажмите Send для использования стандартного: " + Environment.NewLine);
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            var sHost = "DESKTOP-NGK2IUN";
            String usHost;
            usHost = AddressTB.Text;
            if (usHost.Length > 0) sHost = usHost;
            try
            {
                serverHost = sHost;
                AddressTB.Enabled = false;
                Choice.Enabled = false;
                ChatTB.AppendText("Подключение к " + sHost + Environment.NewLine);
                cSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                cSocket.Connect(this.serverHost, port);
                net = new NetMessaging(cSocket);
                net.LoginCmdReceived += OnLogin;
                net.UserListCmdReceived += OnUserList;
                net.StartCmdReceived += OnStart;
                net.MessageCmdReceived += OnMessage;
                net.EventComment += OnComment;
                net.EventError += OnNameError;
                new Thread(() =>
                {
                    try
                    {
                        net.Communicate();
                    }
                    catch (Exception ex)
                    {
                        ChatTB.AppendText("Не удалось получить данные. Завершение соединения..." + Environment.NewLine);
                    }
                }).Start();
            }
            catch (Exception ex)
            {
               ChatTB.AppendText("Что-то пошло не так... :(" + Environment.NewLine);
            }
        }
        private void OnComment(String value)
        {
            if (!ChatTB.InvokeRequired)
            {
                ChatTB.Text += value + "\r\n";
            }
            else
            {
                Invoke(new NetMessaging.Comment(OnComment), value);
            }
        }

        private void OnMessage(string command, string data)
        {
            if (!ChatTB.InvokeRequired) ChatTB.AppendText(data + Environment.NewLine);
            else
            {
                object[] value = { command, data };
                Invoke(new NetMessaging.Receiving(OnMessage), value);
            }
        }
    

        private void OnStart(string command, string data)
        {
            if (!ChatTB.InvokeRequired)
            {
                ChatTB.AppendText("Вы можете писать сообщения!" + Environment.NewLine);
                GoMessaging();
            }
            else
            {
                object[] value = { command, data };
                Invoke(new NetMessaging.Receiving(OnStart), value);
            }
        }

        private void OnUserList(string command, string data)
        {
            if (!ChatTB.InvokeRequired)
            {
                var us = data.Split(',');
                ChatTB.AppendText("Список подключенных клиентов:" + Environment.NewLine);
                foreach (var cl in us)
                {
                    ChatTB.Text += cl + ",";
                }
                ChatTB.Text += "\r\n";
                ChatTB.AppendText("___________________________" + Environment.NewLine);
            }
            else
            {
                object[] value = { command, data };
                Invoke(new NetMessaging.Receiving(OnUserList), value);
            }
        }

        private void GoMessaging()
        {
            new Thread(() =>
            {
                while (true)
                {
                    String userData = "";
                    userData = send;
                    if (send!="")
                    {
                        send = "";
                        net.SendData("MESSAGE", userData);
                    }
                }
            }
            ).Start();
        }

        void OnLogin(string c, string d)
        {
            if (!userNameTB.InvokeRequired)
            {
                var t = true;
                new Thread(name).Start();
            }
            else
            {
                object[] value = { c, d };
                Invoke(new NetMessaging.Receiving(OnLogin), value);
            }
        }
        void name()
        {
            var t = true;
            while (t)
            {
                String userName = "";
                userName = userNameTB.Text;
                if (!Entry.Enabled)
                {
                    t = false;
                    net.SendData("LOGIN", userName);
                }
                
            }
        }

        private void Entry_Click(object sender, EventArgs e)
        {
            Entry.Enabled = false;
            userNameTB.Enabled = false;
            
        }
        String send ="";
        private void Send_Click(object sender, EventArgs e)
        {
            send = MessageTB.Text;
            MessageTB.Text = "";
        }

        private void ChatTB_TextChanged(object sender, EventArgs e)
        {
            ChatTB.SelectionStart = ChatTB.TextLength;
            ChatTB.ScrollToCaret();

        }
        private void OnNameError(int val)
        {
            Entry.Enabled = true;
            userNameTB.Enabled = true;
            ChatTB.AppendText("Выберите другое имя" + Environment.NewLine);
        }
    }

}

