
namespace DarkSoulsRemastest_Installer
{
    partial class MainForm
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
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.labelDir = new System.Windows.Forms.Label();
            this.buttonDirSel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.labelInfoModVerOnline = new System.Windows.Forms.Label();
            this.labelInfoModded = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelModded = new System.Windows.Forms.Label();
            this.labelModVerOnline = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(12, 34);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(521, 20);
            this.textBoxDir.TabIndex = 0;
            // 
            // labelDir
            // 
            this.labelDir.AutoSize = true;
            this.labelDir.Location = new System.Drawing.Point(9, 9);
            this.labelDir.Name = "labelDir";
            this.labelDir.Size = new System.Drawing.Size(204, 13);
            this.labelDir.TabIndex = 1;
            this.labelDir.Text = "Detected Dark Souls installation directory:";
            // 
            // buttonDirSel
            // 
            this.buttonDirSel.Location = new System.Drawing.Point(448, 2);
            this.buttonDirSel.Name = "buttonDirSel";
            this.buttonDirSel.Size = new System.Drawing.Size(85, 26);
            this.buttonDirSel.TabIndex = 2;
            this.buttonDirSel.Text = "Change...";
            this.buttonDirSel.UseVisualStyleBackColor = true;
            this.buttonDirSel.Click += new System.EventHandler(this.ButtonDirSel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelModVerOnline);
            this.groupBox1.Controls.Add(this.labelModded);
            this.groupBox1.Controls.Add(this.buttonInstall);
            this.groupBox1.Controls.Add(this.labelInfoModVerOnline);
            this.groupBox1.Controls.Add(this.labelInfoModded);
            this.groupBox1.Location = new System.Drawing.Point(13, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(435, 19);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 64);
            this.buttonInstall.TabIndex = 2;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.ButtonInstall_Click);
            // 
            // labelInfoModVerOnline
            // 
            this.labelInfoModVerOnline.AutoSize = true;
            this.labelInfoModVerOnline.Location = new System.Drawing.Point(6, 45);
            this.labelInfoModVerOnline.Name = "labelInfoModVerOnline";
            this.labelInfoModVerOnline.Size = new System.Drawing.Size(129, 13);
            this.labelInfoModVerOnline.TabIndex = 1;
            this.labelInfoModVerOnline.Text = "Most recent mod version: ";
            // 
            // labelInfoModded
            // 
            this.labelInfoModded.AutoSize = true;
            this.labelInfoModded.Location = new System.Drawing.Point(6, 19);
            this.labelInfoModded.Name = "labelInfoModded";
            this.labelInfoModded.Size = new System.Drawing.Size(78, 13);
            this.labelInfoModded.TabIndex = 0;
            this.labelInfoModded.Text = "Mod installed? ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 155);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(520, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(12, 185);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(41, 13);
            this.labelProgress.TabIndex = 5;
            this.labelProgress.Text = "Ready.";
            // 
            // labelModded
            // 
            this.labelModded.AutoSize = true;
            this.labelModded.Location = new System.Drawing.Point(153, 19);
            this.labelModded.Name = "labelModded";
            this.labelModded.Size = new System.Drawing.Size(28, 13);
            this.labelModded.TabIndex = 3;
            this.labelModded.Text = "<...>";
            // 
            // labelModVerOnline
            // 
            this.labelModVerOnline.AutoSize = true;
            this.labelModVerOnline.Location = new System.Drawing.Point(153, 45);
            this.labelModVerOnline.Name = "labelModVerOnline";
            this.labelModVerOnline.Size = new System.Drawing.Size(28, 13);
            this.labelModVerOnline.TabIndex = 4;
            this.labelModVerOnline.Text = "<...>";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 212);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDirSel);
            this.Controls.Add(this.labelDir);
            this.Controls.Add(this.textBoxDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "DarkSoulsRemastest-Installer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Label labelDir;
        private System.Windows.Forms.Button buttonDirSel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelInfoModVerOnline;
        private System.Windows.Forms.Label labelInfoModded;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label labelModVerOnline;
        private System.Windows.Forms.Label labelModded;
    }
}

