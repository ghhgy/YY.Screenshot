﻿
namespace YY.Screenshot
{
    partial class ScreenshotForm
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
            this.SuspendLayout();
            // 
            // ScreenshotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 128);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenshotForm";
            this.Text = "ScreenshotForm";
            this.Load += new System.EventHandler(this.ScreenshotForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenshotForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenshotForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenshotForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}