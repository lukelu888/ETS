namespace CGS_Win
{
    partial class Login
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
            this.bn_exit = new System.Windows.Forms.Button();
            this.bn_submit = new System.Windows.Forms.Button();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.txb_username = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.lb_subtitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bn_exit
            // 
            this.bn_exit.AutoSize = true;
            this.bn_exit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bn_exit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.bn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_exit.Location = new System.Drawing.Point(233, 320);
            this.bn_exit.Name = "bn_exit";
            this.bn_exit.Size = new System.Drawing.Size(132, 41);
            this.bn_exit.TabIndex = 13;
            this.bn_exit.Text = "Cancel";
            this.bn_exit.UseVisualStyleBackColor = false;
            this.bn_exit.Click += new System.EventHandler(this.bn_exit_Click);
            // 
            // bn_submit
            // 
            this.bn_submit.AllowDrop = true;
            this.bn_submit.AutoEllipsis = true;
            this.bn_submit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bn_submit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.bn_submit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bn_submit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bn_submit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bn_submit.Location = new System.Drawing.Point(84, 320);
            this.bn_submit.Name = "bn_submit";
            this.bn_submit.Size = new System.Drawing.Size(128, 41);
            this.bn_submit.TabIndex = 12;
            this.bn_submit.Text = "Submit";
            this.bn_submit.UseVisualStyleBackColor = true;
            this.bn_submit.Click += new System.EventHandler(this.bn_submit_Click);
            // 
            // txb_password
            // 
            this.txb_password.Location = new System.Drawing.Point(204, 238);
            this.txb_password.Name = "txb_password";
            this.txb_password.PasswordChar = '*';
            this.txb_password.Size = new System.Drawing.Size(161, 26);
            this.txb_password.TabIndex = 11;
            // 
            // txb_username
            // 
            this.txb_username.Location = new System.Drawing.Point(204, 174);
            this.txb_username.Name = "txb_username";
            this.txb_username.Size = new System.Drawing.Size(161, 26);
            this.txb_username.TabIndex = 10;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.Location = new System.Drawing.Point(79, 239);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(104, 25);
            this.lb_password.TabIndex = 9;
            this.lb_password.Text = "Password:";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(79, 174);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(108, 25);
            this.lb_username.TabIndex = 8;
            this.lb_username.Text = "Username:";
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.Location = new System.Drawing.Point(68, 29);
            this.lb_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(337, 120);
            this.lb_title.TabIndex = 1;
            this.lb_title.Text = "Welcome to the ETS\r\n Telethon System\r\n\r\n\r\n";
            // 
            // lb_subtitle
            // 
            this.lb_subtitle.AutoSize = true;
            this.lb_subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_subtitle.Location = new System.Drawing.Point(43, 124);
            this.lb_subtitle.Name = "lb_subtitle";
            this.lb_subtitle.Size = new System.Drawing.Size(143, 25);
            this.lb_subtitle.TabIndex = 14;
            this.lb_subtitle.Text = "Please log in:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(462, 441);
            this.Controls.Add(this.lb_subtitle);
            this.Controls.Add(this.bn_exit);
            this.Controls.Add(this.bn_submit);
            this.Controls.Add(this.txb_password);
            this.Controls.Add(this.txb_username);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.lb_title);
            this.Name = "Login";
            this.Text = "ETS Telethon System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bn_exit;
        private System.Windows.Forms.Button bn_submit;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.TextBox txb_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label lb_subtitle;
    }
}