namespace Fisheye
{
    partial class ModifierTuile
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
            this.boutonCouleur = new System.Windows.Forms.Button();
            this.zoneHauteur = new System.Windows.Forms.NumericUpDown();
            this.zoneLargeur = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zoneNom = new System.Windows.Forms.TextBox();
            this.boutonAjouter = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.zoneHauteur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneLargeur)).BeginInit();
            this.SuspendLayout();
            // 
            // boutonCouleur
            // 
            this.boutonCouleur.Location = new System.Drawing.Point(69, 142);
            this.boutonCouleur.Name = "boutonCouleur";
            this.boutonCouleur.Size = new System.Drawing.Size(81, 25);
            this.boutonCouleur.TabIndex = 22;
            this.boutonCouleur.Text = "Couleur";
            this.boutonCouleur.UseVisualStyleBackColor = true;
            this.boutonCouleur.Click += new System.EventHandler(this.boutonCouleur_Click);
            // 
            // zoneHauteur
            // 
            this.zoneHauteur.Location = new System.Drawing.Point(121, 107);
            this.zoneHauteur.Name = "zoneHauteur";
            this.zoneHauteur.Size = new System.Drawing.Size(42, 20);
            this.zoneHauteur.TabIndex = 21;
            // 
            // zoneLargeur
            // 
            this.zoneLargeur.Location = new System.Drawing.Point(121, 75);
            this.zoneLargeur.Name = "zoneLargeur";
            this.zoneLargeur.Size = new System.Drawing.Size(42, 20);
            this.zoneLargeur.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Hauteur :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Largeur :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nom :";
            // 
            // zoneNom
            // 
            this.zoneNom.Location = new System.Drawing.Point(119, 34);
            this.zoneNom.Name = "zoneNom";
            this.zoneNom.Size = new System.Drawing.Size(101, 20);
            this.zoneNom.TabIndex = 16;
            // 
            // boutonAjouter
            // 
            this.boutonAjouter.Location = new System.Drawing.Point(88, 192);
            this.boutonAjouter.Name = "boutonAjouter";
            this.boutonAjouter.Size = new System.Drawing.Size(113, 35);
            this.boutonAjouter.TabIndex = 15;
            this.boutonAjouter.Text = "Modifier";
            this.boutonAjouter.UseVisualStyleBackColor = true;
            this.boutonAjouter.Click += new System.EventHandler(this.boutonAjouter_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 35);
            this.button1.TabIndex = 23;
            this.button1.Text = "Supprimer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.boutonSupprimer_Click);
            // 
            // ModifierTuile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.boutonCouleur);
            this.Controls.Add(this.zoneHauteur);
            this.Controls.Add(this.zoneLargeur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoneNom);
            this.Controls.Add(this.boutonAjouter);
            this.Name = "ModifierTuile";
            this.Text = "ModifierTuile";
            ((System.ComponentModel.ISupportInitialize)(this.zoneHauteur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneLargeur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boutonCouleur;
        private System.Windows.Forms.NumericUpDown zoneHauteur;
        private System.Windows.Forms.NumericUpDown zoneLargeur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zoneNom;
        private System.Windows.Forms.Button boutonAjouter;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
    }
}