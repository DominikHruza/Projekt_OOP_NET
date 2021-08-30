
namespace WinFormsDesktopClient
{
    partial class PlayerRankingsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRankingsUC));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goalsScoredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlRankings = new System.Windows.Forms.FlowLayoutPanel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // sortByToolStripMenuItem
            // 
            resources.ApplyResources(this.sortByToolStripMenuItem, "sortByToolStripMenuItem");
            this.sortByToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yellowCardsToolStripMenuItem,
            this.goalsScoredToolStripMenuItem});
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            // 
            // yellowCardsToolStripMenuItem
            // 
            resources.ApplyResources(this.yellowCardsToolStripMenuItem, "yellowCardsToolStripMenuItem");
            this.yellowCardsToolStripMenuItem.Name = "yellowCardsToolStripMenuItem";
            this.yellowCardsToolStripMenuItem.Click += new System.EventHandler(this.yellowCardsToolStripMenuItem_Click);
            // 
            // goalsScoredToolStripMenuItem
            // 
            resources.ApplyResources(this.goalsScoredToolStripMenuItem, "goalsScoredToolStripMenuItem");
            this.goalsScoredToolStripMenuItem.Name = "goalsScoredToolStripMenuItem";
            this.goalsScoredToolStripMenuItem.Click += new System.EventHandler(this.goalsScoredToolStripMenuItem_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlRankings
            // 
            resources.ApplyResources(this.pnlRankings, "pnlRankings");
            this.pnlRankings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRankings.Name = "pnlRankings";
            // 
            // printDocument1
            // 
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // PlayerRankingsUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlRankings);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PlayerRankingsUC";
            this.Load += new System.EventHandler(this.PlayerRankingsUC_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goalsScoredToolStripMenuItem;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.FlowLayoutPanel pnlRankings;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
