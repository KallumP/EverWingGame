namespace EverWing_Remake {
    partial class Menu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.play_btn = new System.Windows.Forms.Button();
            this.scores_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // play_btn
            // 
            this.play_btn.Location = new System.Drawing.Point(13, 13);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(269, 41);
            this.play_btn.TabIndex = 0;
            this.play_btn.Text = "Play!";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // scores_btn
            // 
            this.scores_btn.Location = new System.Drawing.Point(13, 205);
            this.scores_btn.Name = "scores_btn";
            this.scores_btn.Size = new System.Drawing.Size(269, 41);
            this.scores_btn.TabIndex = 1;
            this.scores_btn.Text = "Scores!";
            this.scores_btn.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 450);
            this.Controls.Add(this.scores_btn);
            this.Controls.Add(this.play_btn);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.Button scores_btn;
    }
}

