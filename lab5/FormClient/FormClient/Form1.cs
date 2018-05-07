using System;
using System.Windows.Forms;
using System.Net.Sockets;

namespace FormClient
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();

        public Form1()
        {
            InitializeComponent();
            textBox2.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");
            clientSocket.Connect("Daniela", 8888);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            msg(returndata);
            textBox2.Text = "";
            textBox2.Focus();
        }

        public void msg(string mesg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        
    }
}
