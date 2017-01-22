namespace Fisheye
{
    partial class Fisheye
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.boutonAjouter = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.zoneNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.zoneLargeur = new System.Windows.Forms.NumericUpDown();
            this.zoneHauteur = new System.Windows.Forms.NumericUpDown();
            this.bouton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.boutonCharger = new System.Windows.Forms.Button();
            this.boutonSauvegarder = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.zoneLargeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneHauteur)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boutonAjouter
            // 
            this.boutonAjouter.Location = new System.Drawing.Point(640, 184);
            this.boutonAjouter.Name = "boutonAjouter";
            this.boutonAjouter.Size = new System.Drawing.Size(113, 35);
            this.boutonAjouter.TabIndex = 1;
            this.boutonAjouter.Text = "Ajouter Tuile";
            this.boutonAjouter.UseVisualStyleBackColor = true;
            this.boutonAjouter.Click += new System.EventHandler(this.boutonAjouter_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(640, 428);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Quitter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // zoneNom
            // 
            this.zoneNom.Location = new System.Drawing.Point(671, 26);
            this.zoneNom.Name = "zoneNom";
            this.zoneNom.Size = new System.Drawing.Size(101, 20);
            this.zoneNom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(618, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Largeur :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(616, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hauteur :";
            // 
            // zoneLargeur
            // 
            this.zoneLargeur.Location = new System.Drawing.Point(673, 67);
            this.zoneLargeur.Name = "zoneLargeur";
            this.zoneLargeur.Size = new System.Drawing.Size(42, 20);
            this.zoneLargeur.TabIndex = 10;
            // 
            // zoneHauteur
            // 
            this.zoneHauteur.Location = new System.Drawing.Point(673, 99);
            this.zoneHauteur.Name = "zoneHauteur";
            this.zoneHauteur.Size = new System.Drawing.Size(42, 20);
            this.zoneHauteur.TabIndex = 11;
            // 
            // bouton
            // 
            this.bouton.AllowDrop = true;
            this.bouton.BackColor = System.Drawing.Color.Blue;
            this.bouton.Location = new System.Drawing.Point(251, 152);
            this.bouton.Name = "bouton";
            this.bouton.Size = new System.Drawing.Size(100, 100);
            this.bouton.TabIndex = 13;
            this.bouton.Text = "Tuile";
            this.bouton.UseVisualStyleBackColor = false;
            this.bouton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownBouton);
            //this.bouton.MouseLeave += new System.EventHandler(this.mouseLeaveBouton);
            //this.bouton.MouseHover += new System.EventHandler(this.mouseHoverBouton);
            this.bouton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMoveBouton);
            this.bouton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpBouton);
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.bouton);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 450);
            this.panel1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Couleur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.boutonCouleur_Click);
            // 
            // boutonCharger
            // 
            this.boutonCharger.Location = new System.Drawing.Point(640, 306);
            this.boutonCharger.Name = "boutonCharger";
            this.boutonCharger.Size = new System.Drawing.Size(113, 35);
            this.boutonCharger.TabIndex = 15;
            this.boutonCharger.Text = "Charger";
            this.boutonCharger.UseVisualStyleBackColor = true;
            this.boutonCharger.Click += new System.EventHandler(this.boutonCharger_Click);
            // 
            // boutonSauvegarder
            // 
            this.boutonSauvegarder.Location = new System.Drawing.Point(640, 347);
            this.boutonSauvegarder.Name = "boutonSauvegarder";
            this.boutonSauvegarder.Size = new System.Drawing.Size(113, 35);
            this.boutonSauvegarder.TabIndex = 16;
            this.boutonSauvegarder.Text = "Sauvegarder";
            this.boutonSauvegarder.UseVisualStyleBackColor = true;
            this.boutonSauvegarder.Click += new System.EventHandler(this.boutonSauvergarder_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Fisheye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 488);
            this.Controls.Add(this.boutonSauvegarder);
            this.Controls.Add(this.boutonCharger);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zoneHauteur);
            this.Controls.Add(this.zoneLargeur);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoneNom);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.boutonAjouter);
            this.Name = "Fisheye";
            this.Text = "Fisheye";
            ((System.ComponentModel.ISupportInitialize)(this.zoneLargeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneHauteur)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boutonAjouter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox zoneNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown zoneLargeur;
        private System.Windows.Forms.NumericUpDown zoneHauteur;
        private System.Windows.Forms.Button bouton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button boutonCharger;
        private System.Windows.Forms.Button boutonSauvegarder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}

