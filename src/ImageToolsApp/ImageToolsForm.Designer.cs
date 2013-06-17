namespace ImageToolsApp
{
    partial class ImageToolsForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox_Display = new System.Windows.Forms.TextBox();
            this.button_Execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Location = new System.Drawing.Point(12, 22);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(35, 12);
            this.label_Host.TabIndex = 0;
            this.label_Host.Text = "Host:";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(171, 22);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(35, 12);
            this.label_Port.TabIndex = 1;
            this.label_Port.Text = "Port:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "192.168.3.52";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(212, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "6379";
            // 
            // textBox_Display
            // 
            this.textBox_Display.Location = new System.Drawing.Point(12, 184);
            this.textBox_Display.Multiline = true;
            this.textBox_Display.Name = "textBox_Display";
            this.textBox_Display.Size = new System.Drawing.Size(753, 404);
            this.textBox_Display.TabIndex = 4;
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(635, 128);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(83, 30);
            this.button_Execute.TabIndex = 5;
            this.button_Execute.Text = "执行";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // ImageToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 591);
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.textBox_Display);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_Host);
            this.Name = "ImageToolsForm";
            this.Text = "ImageToolsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox_Display;
        private System.Windows.Forms.Button button_Execute;
    }
}

