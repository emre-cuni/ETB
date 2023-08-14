namespace etb
{
    partial class FormDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonCustomer = new System.Windows.Forms.RadioButton();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.labelAuthorization = new System.Windows.Forms.Label();
            this.labelCreditCard = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.labelExit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonCustomer);
            this.panel1.Controls.Add(this.radioButtonAdmin);
            this.panel1.Controls.Add(this.labelAuthorization);
            this.panel1.Controls.Add(this.labelCreditCard);
            this.panel1.Controls.Add(this.labelPhone);
            this.panel1.Controls.Add(this.labelAddress);
            this.panel1.Controls.Add(this.labelGender);
            this.panel1.Controls.Add(this.labelBirthday);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.labelSurname);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.pictureBoxPhoto);
            this.panel1.Location = new System.Drawing.Point(27, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 329);
            this.panel1.TabIndex = 0;
            this.panel1.DoubleClick += new System.EventHandler(this.FormDetails_DoubleClick);
            // 
            // radioButtonCustomer
            // 
            this.radioButtonCustomer.AutoSize = true;
            this.radioButtonCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonCustomer.Location = new System.Drawing.Point(403, 288);
            this.radioButtonCustomer.Name = "radioButtonCustomer";
            this.radioButtonCustomer.Size = new System.Drawing.Size(79, 24);
            this.radioButtonCustomer.TabIndex = 11;
            this.radioButtonCustomer.TabStop = true;
            this.radioButtonCustomer.Text = "Müşteri";
            this.radioButtonCustomer.UseVisualStyleBackColor = true;
            this.radioButtonCustomer.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonAdmin.Location = new System.Drawing.Point(318, 288);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(81, 24);
            this.radioButtonAdmin.TabIndex = 10;
            this.radioButtonAdmin.TabStop = true;
            this.radioButtonAdmin.Text = "Yönetici";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            this.radioButtonAdmin.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // labelAuthorization
            // 
            this.labelAuthorization.AutoSize = true;
            this.labelAuthorization.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAuthorization.Location = new System.Drawing.Point(269, 290);
            this.labelAuthorization.Name = "labelAuthorization";
            this.labelAuthorization.Size = new System.Drawing.Size(46, 20);
            this.labelAuthorization.TabIndex = 9;
            this.labelAuthorization.Text = "Yetki:";
            // 
            // labelCreditCard
            // 
            this.labelCreditCard.AutoSize = true;
            this.labelCreditCard.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCreditCard.Location = new System.Drawing.Point(230, 256);
            this.labelCreditCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreditCard.Name = "labelCreditCard";
            this.labelCreditCard.Size = new System.Drawing.Size(85, 20);
            this.labelCreditCard.TabIndex = 8;
            this.labelCreditCard.Text = "Kredi Kartı:";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPhone.Location = new System.Drawing.Point(252, 222);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(63, 20);
            this.labelPhone.TabIndex = 7;
            this.labelPhone.Text = "Telefon:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAddress.Location = new System.Drawing.Point(263, 188);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(52, 20);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Adres:";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGender.Location = new System.Drawing.Point(249, 154);
            this.labelGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(66, 20);
            this.labelGender.TabIndex = 5;
            this.labelGender.Text = "Cinsiyet:";
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBirthday.Location = new System.Drawing.Point(209, 120);
            this.labelBirthday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(106, 20);
            this.labelBirthday.TabIndex = 4;
            this.labelBirthday.Text = "Doğum Tarihi:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEmail.Location = new System.Drawing.Point(258, 86);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(57, 20);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "E-Mail:";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSurname.Location = new System.Drawing.Point(256, 52);
            this.labelSurname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(59, 20);
            this.labelSurname.TabIndex = 2;
            this.labelSurname.Text = "Soyadı:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelName.Location = new System.Drawing.Point(279, 18);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(36, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Adı:";
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(26, 26);
            this.pictureBoxPhoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(157, 194);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPhoto.TabIndex = 0;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelExit.ForeColor = System.Drawing.Color.Silver;
            this.labelExit.Location = new System.Drawing.Point(515, 358);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(176, 20);
            this.labelExit.TabIndex = 1;
            this.labelExit.Text = "(Çıkmak İçin Çift Tıklayın)";
            this.labelExit.DoubleClick += new System.EventHandler(this.FormDetails_DoubleClick);
            // 
            // FormDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(723, 387);
            this.ControlBox = false;
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Müşteri Detayları";
            this.Load += new System.EventHandler(this.FormDetails_Load);
            this.DoubleClick += new System.EventHandler(this.FormDetails_DoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Label labelCreditCard;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label labelAuthorization;
        private System.Windows.Forms.RadioButton radioButtonCustomer;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
    }
}