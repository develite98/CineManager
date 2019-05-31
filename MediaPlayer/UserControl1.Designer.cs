namespace MediaPlayer
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.axMoviePlayer1 = new AxMOVIEPLAYERLib.AxMoviePlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axMoviePlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axMoviePlayer1
            // 
            this.axMoviePlayer1.Enabled = true;
            this.axMoviePlayer1.Location = new System.Drawing.Point(19, 16);
            this.axMoviePlayer1.Name = "axMoviePlayer1";
            this.axMoviePlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMoviePlayer1.OcxState")));
            this.axMoviePlayer1.Size = new System.Drawing.Size(762, 396);
            this.axMoviePlayer1.TabIndex = 0;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axMoviePlayer1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.axMoviePlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMOVIEPLAYERLib.AxMoviePlayer axMoviePlayer1;
    }
}
