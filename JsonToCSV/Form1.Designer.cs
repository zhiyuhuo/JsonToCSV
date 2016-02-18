namespace JsonToCSV
{
    partial class Main
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_openjson = new System.Windows.Forms.Button();
            this.button_readjsonlist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button_openjson
            // 
            this.button_openjson.Location = new System.Drawing.Point(12, 214);
            this.button_openjson.Name = "button_openjson";
            this.button_openjson.Size = new System.Drawing.Size(75, 35);
            this.button_openjson.TabIndex = 0;
            this.button_openjson.Text = "Open Json";
            this.button_openjson.UseVisualStyleBackColor = true;
            this.button_openjson.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_readjsonlist
            // 
            this.button_readjsonlist.Location = new System.Drawing.Point(93, 214);
            this.button_readjsonlist.Name = "button_readjsonlist";
            this.button_readjsonlist.Size = new System.Drawing.Size(75, 35);
            this.button_readjsonlist.TabIndex = 1;
            this.button_readjsonlist.Text = "Read Json List";
            this.button_readjsonlist.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_readjsonlist);
            this.Controls.Add(this.button_openjson);
            this.Name = "Main";
            this.Text = "JsonToCSV";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_openjson;
        private System.Windows.Forms.Button button_readjsonlist;
    }
}

