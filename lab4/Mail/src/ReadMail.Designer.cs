namespace Mail
{
    partial class ReadMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_passwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_retrieve = new System.Windows.Forms.Button();
            this.listViewMails = new System.Windows.Forms.ListView();
            this.from = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mesage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(387, 22);
            this.textBox_email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(244, 22);
            this.textBox_email.TabIndex = 2;
            // 
            // textBox_passwd
            // 
            this.textBox_passwd.Location = new System.Drawing.Point(387, 58);
            this.textBox_passwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_passwd.Name = "textBox_passwd";
            this.textBox_passwd.Size = new System.Drawing.Size(244, 22);
            this.textBox_passwd.TabIndex = 3;
            this.textBox_passwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "messages";
            // 
            // button_retrieve
            // 
            this.button_retrieve.Location = new System.Drawing.Point(16, 382);
            this.button_retrieve.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_retrieve.Name = "button_retrieve";
            this.button_retrieve.Size = new System.Drawing.Size(247, 28);
            this.button_retrieve.TabIndex = 10;
            this.button_retrieve.Text = "Retrieve";
            this.button_retrieve.UseVisualStyleBackColor = true;
            this.button_retrieve.Click += new System.EventHandler(this.button_retrieve_Click);
            // 
            // listViewMails
            // 
            this.listViewMails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.from,
            this.date,
            this.subject,
            this.mesage});
            this.listViewMails.Location = new System.Drawing.Point(16, 199);
            this.listViewMails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewMails.Name = "listViewMails";
            this.listViewMails.Size = new System.Drawing.Size(852, 157);
            this.listViewMails.TabIndex = 11;
            this.listViewMails.UseCompatibleStateImageBehavior = false;
            this.listViewMails.View = System.Windows.Forms.View.Details;
            // 
            // from
            // 
            this.from.Text = "from";
            this.from.Width = 179;
            // 
            // date
            // 
            this.date.Text = "date";
            // 
            // subject
            // 
            this.subject.Text = "subject";
            this.subject.Width = 130;
            // 
            // mesage
            // 
            this.mesage.Text = "mesage";
            this.mesage.Width = 210;
            // 
            // ReadMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 425);
            this.Controls.Add(this.listViewMails);
            this.Controls.Add(this.button_retrieve);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_passwd);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReadMail";
            this.Text = "ReadMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_passwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_retrieve;
        private System.Windows.Forms.ListView listViewMails;
        private System.Windows.Forms.ColumnHeader subject;
        private System.Windows.Forms.ColumnHeader mesage;
        public System.Windows.Forms.ColumnHeader from;
        private System.Windows.Forms.ColumnHeader date;
    }
}