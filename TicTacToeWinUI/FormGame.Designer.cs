namespace TicTacToeWinUI
{
    partial class FormGame
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
            labelPlayer1 = new System.Windows.Forms.Label();
            labelPlayer2 = new System.Windows.Forms.Label();
            labelScorePlayer1 = new System.Windows.Forms.Label();
            labelScorePlayer2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // labelPlayer1
            // 
            labelPlayer1.AutoSize = true;
            labelPlayer1.Location = new System.Drawing.Point(12, 9);
            labelPlayer1.Name = "labelPlayer1";
            labelPlayer1.Size = new System.Drawing.Size(68, 20);
            labelPlayer1.TabIndex = 0;
            labelPlayer1.Text = "Player 1 :";
            labelPlayer1.Click += label1_Click_1;
            // 
            // labelPlayer2
            // 
            labelPlayer2.AutoSize = true;
            labelPlayer2.Location = new System.Drawing.Point(151, 9);
            labelPlayer2.Name = "labelPlayer2";
            labelPlayer2.Size = new System.Drawing.Size(68, 20);
            labelPlayer2.TabIndex = 1;
            labelPlayer2.Text = "Player 2 :";
            // 
            // labelScorePlayer1
            // 
            labelScorePlayer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelScorePlayer1.AutoSize = true;
            labelScorePlayer1.Location = new System.Drawing.Point(76, 9);
            labelScorePlayer1.Name = "labelScorePlayer1";
            labelScorePlayer1.Size = new System.Drawing.Size(17, 20);
            labelScorePlayer1.TabIndex = 2;
            labelScorePlayer1.Text = "0";
            labelScorePlayer1.Click += label3_Click;
            // 
            // labelScorePlayer2
            // 
            labelScorePlayer2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelScorePlayer2.AutoSize = true;
            labelScorePlayer2.Location = new System.Drawing.Point(215, 9);
            labelScorePlayer2.Name = "labelScorePlayer2";
            labelScorePlayer2.Size = new System.Drawing.Size(17, 20);
            labelScorePlayer2.TabIndex = 3;
            labelScorePlayer2.Text = "0";
            // 
            // FormGame
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(375, 321);
            Controls.Add(labelScorePlayer2);
            Controls.Add(labelScorePlayer1);
            Controls.Add(labelPlayer2);
            Controls.Add(labelPlayer1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormGame";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tic Tac Toe";
            Load += FormGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelScorePlayer1;
        private System.Windows.Forms.Label labelScorePlayer2;
    }
}