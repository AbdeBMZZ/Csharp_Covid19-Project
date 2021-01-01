namespace Covid_19_WinForm
{
    partial class Form1
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
            this.suivre = new System.Windows.Forms.Button();
            this.ajouter = new System.Windows.Forms.Button();
            this.en_attente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // suivre
            // 
            this.suivre.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suivre.Location = new System.Drawing.Point(59, 118);
            this.suivre.Name = "suivre";
            this.suivre.Size = new System.Drawing.Size(150, 50);
            this.suivre.TabIndex = 0;
            this.suivre.Text = "Suivi les patients";
            this.suivre.UseVisualStyleBackColor = true;
            this.suivre.Click += new System.EventHandler(this.suivre_Click);
            // 
            // ajouter
            // 
            this.ajouter.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajouter.Location = new System.Drawing.Point(22, 41);
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(236, 50);
            this.ajouter.TabIndex = 1;
            this.ajouter.Text = "ajouter un citoyen pour passer le test";
            this.ajouter.UseVisualStyleBackColor = true;
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // en_attente
            // 
            this.en_attente.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.en_attente.Location = new System.Drawing.Point(59, 200);
            this.en_attente.Name = "en_attente";
            this.en_attente.Size = new System.Drawing.Size(150, 84);
            this.en_attente.TabIndex = 2;
            this.en_attente.Text = "les personnes qui ont passé le test";
            this.en_attente.UseVisualStyleBackColor = true;
            this.en_attente.Click += new System.EventHandler(this.en_attente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.en_attente);
            this.Controls.Add(this.ajouter);
            this.Controls.Add(this.suivre);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Covid Track";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button suivre;
        private System.Windows.Forms.Button ajouter;
        private System.Windows.Forms.Button en_attente;
    }
}

