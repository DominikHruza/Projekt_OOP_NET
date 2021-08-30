
namespace WinFormsDesktopClient
{
    partial class PlayersTabUC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersTabUC));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFavourites = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuPlayerRemove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromFavouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPlayerAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToFav = new System.Windows.Forms.Button();
            this.btnFromFav = new System.Windows.Forms.Button();
            this.contextMenuPlayerRemove.SuspendLayout();
            this.contextMenuPlayerAdd.SuspendLayout();
            this.SuspendLayout();
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
            // pnlPlayers
            // 
            resources.ApplyResources(this.pnlPlayers, "pnlPlayers");
            this.pnlPlayers.AllowDrop = true;
            this.pnlPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlPlayers_DragDrop);
            this.pnlPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlFavourites_DragEnter);
            // 
            // pnlFavourites
            // 
            resources.ApplyResources(this.pnlFavourites, "pnlFavourites");
            this.pnlFavourites.AllowDrop = true;
            this.pnlFavourites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFavourites.Name = "pnlFavourites";
            this.pnlFavourites.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlFavourites_DragDrop);
            this.pnlFavourites.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlFavourites_DragEnter);
            // 
            // contextMenuPlayerRemove
            // 
            resources.ApplyResources(this.contextMenuPlayerRemove, "contextMenuPlayerRemove");
            this.contextMenuPlayerRemove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromFavouritesToolStripMenuItem});
            this.contextMenuPlayerRemove.Name = "contextMenuPlayerRemove";
            this.contextMenuPlayerRemove.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuPlayer_Closed);
            this.contextMenuPlayerRemove.Opened += new System.EventHandler(this.contextMenuPlayer_Opened);
            // 
            // removeFromFavouritesToolStripMenuItem
            // 
            resources.ApplyResources(this.removeFromFavouritesToolStripMenuItem, "removeFromFavouritesToolStripMenuItem");
            this.removeFromFavouritesToolStripMenuItem.Name = "removeFromFavouritesToolStripMenuItem";
            this.removeFromFavouritesToolStripMenuItem.Click += new System.EventHandler(this.removeFromFavouritesToolStripMenuItem_Click);
            // 
            // contextMenuPlayerAdd
            // 
            resources.ApplyResources(this.contextMenuPlayerAdd, "contextMenuPlayerAdd");
            this.contextMenuPlayerAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavoritesToolStripMenuItem});
            this.contextMenuPlayerAdd.Name = "contextMenuPlayer";
            this.contextMenuPlayerAdd.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuPlayer_Closed);
            this.contextMenuPlayerAdd.Opened += new System.EventHandler(this.contextMenuPlayer_Opened);
            // 
            // addToFavoritesToolStripMenuItem
            // 
            resources.ApplyResources(this.addToFavoritesToolStripMenuItem, "addToFavoritesToolStripMenuItem");
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavoritesToolStripMenuItem_Click);
            // 
            // btnToFav
            // 
            resources.ApplyResources(this.btnToFav, "btnToFav");
            this.btnToFav.Name = "btnToFav";
            this.btnToFav.UseVisualStyleBackColor = true;
            this.btnToFav.Click += new System.EventHandler(this.btnToFavorite_Click);
            // 
            // btnFromFav
            // 
            resources.ApplyResources(this.btnFromFav, "btnFromFav");
            this.btnFromFav.Name = "btnFromFav";
            this.btnFromFav.UseVisualStyleBackColor = true;
            this.btnFromFav.Click += new System.EventHandler(this.btnFromFavourite_Click);
            // 
            // PlayersTabUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFromFav);
            this.Controls.Add(this.btnToFav);
            this.Controls.Add(this.pnlFavourites);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PlayersTabUC";
            this.Load += new System.EventHandler(this.PlayersTabUC_Load);
            this.contextMenuPlayerRemove.ResumeLayout(false);
            this.contextMenuPlayerAdd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlFavourites;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayerAdd;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayerRemove;
        private System.Windows.Forms.ToolStripMenuItem removeFromFavouritesToolStripMenuItem;
        private System.Windows.Forms.Button btnToFav;
        private System.Windows.Forms.Button btnFromFav;
    }
}
