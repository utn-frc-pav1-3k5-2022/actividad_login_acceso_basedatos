namespace Login_BD
{
    partial class frmLogin
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
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbln_Usuario = new System.Windows.Forms.Label();
            this.lbln_Password = new System.Windows.Forms.Label();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(154, 50);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(326, 27);
            this.txt_Usuario.TabIndex = 0;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(154, 116);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(326, 27);
            this.txt_Password.TabIndex = 1;
            // 
            // lbln_Usuario
            // 
            this.lbln_Usuario.AutoSize = true;
            this.lbln_Usuario.Location = new System.Drawing.Point(70, 50);
            this.lbln_Usuario.Name = "lbln_Usuario";
            this.lbln_Usuario.Size = new System.Drawing.Size(59, 20);
            this.lbln_Usuario.TabIndex = 2;
            this.lbln_Usuario.Text = "Usuario";
            // 
            // lbln_Password
            // 
            this.lbln_Password.AutoSize = true;
            this.lbln_Password.Location = new System.Drawing.Point(70, 116);
            this.lbln_Password.Name = "lbln_Password";
            this.lbln_Password.Size = new System.Drawing.Size(70, 20);
            this.lbln_Password.TabIndex = 3;
            this.lbln_Password.Text = "Password";
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.Location = new System.Drawing.Point(301, 183);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(94, 29);
            this.btn_Ingresar.TabIndex = 4;
            this.btn_Ingresar.Text = "Ingresar";
            this.btn_Ingresar.UseVisualStyleBackColor = true;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Location = new System.Drawing.Point(417, 183);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(94, 29);
            this.btn_Salir.TabIndex = 5;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 224);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Ingresar);
            this.Controls.Add(this.lbln_Password);
            this.Controls.Add(this.lbln_Usuario);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txt_Usuario;
        private TextBox txt_Password;
        private Label lbln_Usuario;
        private Label lbln_Password;
        private Button btn_Ingresar;
        private Button btn_Salir;
    }
}