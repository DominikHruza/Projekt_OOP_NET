
namespace WinFormsDesktopClient
{
    partial class PlayerItemUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerItemUC));
            this.imgPlayer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPlayerData = new System.Windows.Forms.Panel();
            this.checkBoxPlayer = new System.Windows.Forms.CheckBox();
            this.iconFavourite = new System.Windows.Forms.PictureBox();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).BeginInit();
            this.pnlPlayerData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconFavourite)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPlayer
            // 
            resources.ApplyResources(this.imgPlayer, "imgPlayer");
            this.imgPlayer.Cursor = System.Windows.Forms.Cursors.Cross;
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pnlPlayerData
            // 
            resources.ApplyResources(this.pnlPlayerData, "pnlPlayerData");
            this.pnlPlayerData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlPlayerData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayerData.Controls.Add(this.checkBoxPlayer);
            this.pnlPlayerData.Controls.Add(this.iconFavourite);
            this.pnlPlayerData.Controls.Add(this.lblCaptain);
            this.pnlPlayerData.Controls.Add(this.lblPosition);
            this.pnlPlayerData.Controls.Add(this.lblShirtNumber);
            this.pnlPlayerData.Controls.Add(this.lblName);
            this.pnlPlayerData.Controls.Add(this.imgPlayer);
            this.pnlPlayerData.Controls.Add(this.label1);
            this.pnlPlayerData.Controls.Add(this.label4);
            this.pnlPlayerData.Controls.Add(this.label2);
            this.pnlPlayerData.Controls.Add(this.label3);
            this.pnlPlayerData.Name = "pnlPlayerData";
            this.pnlPlayerData.Click += new System.EventHandler(this.pnlPlayerData_Click);
            this.pnlPlayerData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPlayerData_MouseDown);
            // 
            // checkBoxPlayer
            // 
            resources.ApplyResources(this.checkBoxPlayer, "checkBoxPlayer");
            this.checkBoxPlayer.Name = "checkBoxPlayer";
            this.checkBoxPlayer.UseVisualStyleBackColor = true;
            // 
            // iconFavourite
            // 
            resources.ApplyResources(this.iconFavourite, "iconFavourite");
            this.iconFavourite.Name = "iconFavourite";
            this.iconFavourite.TabStop = false;
            // 
            // lblCaptain
            // 
            resources.ApplyResources(this.lblCaptain, "lblCaptain");
            this.lblCaptain.Name = "lblCaptain";
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // lblShirtNumber
            // 
            resources.ApplyResources(this.lblShirtNumber, "lblShirtNumber");
            this.lblShirtNumber.Name = "lblShirtNumber";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // PlayerItemUC
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlPlayerData);
            this.Name = "PlayerItemUC";
            this.Load += new System.EventHandler(this.PlayerItemUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).EndInit();
            this.pnlPlayerData.ResumeLayout(false);
            this.pnlPlayerData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconFavourite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlPlayerData;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblShirtNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox iconFavourite;
        private System.Windows.Forms.CheckBox checkBoxPlayer;
    }
}
