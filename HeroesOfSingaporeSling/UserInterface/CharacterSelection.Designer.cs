namespace UserInterface
{
    partial class CharacterSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterSelection));
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.HeroesSource = new System.Windows.Forms.BindingSource(this.components);
            this.Navigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.StrenghtLabel = new System.Windows.Forms.Label();
            this.VitalityLabel = new System.Windows.Forms.Label();
            this.WisdomLabel = new System.Windows.Forms.Label();
            this.AgilityLabel = new System.Windows.Forms.Label();
            this.Strenght = new System.Windows.Forms.Label();
            this.Vitality = new System.Windows.Forms.Label();
            this.Wisdom = new System.Windows.Forms.Label();
            this.Agility = new System.Windows.Forms.Label();
            this.HeroIcon = new System.Windows.Forms.PictureBox();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.HPLabel = new System.Windows.Forms.Label();
            this.ManaLabel = new System.Windows.Forms.Label();
            this.MinDamage = new System.Windows.Forms.Label();
            this.separator1 = new System.Windows.Forms.Label();
            this.MaxDamage = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.DefenceLabel = new System.Windows.Forms.Label();
            this.Defence = new System.Windows.Forms.Label();
            this.PercentSeparator = new System.Windows.Forms.Label();
            this.HP = new System.Windows.Forms.Label();
            this.Mana = new System.Windows.Forms.Label();
            this.StartGame = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeroesSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Navigator)).BeginInit();
            this.Navigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeroIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "Name", true));
            this.NameTextBox.Location = new System.Drawing.Point(53, 6);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // HeroesSource
            // 
            this.HeroesSource.DataSource = typeof(GameAssets.Hero);
            // 
            // Navigator
            // 
            this.Navigator.AddNewItem = null;
            this.Navigator.BindingSource = this.HeroesSource;
            this.Navigator.CountItem = null;
            this.Navigator.DeleteItem = null;
            this.Navigator.Dock = System.Windows.Forms.DockStyle.None;
            this.Navigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Navigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem});
            this.Navigator.Location = new System.Drawing.Point(9, 272);
            this.Navigator.MoveFirstItem = null;
            this.Navigator.MoveLastItem = null;
            this.Navigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Navigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Navigator.Name = "Navigator";
            this.Navigator.PositionItem = null;
            this.Navigator.Size = new System.Drawing.Size(61, 25);
            this.Navigator.TabIndex = 3;
            this.Navigator.Text = "Hero Navigator";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // StrenghtLabel
            // 
            this.StrenghtLabel.AutoSize = true;
            this.StrenghtLabel.Location = new System.Drawing.Point(12, 112);
            this.StrenghtLabel.Name = "StrenghtLabel";
            this.StrenghtLabel.Size = new System.Drawing.Size(47, 13);
            this.StrenghtLabel.TabIndex = 4;
            this.StrenghtLabel.Text = "Strenght";
            // 
            // VitalityLabel
            // 
            this.VitalityLabel.AutoSize = true;
            this.VitalityLabel.Location = new System.Drawing.Point(22, 141);
            this.VitalityLabel.Name = "VitalityLabel";
            this.VitalityLabel.Size = new System.Drawing.Size(37, 13);
            this.VitalityLabel.TabIndex = 5;
            this.VitalityLabel.Text = "Vitality";
            // 
            // WisdomLabel
            // 
            this.WisdomLabel.AutoSize = true;
            this.WisdomLabel.Location = new System.Drawing.Point(14, 174);
            this.WisdomLabel.Name = "WisdomLabel";
            this.WisdomLabel.Size = new System.Drawing.Size(45, 13);
            this.WisdomLabel.TabIndex = 6;
            this.WisdomLabel.Text = "Wisdom";
            // 
            // AgilityLabel
            // 
            this.AgilityLabel.AutoSize = true;
            this.AgilityLabel.Location = new System.Drawing.Point(25, 206);
            this.AgilityLabel.Name = "AgilityLabel";
            this.AgilityLabel.Size = new System.Drawing.Size(34, 13);
            this.AgilityLabel.TabIndex = 7;
            this.AgilityLabel.Text = "Agility";
            // 
            // Strenght
            // 
            this.Strenght.AutoSize = true;
            this.Strenght.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "Strenght", true));
            this.Strenght.Location = new System.Drawing.Point(82, 112);
            this.Strenght.Name = "Strenght";
            this.Strenght.Size = new System.Drawing.Size(35, 13);
            this.Strenght.TabIndex = 8;
            this.Strenght.Text = "label1";
            // 
            // Vitality
            // 
            this.Vitality.AutoSize = true;
            this.Vitality.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "Vitality", true));
            this.Vitality.Location = new System.Drawing.Point(82, 141);
            this.Vitality.Name = "Vitality";
            this.Vitality.Size = new System.Drawing.Size(35, 13);
            this.Vitality.TabIndex = 9;
            this.Vitality.Text = "label2";
            // 
            // Wisdom
            // 
            this.Wisdom.AutoSize = true;
            this.Wisdom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "Wisdom", true));
            this.Wisdom.Location = new System.Drawing.Point(82, 174);
            this.Wisdom.Name = "Wisdom";
            this.Wisdom.Size = new System.Drawing.Size(35, 13);
            this.Wisdom.TabIndex = 10;
            this.Wisdom.Text = "label3";
            // 
            // Agility
            // 
            this.Agility.AutoSize = true;
            this.Agility.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "Agility", true));
            this.Agility.Location = new System.Drawing.Point(82, 206);
            this.Agility.Name = "Agility";
            this.Agility.Size = new System.Drawing.Size(35, 13);
            this.Agility.TabIndex = 11;
            this.Agility.Text = "label4";
            // 
            // HeroIcon
            // 
            this.HeroIcon.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.HeroesSource, "ExploreImage", true));
            this.HeroIcon.Location = new System.Drawing.Point(85, 43);
            this.HeroIcon.Name = "HeroIcon";
            this.HeroIcon.Size = new System.Drawing.Size(59, 55);
            this.HeroIcon.TabIndex = 12;
            this.HeroIcon.TabStop = false;
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Location = new System.Drawing.Point(174, 141);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(47, 13);
            this.DamageLabel.TabIndex = 13;
            this.DamageLabel.Text = "Damage";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(183, 174);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(38, 13);
            this.SpeedLabel.TabIndex = 14;
            this.SpeedLabel.Text = "Speed";
            // 
            // HPLabel
            // 
            this.HPLabel.AutoSize = true;
            this.HPLabel.Location = new System.Drawing.Point(183, 206);
            this.HPLabel.Name = "HPLabel";
            this.HPLabel.Size = new System.Drawing.Size(38, 13);
            this.HPLabel.TabIndex = 15;
            this.HPLabel.Text = "Health";
            // 
            // ManaLabel
            // 
            this.ManaLabel.AutoSize = true;
            this.ManaLabel.Location = new System.Drawing.Point(187, 237);
            this.ManaLabel.Name = "ManaLabel";
            this.ManaLabel.Size = new System.Drawing.Size(34, 13);
            this.ManaLabel.TabIndex = 16;
            this.ManaLabel.Text = "Mana";
            // 
            // MinDamage
            // 
            this.MinDamage.AutoSize = true;
            this.MinDamage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "MinDamage", true));
            this.MinDamage.Location = new System.Drawing.Point(244, 141);
            this.MinDamage.Name = "MinDamage";
            this.MinDamage.Size = new System.Drawing.Size(13, 13);
            this.MinDamage.TabIndex = 17;
            this.MinDamage.Text = "0";
            // 
            // separator1
            // 
            this.separator1.AutoSize = true;
            this.separator1.Location = new System.Drawing.Point(263, 141);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(10, 13);
            this.separator1.TabIndex = 18;
            this.separator1.Text = "-";
            // 
            // MaxDamage
            // 
            this.MaxDamage.AutoSize = true;
            this.MaxDamage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "MaxDamage", true));
            this.MaxDamage.Location = new System.Drawing.Point(279, 141);
            this.MaxDamage.Name = "MaxDamage";
            this.MaxDamage.Size = new System.Drawing.Size(13, 13);
            this.MaxDamage.TabIndex = 19;
            this.MaxDamage.Text = "0";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "Speed", true));
            this.Speed.Location = new System.Drawing.Point(244, 174);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(35, 13);
            this.Speed.TabIndex = 20;
            this.Speed.Text = "label1";
            // 
            // DefenceLabel
            // 
            this.DefenceLabel.AutoSize = true;
            this.DefenceLabel.Location = new System.Drawing.Point(173, 112);
            this.DefenceLabel.Name = "DefenceLabel";
            this.DefenceLabel.Size = new System.Drawing.Size(48, 13);
            this.DefenceLabel.TabIndex = 21;
            this.DefenceLabel.Text = "Defence";
            // 
            // Defence
            // 
            this.Defence.AutoSize = true;
            this.Defence.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "Defence", true));
            this.Defence.Location = new System.Drawing.Point(244, 112);
            this.Defence.Name = "Defence";
            this.Defence.Size = new System.Drawing.Size(19, 13);
            this.Defence.TabIndex = 22;
            this.Defence.Text = "00";
            // 
            // PercentSeparator
            // 
            this.PercentSeparator.AutoSize = true;
            this.PercentSeparator.Location = new System.Drawing.Point(270, 112);
            this.PercentSeparator.Name = "PercentSeparator";
            this.PercentSeparator.Size = new System.Drawing.Size(15, 13);
            this.PercentSeparator.TabIndex = 23;
            this.PercentSeparator.Text = "%";
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "MaxHealt", true));
            this.HP.Location = new System.Drawing.Point(244, 205);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(35, 13);
            this.HP.TabIndex = 24;
            this.HP.Text = "label1";
            // 
            // Mana
            // 
            this.Mana.AutoSize = true;
            this.Mana.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HeroesSource, "MaxMana", true));
            this.Mana.Location = new System.Drawing.Point(244, 237);
            this.Mana.Name = "Mana";
            this.Mana.Size = new System.Drawing.Size(35, 13);
            this.Mana.TabIndex = 25;
            this.Mana.Text = "label1";
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(214, 272);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(75, 23);
            this.StartGame.TabIndex = 26;
            this.StartGame.Text = "Begin";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(133, 272);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 27;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // CharacterSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 307);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.Mana);
            this.Controls.Add(this.HP);
            this.Controls.Add(this.PercentSeparator);
            this.Controls.Add(this.Defence);
            this.Controls.Add(this.DefenceLabel);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.MaxDamage);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.MinDamage);
            this.Controls.Add(this.ManaLabel);
            this.Controls.Add(this.HPLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.DamageLabel);
            this.Controls.Add(this.HeroIcon);
            this.Controls.Add(this.Agility);
            this.Controls.Add(this.Wisdom);
            this.Controls.Add(this.Vitality);
            this.Controls.Add(this.Strenght);
            this.Controls.Add(this.AgilityLabel);
            this.Controls.Add(this.WisdomLabel);
            this.Controls.Add(this.VitalityLabel);
            this.Controls.Add(this.StrenghtLabel);
            this.Controls.Add(this.Navigator);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Name = "CharacterSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Character Selection";
            ((System.ComponentModel.ISupportInitialize)(this.HeroesSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Navigator)).EndInit();
            this.Navigator.ResumeLayout(false);
            this.Navigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeroIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource HeroesSource;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.BindingNavigator Navigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.Label StrenghtLabel;
        private System.Windows.Forms.Label VitalityLabel;
        private System.Windows.Forms.Label WisdomLabel;
        private System.Windows.Forms.Label AgilityLabel;
        private System.Windows.Forms.Label Strenght;
        private System.Windows.Forms.Label Vitality;
        private System.Windows.Forms.Label Wisdom;
        private System.Windows.Forms.Label Agility;
        private System.Windows.Forms.PictureBox HeroIcon;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label HPLabel;
        private System.Windows.Forms.Label ManaLabel;
        private System.Windows.Forms.Label MinDamage;
        private System.Windows.Forms.Label separator1;
        private System.Windows.Forms.Label MaxDamage;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label DefenceLabel;
        private System.Windows.Forms.Label Defence;
        private System.Windows.Forms.Label PercentSeparator;
        private System.Windows.Forms.Label HP;
        private System.Windows.Forms.Label Mana;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button Cancel;
    }
}