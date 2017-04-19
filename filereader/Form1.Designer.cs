namespace filereader
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
            this.listBoxDocuments = new System.Windows.Forms.ListBox();
            this.rtbDocViewer = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listBoxDocuments
            // 
            this.listBoxDocuments.FormattingEnabled = true;
            this.listBoxDocuments.Location = new System.Drawing.Point(12, 12);
            this.listBoxDocuments.Name = "listBoxDocuments";
            this.listBoxDocuments.Size = new System.Drawing.Size(538, 147);
            this.listBoxDocuments.TabIndex = 0;
            // 
            // rtbDocViewer
            // 
            this.rtbDocViewer.Location = new System.Drawing.Point(12, 165);
            this.rtbDocViewer.Name = "rtbDocViewer";
            this.rtbDocViewer.Size = new System.Drawing.Size(538, 207);
            this.rtbDocViewer.TabIndex = 1;
            this.rtbDocViewer.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 409);
            this.Controls.Add(this.rtbDocViewer);
            this.Controls.Add(this.listBoxDocuments);
            this.Name = "Form1";
            this.Text = "File Reader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDocuments;
        private System.Windows.Forms.RichTextBox rtbDocViewer;
    }
}

