
namespace GymXML
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.LableUsername = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.LabelParola = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnConectare = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Sigmar One", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(619, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(180, 0, 180, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 154);
            this.label1.TabIndex = 1;
            this.label1.Text = "Power Gym";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LableUsername
            // 
            this.LableUsername.AutoSize = true;
            this.LableUsername.Font = new System.Drawing.Font("Sigmar One", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableUsername.Location = new System.Drawing.Point(117, 219);
            this.LableUsername.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.LableUsername.Name = "LableUsername";
            this.LableUsername.Size = new System.Drawing.Size(94, 24);
            this.LableUsername.TabIndex = 2;
            this.LableUsername.Text = "Username";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(121, 270);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(182, 22);
            this.TxtUsername.TabIndex = 3;
            // 
            // LabelParola
            // 
            this.LabelParola.Font = new System.Drawing.Font("Sigmar One", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelParola.Location = new System.Drawing.Point(117, 334);
            this.LabelParola.Name = "LabelParola";
            this.LabelParola.Size = new System.Drawing.Size(102, 25);
            this.LabelParola.TabIndex = 4;
            this.LabelParola.Text = "Parola";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(121, 389);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(182, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // btnConectare
            // 
            this.btnConectare.Font = new System.Drawing.Font("Noto Sans", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectare.Location = new System.Drawing.Point(238, 542);
            this.btnConectare.Name = "btnConectare";
            this.btnConectare.Size = new System.Drawing.Size(124, 61);
            this.btnConectare.TabIndex = 6;
            this.btnConectare.Text = "Conectare";
            this.btnConectare.UseVisualStyleBackColor = true;
            this.btnConectare.Click += new System.EventHandler(this.btnConectare_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Noto Sans", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(860, 542);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(151, 61);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Inregistreaza-te";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1441, 742);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnConectare);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.LabelParola);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.LableUsername);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LableUsername;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label LabelParola;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConectare;
        private System.Windows.Forms.Button btnRegister;
    }
}

