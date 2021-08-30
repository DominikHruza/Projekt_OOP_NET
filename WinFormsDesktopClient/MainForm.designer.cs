
namespace WinFormsDesktopClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabRankingsPlayer = new System.Windows.Forms.TabPage();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.tabTeams = new System.Windows.Forms.TabPage();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMatchRankings = new System.Windows.Forms.TabPage();
            this.btnSettingsChange = new System.Windows.Forms.Button();
            this.playersTabUC1 = new WinFormsDesktopClient.PlayersTabUC();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabRankingsPlayer
            // 
            resources.ApplyResources(this.tabRankingsPlayer, "tabRankingsPlayer");
            this.tabRankingsPlayer.Name = "tabRankingsPlayer";
            this.tabRankingsPlayer.UseVisualStyleBackColor = true;
            // 
            // tabPlayers
            // 
            resources.ApplyResources(this.tabPlayers, "tabPlayers");
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.UseVisualStyleBackColor = true;
            // 
            // tabTeams
            // 
            resources.ApplyResources(this.tabTeams, "tabTeams");
            this.tabTeams.Name = "tabTeams";
            this.tabTeams.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Controls.Add(this.tabTeams);
            this.tabMain.Controls.Add(this.tabPlayers);
            this.tabMain.Controls.Add(this.tabRankingsPlayer);
            this.tabMain.Controls.Add(this.tabMatchRankings);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabMain_Selected);
            // 
            // tabMatchRankings
            // 
            resources.ApplyResources(this.tabMatchRankings, "tabMatchRankings");
            this.tabMatchRankings.Name = "tabMatchRankings";
            this.tabMatchRankings.UseVisualStyleBackColor = true;
            // 
            // btnSettingsChange
            // 
            resources.ApplyResources(this.btnSettingsChange, "btnSettingsChange");
            this.btnSettingsChange.Name = "btnSettingsChange";
            this.btnSettingsChange.UseVisualStyleBackColor = true;
            this.btnSettingsChange.Click += new System.EventHandler(this.btnSettingsChange_Click);
            // 
            // playersTabUC1
            // 
            resources.ApplyResources(this.playersTabUC1, "playersTabUC1");
            this.playersTabUC1.Name = "playersTabUC1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSettingsChange);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PlayersTabUC playersTabUC1;
        private System.Windows.Forms.TabPage tabRankingsPlayer;
        private System.Windows.Forms.TabPage tabPlayers;
        private System.Windows.Forms.TabPage tabTeams;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMatchRankings;
        private System.Windows.Forms.Button btnSettingsChange;
    }
}