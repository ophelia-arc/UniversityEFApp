namespace UniversityEFApp
{
    partial class CoursesForm
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
            this.lblCName = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.btnCourseAdd = new System.Windows.Forms.Button();
            this.btnCourseUpdate = new System.Windows.Forms.Button();
            this.btnCourseDelete = new System.Windows.Forms.Button();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbCourseSort = new System.Windows.Forms.ComboBox();
            this.lblCourseCount = new System.Windows.Forms.Label();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(12, 9);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(51, 13);
            this.lblCName.TabIndex = 0;
            this.lblCName.Text = "Fənn adı:";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(69, 6);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(100, 20);
            this.txtCourseName.TabIndex = 1;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Location = new System.Drawing.Point(12, 42);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(37, 13);
            this.lblCredits.TabIndex = 2;
            this.lblCredits.Text = "Kredit:";
            // 
            // txtCredits
            // 
            this.txtCredits.Location = new System.Drawing.Point(69, 42);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(100, 20);
            this.txtCredits.TabIndex = 3;
            // 
            // btnCourseAdd
            // 
            this.btnCourseAdd.Location = new System.Drawing.Point(12, 78);
            this.btnCourseAdd.Name = "btnCourseAdd";
            this.btnCourseAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCourseAdd.TabIndex = 4;
            this.btnCourseAdd.Text = "Əlavə et";
            this.btnCourseAdd.UseVisualStyleBackColor = true;
            this.btnCourseAdd.Click += new System.EventHandler(this.btnCourseAdd_Click);
            // 
            // btnCourseUpdate
            // 
            this.btnCourseUpdate.Location = new System.Drawing.Point(93, 78);
            this.btnCourseUpdate.Name = "btnCourseUpdate";
            this.btnCourseUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCourseUpdate.TabIndex = 5;
            this.btnCourseUpdate.Text = "Yenilə";
            this.btnCourseUpdate.UseVisualStyleBackColor = true;
            this.btnCourseUpdate.Click += new System.EventHandler(this.btnCourseUpdate_Click);
            // 
            // btnCourseDelete
            // 
            this.btnCourseDelete.Location = new System.Drawing.Point(174, 78);
            this.btnCourseDelete.Name = "btnCourseDelete";
            this.btnCourseDelete.Size = new System.Drawing.Size(75, 23);
            this.btnCourseDelete.TabIndex = 6;
            this.btnCourseDelete.Text = "Sil";
            this.btnCourseDelete.UseVisualStyleBackColor = true;
            this.btnCourseDelete.Click += new System.EventHandler(this.btnCourseDelete_Click);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(12, 118);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(50, 13);
            this.lblSort.TabIndex = 7;
            this.lblSort.Text = "Sıralama:";
            // 
            // cmbCourseSort
            // 
            this.cmbCourseSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseSort.FormattingEnabled = true;
            this.cmbCourseSort.Location = new System.Drawing.Point(68, 115);
            this.cmbCourseSort.Name = "cmbCourseSort";
            this.cmbCourseSort.Size = new System.Drawing.Size(121, 21);
            this.cmbCourseSort.TabIndex = 8;
            this.cmbCourseSort.SelectedIndexChanged += new System.EventHandler(this.cmbCourseSort_SelectedIndexChanged);
            // 
            // lblCourseCount
            // 
            this.lblCourseCount.AutoSize = true;
            this.lblCourseCount.Location = new System.Drawing.Point(12, 153);
            this.lblCourseCount.Name = "lblCourseCount";
            this.lblCourseCount.Size = new System.Drawing.Size(96, 13);
            this.lblCourseCount.TabIndex = 9;
            this.lblCourseCount.Text = "Ümumi fənn sayı: 0";
            // 
            // dgvCourses
            // 
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(289, 6);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.Size = new System.Drawing.Size(292, 176);
            this.dgvCourses.TabIndex = 10;
            this.dgvCourses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellClick);
            // 
            // CoursesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.lblCourseCount);
            this.Controls.Add(this.cmbCourseSort);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.btnCourseDelete);
            this.Controls.Add(this.btnCourseUpdate);
            this.Controls.Add(this.btnCourseAdd);
            this.Controls.Add(this.txtCredits);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.lblCName);
            this.Name = "CoursesForm";
            this.Text = "CoursesForm";
            this.Load += new System.EventHandler(this.CoursesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.TextBox txtCredits;
        private System.Windows.Forms.Button btnCourseAdd;
        private System.Windows.Forms.Button btnCourseUpdate;
        private System.Windows.Forms.Button btnCourseDelete;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbCourseSort;
        private System.Windows.Forms.Label lblCourseCount;
        private System.Windows.Forms.DataGridView dgvCourses;
    }
}