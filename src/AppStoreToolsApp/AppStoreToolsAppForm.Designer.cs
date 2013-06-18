namespace AppStoreToolsApp
{
    partial class AppStoreToolsAppForm
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
            this.button_Execute = new System.Windows.Forms.Button();
            this.textBox_Display = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(862, 155);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(125, 49);
            this.button_Execute.TabIndex = 4;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // textBox_Display
            // 
            this.textBox_Display.Location = new System.Drawing.Point(1, 225);
            this.textBox_Display.Multiline = true;
            this.textBox_Display.Name = "textBox_Display";
            this.textBox_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Display.Size = new System.Drawing.Size(1033, 521);
            this.textBox_Display.TabIndex = 5;
            // 
            // AppStoreToolsAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 744);
            this.Controls.Add(this.textBox_Display);
            this.Controls.Add(this.button_Execute);
            this.Name = "AppStoreToolsAppForm";
            this.Text = "AppStoreToolsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.TextBox textBox_Display;
    }
}

