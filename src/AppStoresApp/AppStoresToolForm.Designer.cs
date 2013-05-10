namespace AppStoresToolApp
{
    partial class AppStoresToolForm
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
            this.label_Host = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_Resoultion = new System.Windows.Forms.Label();
            this.textBox_Resoultion = new System.Windows.Forms.TextBox();
            this.button_Execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Location = new System.Drawing.Point(25, 32);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(35, 12);
            this.label_Host.TabIndex = 0;
            this.label_Host.Text = "Host:";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(25, 70);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(35, 12);
            this.label_Port.TabIndex = 1;
            this.label_Port.Text = "Port:";
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(150, 29);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(100, 21);
            this.textBox_Host.TabIndex = 2;
            this.textBox_Host.Text = "192.168.3.52";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(150, 70);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 21);
            this.textBox_Port.TabIndex = 3;
            this.textBox_Port.Text = "6379";
            // 
            // label_Resoultion
            // 
            this.label_Resoultion.AutoSize = true;
            this.label_Resoultion.Location = new System.Drawing.Point(25, 110);
            this.label_Resoultion.Name = "label_Resoultion";
            this.label_Resoultion.Size = new System.Drawing.Size(95, 12);
            this.label_Resoultion.TabIndex = 4;
            this.label_Resoultion.Text = "Add Resoultion:";
            // 
            // textBox_Resoultion
            // 
            this.textBox_Resoultion.Location = new System.Drawing.Point(150, 110);
            this.textBox_Resoultion.Name = "textBox_Resoultion";
            this.textBox_Resoultion.Size = new System.Drawing.Size(171, 21);
            this.textBox_Resoultion.TabIndex = 5;
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(12, 547);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(75, 23);
            this.button_Execute.TabIndex = 6;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // AppStoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 625);
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.textBox_Resoultion);
            this.Controls.Add(this.label_Resoultion);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Host);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_Host);
            this.Name = "AppStoresForm";
            this.Text = "AppStoresForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_Resoultion;
        private System.Windows.Forms.TextBox textBox_Resoultion;
        private System.Windows.Forms.Button button_Execute;
    }
}

