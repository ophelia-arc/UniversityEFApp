using System;
using System.Data.Entity; 
using System.Linq;
using System.Windows.Forms;

namespace UniversityEFApp
{
    public partial class Form1 : Form
    {
        private int _selectedGradeId = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvGrades.ReadOnly = true;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrades.AllowUserToAddRows = false;

            LoadComboBoxes();
            LoadGrades();
        }

        private void LoadComboBoxes()
        {
            using (var db = new UniversityDBEntities())
            {
                var students = db.Students
                    .Select(s => new
                    {
                        s.StudentId,
                        FullName = s.FirstName + " " + s.LastName
                    })
                    .ToList();

                cmbStudent.DisplayMember = "FullName";
                cmbStudent.ValueMember = "StudentId";
                cmbStudent.DataSource = students;

                var courses = db.Courses
                    .Select(c => new
                    {
                        c.CourseId,
                        c.CourseName
                    })
                    .ToList();

                cmbCourse.DisplayMember = "CourseName";
                cmbCourse.ValueMember = "CourseId";
                cmbCourse.DataSource = courses;
            }
        }

        private void LoadGrades()
        {
            using (var db = new UniversityDBEntities())
            {
                var rows = db.Grades
                    .Select(g => new
                    {
                        g.GradeId,
                        Telebe = g.Student.FirstName + " " + g.Student.LastName,
                        Fenn = g.Cours.CourseName,
                        Qiymet = g.Score
                    })
                    .ToList();

                dgvGrades.DataSource = rows;

                if (dgvGrades.Columns["GradeId"] != null)
                    dgvGrades.Columns["GradeId"].Visible = false;
            }

            CalculateAverage();
        }

        private void CalculateAverage()
        {
            if (cmbStudent.SelectedValue == null || !(cmbStudent.SelectedValue is int studentId))
                return;

            using (var db = new UniversityDBEntities())
            {
                double? avg = db.Grades
                    .Where(g => g.StudentId == studentId)
                    .Average(g => (double?)g.Score);

                if (avg == null)
                    lblAverage.Text = "Qiymət yoxdur";
                else
                    lblAverage.Text = $"Orta bal: {avg:F2}";
            }
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAverage();
        }

        private void dgvGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvGrades.Rows[e.RowIndex];
            _selectedGradeId = Convert.ToInt32(row.Cells["GradeId"].Value);
            cmbStudent.Text = row.Cells["Telebe"].Value?.ToString();
            cmbCourse.Text = row.Cells["Fenn"].Value?.ToString();
            txtScore.Text = row.Cells["Qiymet"].Value?.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtScore.Text, out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Qiymət 0 ilə 100 arasında tam ədəd olmalıdır!");
                return;
            }

            using (var db = new UniversityDBEntities())
            {
                var grade = new Grade
                {
                    StudentId = (int)cmbStudent.SelectedValue,
                    CourseId = (int)cmbCourse.SelectedValue,
                    Score = score
                };

                db.Grades.Add(grade);
                db.SaveChanges();
            }

            txtScore.Clear();
            LoadGrades();
            MessageBox.Show("Qiymət əlavə olundu!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedGradeId == 0)
            {
                MessageBox.Show("Əvvəlcə cədvəldən yeniləmək istədiyiniz sətri seçin!");
                return;
            }

            if (!int.TryParse(txtScore.Text, out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Qiymət 0 ilə 100 arasında tam ədəd olmalıdır!");
                return;
            }

            using (var db = new UniversityDBEntities())
            {
                var grade = db.Grades.Find(_selectedGradeId);
                if (grade != null)
                {
                    grade.StudentId = (int)cmbStudent.SelectedValue;
                    grade.CourseId = (int)cmbCourse.SelectedValue;
                    grade.Score = score;

                    db.SaveChanges();
                }
            }

            _selectedGradeId = 0;
            txtScore.Clear();
            LoadGrades();
            MessageBox.Show("Qiymət yeniləndi!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedGradeId == 0)
            {
                MessageBox.Show("Əvvəlcə cədvəldən silmək istədiyiniz sətri seçin!");
                return;
            }

            var confirm = MessageBox.Show("Bu qiyməti silmək istədiyinizə əminsiniz?", "Təsdiq", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (var db = new UniversityDBEntities())
            {
                var grade = db.Grades.Find(_selectedGradeId);
                if (grade != null)
                {
                    db.Grades.Remove(grade);
                    db.SaveChanges();
                }
            }

            _selectedGradeId = 0;
            txtScore.Clear();
            LoadGrades();
            MessageBox.Show("Qiymət silindi!");
        }

        private void btnOpenCourses_Click(object sender, EventArgs e)
        {
            var frm = new CoursesForm();
            frm.ShowDialog();
            LoadComboBoxes(); 
        } 
    }
}