using System;
using System.Windows.Forms;
using OpenPop.Mime;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using Message = OpenPop.Mime.Message;

namespace Mail
{
    public partial class ReadMail : Form
    {
        private Pop3Client pop3Client;
   
        public ReadMail()
        {
            InitializeComponent();
            pop3Client = new Pop3Client();
   
        }

        private void button_connect_Click(object sender, EventArgs e)
        {

        }

        private void button_retrieve_Click(object sender, EventArgs e)
        {
           ReceiveMails();
       
        }
        private void ReceiveMails()
        {
            try
            {
                if (pop3Client.Connected)
                    pop3Client.Disconnect();
                pop3Client.Connect("pop.gmail.com", 995, true);
                pop3Client.Authenticate(textBox_email.Text, textBox_passwd.Text);
              
                int count = pop3Client.GetMessageCount();

                for (int i = count; i >= 1; i -= 1)
                {
                    try
                    {
                        Application.DoEvents();
                        Message message = pop3Client.GetMessage(i);
                        MessagePart plainTextPart = message.FindFirstPlainTextVersion();
                       ListViewItem lvi = new ListViewItem(message.Headers.From.Address.ToString());
                       lvi.SubItems.Add(message.Headers.Date.ToString());
                        lvi.SubItems.Add(message.Headers.Subject.ToString());
                       lvi.SubItems.Add(plainTextPart.GetBodyAsText());
                       listViewMails.Items.Add(lvi);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            catch (InvalidLoginException)
            {
                MessageBox.Show(this, "The server did not accept the user credentials!", "POP3 Server Authentication");
            }
            catch (PopServerNotFoundException)
            {
                MessageBox.Show(this, "The server could not be found", "POP3 Retrieval");
            }
            catch (PopServerLockedException)
            {
                MessageBox.Show(this, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
            }
            catch (LoginDelayException)
            {
                MessageBox.Show(this, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Error occurred retrieving mail. " + e.Message, "POP3 Retrieval");
            }
            finally
            {

            }
        }
     
    }
}
