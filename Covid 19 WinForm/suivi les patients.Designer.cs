namespace Covid_19_WinForm
{
    partial class suivi_les_patients
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
            this.en_quarantaine = new System.Windows.Forms.Button();
            this.en_reanimation_btn = new System.Windows.Forms.Button();
            this.gueris_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // en_quarantaine
            // 
            this.en_quarantaine.Location = new System.Drawing.Point(179, 13);
            this.en_quarantaine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.en_quarantaine.Name = "en_quarantaine";
            this.en_quarantaine.Size = new System.Drawing.Size(153, 56);
            this.en_quarantaine.TabIndex = 0;
            this.en_quarantaine.Text = "en quarantaine";
            this.en_quarantaine.UseVisualStyleBackColor = true;
            this.en_quarantaine.Click += new System.EventHandler(this.en_quarantaine_Click);
            // 
            // en_reanimation_btn
            // 
            this.en_reanimation_btn.Location = new System.Drawing.Point(377, 13);
            this.en_reanimation_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.en_reanimation_btn.Name = "en_reanimation_btn";
            this.en_reanimation_btn.Size = new System.Drawing.Size(153, 54);
            this.en_reanimation_btn.TabIndex = 1;
            this.en_reanimation_btn.Text = "en reanimation";
            this.en_reanimation_btn.UseVisualStyleBackColor = true;
            this.en_reanimation_btn.Click += new System.EventHandler(this.en_reanimation_btn_Click_1);
            // 
            // gueris_btn
            // 
            this.gueris_btn.Location = new System.Drawing.Point(576, 13);
            this.gueris_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gueris_btn.Name = "gueris_btn";
            this.gueris_btn.Size = new System.Drawing.Size(152, 54);
            this.gueris_btn.TabIndex = 2;
            this.gueris_btn.Text = "guéris";
            this.gueris_btn.UseVisualStyleBackColor = true;
            this.gueris_btn.Click += new System.EventHandler(this.gueris_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.Location = new System.Drawing.Point(108, 116);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(745, 294);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(103, 116);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(750, 222);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.Visible = false;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(103, 116);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(750, 284);
            this.dataGridView3.TabIndex = 5;
            this.dataGridView3.Visible = false;
            this.dataGridView3.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView3_CellFormatting);
            // 
            // suivi_les_patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 485);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gueris_btn);
            this.Controls.Add(this.en_reanimation_btn);
            this.Controls.Add(this.en_quarantaine);
            this.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "suivi_les_patients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "suivi_les_patients";
            this.Load += new System.EventHandler(this.suivi_les_patients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button en_quarantaine;
        private System.Windows.Forms.Button en_reanimation_btn;
        private System.Windows.Forms.Button gueris_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}