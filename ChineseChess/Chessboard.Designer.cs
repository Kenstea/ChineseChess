namespace ChineseChess
{
    partial class Chessboard
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StartButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.XLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.XCoordinate = new System.Windows.Forms.Label();
            this.YCoordinate = new System.Windows.Forms.Label();
            this.TypeStatus = new System.Windows.Forms.Label();
            this.TypeStatusLabel = new System.Windows.Forms.Label();
            this.UndoButton = new System.Windows.Forms.Button();
            this.dangerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 559);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(771, 332);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 57);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "开始";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(752, 238);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(70, 13);
            this.XLabel.TabIndex = 2;
            this.XLabel.Text = "X coordinate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(752, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y coordinate:";
            // 
            // XCoordinate
            // 
            this.XCoordinate.AutoSize = true;
            this.XCoordinate.Location = new System.Drawing.Point(836, 238);
            this.XCoordinate.Name = "XCoordinate";
            this.XCoordinate.Size = new System.Drawing.Size(35, 13);
            this.XCoordinate.TabIndex = 2;
            this.XCoordinate.Text = "label1";
            // 
            // YCoordinate
            // 
            this.YCoordinate.AutoSize = true;
            this.YCoordinate.Location = new System.Drawing.Point(836, 266);
            this.YCoordinate.Name = "YCoordinate";
            this.YCoordinate.Size = new System.Drawing.Size(35, 13);
            this.YCoordinate.TabIndex = 3;
            this.YCoordinate.Text = "label2";
            // 
            // TypeStatus
            // 
            this.TypeStatus.AutoSize = true;
            this.TypeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeStatus.Location = new System.Drawing.Point(822, 153);
            this.TypeStatus.Name = "TypeStatus";
            this.TypeStatus.Size = new System.Drawing.Size(0, 24);
            this.TypeStatus.TabIndex = 4;
            // 
            // TypeStatusLabel
            // 
            this.TypeStatusLabel.AutoSize = true;
            this.TypeStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeStatusLabel.Location = new System.Drawing.Point(708, 153);
            this.TypeStatusLabel.Name = "TypeStatusLabel";
            this.TypeStatusLabel.Size = new System.Drawing.Size(108, 24);
            this.TypeStatusLabel.TabIndex = 2;
            this.TypeStatusLabel.Text = "Type Status";
            // 
            // UndoButton
            // 
            this.UndoButton.Enabled = false;
            this.UndoButton.Location = new System.Drawing.Point(771, 420);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 50);
            this.UndoButton.TabIndex = 5;
            this.UndoButton.Text = "悔棋";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // dangerLabel
            // 
            this.dangerLabel.AutoSize = true;
            this.dangerLabel.BackColor = System.Drawing.Color.PeachPuff;
            this.dangerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangerLabel.ForeColor = System.Drawing.Color.Red;
            this.dangerLabel.Location = new System.Drawing.Point(708, 78);
            this.dangerLabel.Name = "dangerLabel";
            this.dangerLabel.Size = new System.Drawing.Size(86, 24);
            this.dangerLabel.TabIndex = 6;
            this.dangerLabel.Text = "    将！  ";
            this.dangerLabel.Visible = false;
            // 
            // Chessboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 596);
            this.Controls.Add(this.dangerLabel);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.TypeStatus);
            this.Controls.Add(this.YCoordinate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TypeStatusLabel);
            this.Controls.Add(this.XCoordinate);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.panel1);
            this.Name = "Chessboard";
            this.Text = "中国象棋";
            this.Load += new System.EventHandler(this.Chessboard_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chessboard_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chessboard_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label XCoordinate;
        private System.Windows.Forms.Label YCoordinate;
        private System.Windows.Forms.Label TypeStatus;
        private System.Windows.Forms.Label TypeStatusLabel;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Label dangerLabel;




    }
}

