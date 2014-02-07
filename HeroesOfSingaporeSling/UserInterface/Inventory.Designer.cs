namespace UserInterface
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.BootsHolder = new System.Windows.Forms.Panel();
            this.GlovesHolder = new System.Windows.Forms.Panel();
            this.PantsHolder = new System.Windows.Forms.Panel();
            this.ArmorHolder = new System.Windows.Forms.Panel();
            this.CapHolder = new System.Windows.Forms.Panel();
            this.ShieldHolder = new System.Windows.Forms.Panel();
            this.WeaponHolder = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BootsHolder
            // 
            this.BootsHolder.BackColor = System.Drawing.Color.Transparent;
            this.BootsHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BootsHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BootsHolder.Location = new System.Drawing.Point(138, 259);
            this.BootsHolder.Name = "BootsHolder";
            this.BootsHolder.Size = new System.Drawing.Size(50, 50);
            this.BootsHolder.TabIndex = 0;
            // 
            // GlovesHolder
            // 
            this.GlovesHolder.BackColor = System.Drawing.Color.Transparent;
            this.GlovesHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GlovesHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GlovesHolder.Location = new System.Drawing.Point(125, 188);
            this.GlovesHolder.Name = "GlovesHolder";
            this.GlovesHolder.Size = new System.Drawing.Size(42, 45);
            this.GlovesHolder.TabIndex = 1;
            // 
            // PantsHolder
            // 
            this.PantsHolder.BackColor = System.Drawing.Color.Transparent;
            this.PantsHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PantsHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PantsHolder.Location = new System.Drawing.Point(194, 234);
            this.PantsHolder.Name = "PantsHolder";
            this.PantsHolder.Size = new System.Drawing.Size(50, 75);
            this.PantsHolder.TabIndex = 2;
            // 
            // ArmorHolder
            // 
            this.ArmorHolder.BackColor = System.Drawing.Color.Transparent;
            this.ArmorHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ArmorHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ArmorHolder.Location = new System.Drawing.Point(194, 143);
            this.ArmorHolder.Name = "ArmorHolder";
            this.ArmorHolder.Size = new System.Drawing.Size(50, 75);
            this.ArmorHolder.TabIndex = 3;
            // 
            // CapHolder
            // 
            this.CapHolder.BackColor = System.Drawing.Color.Transparent;
            this.CapHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CapHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CapHolder.Location = new System.Drawing.Point(194, 29);
            this.CapHolder.Name = "CapHolder";
            this.CapHolder.Size = new System.Drawing.Size(50, 50);
            this.CapHolder.TabIndex = 1;
            // 
            // ShieldHolder
            // 
            this.ShieldHolder.BackColor = System.Drawing.Color.Transparent;
            this.ShieldHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ShieldHolder.Location = new System.Drawing.Point(40, 174);
            this.ShieldHolder.Name = "ShieldHolder";
            this.ShieldHolder.Size = new System.Drawing.Size(59, 93);
            this.ShieldHolder.TabIndex = 4;
            // 
            // WeaponHolder
            // 
            this.WeaponHolder.BackColor = System.Drawing.Color.Transparent;
            this.WeaponHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WeaponHolder.Location = new System.Drawing.Point(40, 29);
            this.WeaponHolder.Name = "WeaponHolder";
            this.WeaponHolder.Size = new System.Drawing.Size(59, 93);
            this.WeaponHolder.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(316, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 285);
            this.panel1.TabIndex = 6;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.WeaponHolder);
            this.Controls.Add(this.ShieldHolder);
            this.Controls.Add(this.CapHolder);
            this.Controls.Add(this.ArmorHolder);
            this.Controls.Add(this.PantsHolder);
            this.Controls.Add(this.GlovesHolder);
            this.Controls.Add(this.BootsHolder);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BootsHolder;
        private System.Windows.Forms.Panel GlovesHolder;
        private System.Windows.Forms.Panel PantsHolder;
        private System.Windows.Forms.Panel ArmorHolder;
        private System.Windows.Forms.Panel CapHolder;
        private System.Windows.Forms.Panel ShieldHolder;
        private System.Windows.Forms.Panel WeaponHolder;
        private System.Windows.Forms.Panel panel1;


    }
}