namespace UserInterface
{
    partial class StartMenu
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
            this.NewGame = new System.Windows.Forms.Button();
            this.LoadGame = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.BackColor = System.Drawing.SystemColors.Control;
            this.NewGame.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGame.Location = new System.Drawing.Point(476, 33);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(169, 54);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "Start New Game";
            this.NewGame.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.NewGame.UseVisualStyleBackColor = false;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // LoadGame
            // 
            this.LoadGame.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadGame.Location = new System.Drawing.Point(476, 117);
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.Size = new System.Drawing.Size(169, 54);
            this.LoadGame.TabIndex = 1;
            this.LoadGame.Text = "Load Game";
            this.LoadGame.UseVisualStyleBackColor = true;
            this.LoadGame.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(476, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 54);
            this.button2.TabIndex = 2;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterface.Properties.Resources.MenuBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(684, 341);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LoadGame);
            this.Controls.Add(this.NewGame);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 380);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 380);
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heroes Of Singapore Sling";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button LoadGame;
        private System.Windows.Forms.Button button2;
    }
}