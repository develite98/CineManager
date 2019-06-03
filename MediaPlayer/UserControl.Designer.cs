namespace MediaPlayer
{
    partial class UserControl
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

        private AxMOVIEPLAYERLib.AxMoviePlayer axMoviePlayer;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl));
            this.axMoviePlayer = new AxMOVIEPLAYERLib.AxMoviePlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axMoviePlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // axMoviePlayer
            // 
            this.axMoviePlayer.Enabled = true;
            this.axMoviePlayer.Location = new System.Drawing.Point(19, 16);
            this.axMoviePlayer.Name = "axMoviePlayer";
            this.axMoviePlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMoviePlayer.OcxState")));
            this.axMoviePlayer.Size = new System.Drawing.Size(762, 396);
            this.axMoviePlayer.TabIndex = 0;
            // 
            // UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axMoviePlayer);
            this.Name = "UserControl";
            this.Size = new System.Drawing.Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.axMoviePlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
