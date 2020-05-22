namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddressTB = new System.Windows.Forms.TextBox();
            this.ChatTB = new System.Windows.Forms.TextBox();
            this.Choice = new System.Windows.Forms.Button();
            this.userNameTB = new System.Windows.Forms.TextBox();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.Label();
            this.yourName = new System.Windows.Forms.Label();
            this.Entry = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddressTB
            // 
            this.AddressTB.Location = new System.Drawing.Point(92, 7);
            this.AddressTB.Margin = new System.Windows.Forms.Padding(2);
            this.AddressTB.Multiline = true;
            this.AddressTB.Name = "AddressTB";
            this.AddressTB.Size = new System.Drawing.Size(260, 19);
            this.AddressTB.TabIndex = 1;
            this.AddressTB.TabStop = false;
            // 
            // ChatTB
            // 
            this.ChatTB.Enabled = false;
            this.ChatTB.Location = new System.Drawing.Point(11, 71);
            this.ChatTB.Margin = new System.Windows.Forms.Padding(2);
            this.ChatTB.Multiline = true;
            this.ChatTB.Name = "ChatTB";
            this.ChatTB.Size = new System.Drawing.Size(411, 237);
            this.ChatTB.TabIndex = 2;
            this.ChatTB.TextChanged += new System.EventHandler(this.ChatTB_TextChanged);
            // 
            // Choice
            // 
            this.Choice.Location = new System.Drawing.Point(360, 3);
            this.Choice.Margin = new System.Windows.Forms.Padding(2);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(58, 23);
            this.Choice.TabIndex = 3;
            this.Choice.Text = "Choice";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Click += new System.EventHandler(this.Choice_Click);
            // 
            // userNameTB
            // 
            this.userNameTB.Enabled = false;
            this.userNameTB.Location = new System.Drawing.Point(92, 32);
            this.userNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.userNameTB.Multiline = true;
            this.userNameTB.Name = "userNameTB";
            this.userNameTB.Size = new System.Drawing.Size(260, 19);
            this.userNameTB.TabIndex = 4;
            this.userNameTB.TabStop = false;
            // 
            // MessageTB
            // 
            this.MessageTB.Location = new System.Drawing.Point(99, 317);
            this.MessageTB.Margin = new System.Windows.Forms.Padding(2);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(260, 19);
            this.MessageTB.TabIndex = 5;
            this.MessageTB.TabStop = false;
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(3, 9);
            this.Address.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(86, 13);
            this.Address.TabIndex = 6;
            this.Address.Text = "Aдрес сервера:";
            // 
            // yourName
            // 
            this.yourName.AutoSize = true;
            this.yourName.Location = new System.Drawing.Point(28, 32);
            this.yourName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yourName.Name = "yourName";
            this.yourName.Size = new System.Drawing.Size(60, 13);
            this.yourName.TabIndex = 7;
            this.yourName.Text = "Ваше имя:";
            // 
            // Entry
            // 
            this.Entry.Enabled = false;
            this.Entry.Location = new System.Drawing.Point(360, 32);
            this.Entry.Margin = new System.Windows.Forms.Padding(2);
            this.Entry.Name = "Entry";
            this.Entry.Size = new System.Drawing.Size(58, 23);
            this.Entry.TabIndex = 8;
            this.Entry.Text = "Entry";
            this.Entry.UseVisualStyleBackColor = true;
            this.Entry.Click += new System.EventHandler(this.Entry_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(363, 317);
            this.Send.Margin = new System.Windows.Forms.Padding(2);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(58, 23);
            this.Send.TabIndex = 9;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(28, 320);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(68, 13);
            this.message.TabIndex = 10;
            this.message.Text = "Сообщение:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 344);
            this.Controls.Add(this.message);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Entry);
            this.Controls.Add(this.yourName);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.MessageTB);
            this.Controls.Add(this.userNameTB);
            this.Controls.Add(this.Choice);
            this.Controls.Add(this.ChatTB);
            this.Controls.Add(this.AddressTB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AddressTB;
        private System.Windows.Forms.TextBox ChatTB;
        private System.Windows.Forms.Button Choice;
        private System.Windows.Forms.TextBox userNameTB;
        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label yourName;
        private System.Windows.Forms.Button Entry;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Label message;
    }
}

