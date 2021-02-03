namespace CSGORCON
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.loginPanel = new System.Windows.Forms.Panel();
			this.loginButton = new System.Windows.Forms.Button();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.loggedpanel = new System.Windows.Forms.Panel();
			this.textBoxCmdDesc = new System.Windows.Forms.TextBox();
			this.textBoxLog = new System.Windows.Forms.TextBox();
			this.textBoxCommand = new System.Windows.Forms.TextBox();
			this.sendCmdButton = new System.Windows.Forms.Button();
			this.loginPanel.SuspendLayout();
			this.loggedpanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxIP
			// 
			this.textBoxIP.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxIP.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.textBoxIP.Location = new System.Drawing.Point(132, 97);
			this.textBoxIP.MaxLength = 23;
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.Size = new System.Drawing.Size(214, 20);
			this.textBoxIP.TabIndex = 0;
			this.textBoxIP.Text = "192.168.1.101:27015";
			this.textBoxIP.TextChanged += new System.EventHandler(this.textBoxIP_TextChanged);
			// 
			// loginPanel
			// 
			this.loginPanel.Controls.Add(this.loginButton);
			this.loginPanel.Controls.Add(this.textBoxPassword);
			this.loginPanel.Controls.Add(this.textBoxIP);
			this.loginPanel.Location = new System.Drawing.Point(12, 12);
			this.loginPanel.Name = "loginPanel";
			this.loginPanel.Size = new System.Drawing.Size(483, 426);
			this.loginPanel.TabIndex = 1;
			// 
			// loginButton
			// 
			this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loginButton.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.loginButton.Location = new System.Drawing.Point(405, 400);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(75, 23);
			this.loginButton.TabIndex = 2;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxPassword.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.textBoxPassword.Location = new System.Drawing.Point(132, 209);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(214, 20);
			this.textBoxPassword.TabIndex = 1;
			this.textBoxPassword.Text = "1234";
			// 
			// loggedpanel
			// 
			this.loggedpanel.Controls.Add(this.textBoxCmdDesc);
			this.loggedpanel.Controls.Add(this.textBoxLog);
			this.loggedpanel.Controls.Add(this.textBoxCommand);
			this.loggedpanel.Controls.Add(this.sendCmdButton);
			this.loggedpanel.Location = new System.Drawing.Point(12, 12);
			this.loggedpanel.Name = "loggedpanel";
			this.loggedpanel.Size = new System.Drawing.Size(483, 426);
			this.loggedpanel.TabIndex = 3;
			this.loggedpanel.Visible = false;
			// 
			// textBoxCmdDesc
			// 
			this.textBoxCmdDesc.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCmdDesc.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.textBoxCmdDesc.Location = new System.Drawing.Point(3, 315);
			this.textBoxCmdDesc.Multiline = true;
			this.textBoxCmdDesc.Name = "textBoxCmdDesc";
			this.textBoxCmdDesc.Size = new System.Drawing.Size(477, 79);
			this.textBoxCmdDesc.TabIndex = 3;
			// 
			// textBoxLog
			// 
			this.textBoxLog.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxLog.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.textBoxLog.Location = new System.Drawing.Point(3, 3);
			this.textBoxLog.Multiline = true;
			this.textBoxLog.Name = "textBoxLog";
			this.textBoxLog.ReadOnly = true;
			this.textBoxLog.Size = new System.Drawing.Size(477, 306);
			this.textBoxLog.TabIndex = 2;
			// 
			// textBoxCommand
			// 
			this.textBoxCommand.AutoCompleteCustomSource.AddRange(CommandList.Commands.ConvertAll(new System.Converter<Command, string>(comm => comm.command)).ToArray());
			this.textBoxCommand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textBoxCommand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBoxCommand.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCommand.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.textBoxCommand.Location = new System.Drawing.Point(3, 402);
			this.textBoxCommand.Name = "textBoxCommand";
			this.textBoxCommand.Size = new System.Drawing.Size(426, 20);
			this.textBoxCommand.TabIndex = 1;
			this.textBoxCommand.TextChanged += new System.EventHandler(this.textBoxCommand_TextChanged);
			this.textBoxCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCommand_KeyPress);
			// 
			// sendCmdButton
			// 
			this.sendCmdButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sendCmdButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.sendCmdButton.Location = new System.Drawing.Point(435, 400);
			this.sendCmdButton.Name = "sendCmdButton";
			this.sendCmdButton.Size = new System.Drawing.Size(45, 23);
			this.sendCmdButton.TabIndex = 0;
			this.sendCmdButton.Text = "Send";
			this.sendCmdButton.UseVisualStyleBackColor = true;
			this.sendCmdButton.Click += new System.EventHandler(this.sendCmdButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
			this.ClientSize = new System.Drawing.Size(507, 450);
			this.Controls.Add(this.loginPanel);
			this.Controls.Add(this.loggedpanel);
			this.Name = "Form1";
			this.Text = "RCON";
			this.loginPanel.ResumeLayout(false);
			this.loginPanel.PerformLayout();
			this.loggedpanel.ResumeLayout(false);
			this.loggedpanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.Panel loginPanel;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.Panel loggedpanel;
		private System.Windows.Forms.TextBox textBoxCmdDesc;
		private System.Windows.Forms.TextBox textBoxLog;
		private System.Windows.Forms.TextBox textBoxCommand;
		private System.Windows.Forms.Button sendCmdButton;
	}
}

