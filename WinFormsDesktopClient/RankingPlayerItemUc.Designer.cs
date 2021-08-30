
namespace WinFormsDesktopClient
{
    partial class RankingPlayerItemUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingPlayerItemUc));
            this.imgPlayer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbCards = new System.Windows.Forms.Label();
            this.lbGoals = new System.Windows.Forms.Label();
            this.lbPlayed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPlayer
            // 
            resources.ApplyResources(this.imgPlayer, "imgPlayer");
            this.imgPlayer.Name = "imgPlayer";
            this.imgPlayer.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // lbCards
            // 
            resources.ApplyResources(this.lbCards, "lbCards");
            this.lbCards.Name = "lbCards";
            // 
            // lbGoals
            // 
            resources.ApplyResources(this.lbGoals, "lbGoals");
            this.lbGoals.Name = "lbGoals";
            // 
            // lbPlayed
            // 
            resources.ApplyResources(this.lbPlayed, "lbPlayed");
            this.lbPlayed.Name = "lbPlayed";
            // 
            // RankingPlayerItemUc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lbPlayed);
            this.Controls.Add(this.lbGoals);
            this.Controls.Add(this.lbCards);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgPlayer);
            this.Name = "RankingPlayerItemUc";
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbCards;
        private System.Windows.Forms.Label lbGoals;
        private System.Windows.Forms.Label lbPlayed;
    }
}
