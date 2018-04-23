using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace Mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        MailMessage mail = new MailMessage();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(textBox_mailFrom.Text);
                mail.To.Add(textBox_mailTo.Text);
                if (String.IsNullOrEmpty(textBoxCC.Text) == false)
                    mail.CC.Add(textBoxCC.Text);

                mail.Subject = textBox_Subject.Text;

                mail.Body = richTextBox_mailText.Text;



                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential(textBox_mailFrom.Text, textBox_passwd.Text);
                client.EnableSsl = true;

                client.Send(mail);
             //   MessageBox.Show("");
                MessageBox.Show("Email was send",
                    "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button_read_Click(object sender, EventArgs e)
        {
            ReadMail frm = new ReadMail();
            frm.Show();
        }
    }
}
