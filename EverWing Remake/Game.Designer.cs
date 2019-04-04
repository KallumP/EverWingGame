namespace EverWing_Remake {
    partial class Game {
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
            this.components = new System.ComponentModel.Container();
            this.canvas_pic = new System.Windows.Forms.PictureBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.close_btn = new System.Windows.Forms.Button();
            this.shop_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas_pic
            // 
            this.canvas_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas_pic.Location = new System.Drawing.Point(13, 13);
            this.canvas_pic.Name = "canvas_pic";
            this.canvas_pic.Size = new System.Drawing.Size(400, 600);
            this.canvas_pic.TabIndex = 0;
            this.canvas_pic.TabStop = false;
            this.canvas_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_pic_Paint);
            this.canvas_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_pic_MouseMove);
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.Lime;
            this.start_btn.Location = new System.Drawing.Point(13, 640);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(87, 27);
            this.start_btn.TabIndex = 1;
            this.start_btn.Text = "START!";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 10;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.Red;
            this.close_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.close_btn.Location = new System.Drawing.Point(165, 642);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(75, 23);
            this.close_btn.TabIndex = 3;
            this.close_btn.Text = "CLOSE!";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // shop_btn
            // 
            this.shop_btn.BackColor = System.Drawing.Color.Aqua;
            this.shop_btn.Location = new System.Drawing.Point(287, 640);
            this.shop_btn.Name = "shop_btn";
            this.shop_btn.Size = new System.Drawing.Size(63, 27);
            this.shop_btn.TabIndex = 4;
            this.shop_btn.Text = "SHOP!";
            this.shop_btn.UseVisualStyleBackColor = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 687);
            this.Controls.Add(this.shop_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.canvas_pic);
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.canvas_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas_pic;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button shop_btn;
    }
}