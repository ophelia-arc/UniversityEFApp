using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace UniversityEFApp
{
    public partial class CoursesForm : Form
    {
        private readonly CourseRepository _courseRepo = new CourseRepository();
        private int _selectedCourseId = 0;

        public CoursesForm()
        {
            InitializeComponent();
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            dgvCourses.ReadOnly = true;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.AllowUserToAddRows = false;

            cmbCourseSort.Items.AddRange(new object[]
            {
                "Ada görə",
                "Kreditə görə (Artan)",
                "Kreditə görə (Azalan)"
            });
            cmbCourseSort.SelectedIndex = 0;

            LoadCourses();
        }

        private void LoadCourses()
        {
            string sort = cmbCourseSort.SelectedItem?.ToString() ?? "Ada görə";

            var list = _courseRepo.GetAll(sort)
                .Select(c => new
                {
                    c.CourseId,
                    FennAdi = c.CourseName,
                    Kredit = c.Credits
                })
                .ToList();

            dgvCourses.DataSource = list;

            if (dgvCourses.Columns["CourseId"] != null)
                dgvCourses.Columns["CourseId"].Visible = false;

            lblCourseCount.Text = $"Ümumi fənn sayı: {_courseRepo.Count()}";
        }

        private void cmbCourseSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCourses.Rows[e.RowIndex];
            _selectedCourseId = Convert.ToInt32(row.Cells["CourseId"].Value);
            txtCourseName.Text = row.Cells["FennAdi"].Value?.ToString();
            txtCredits.Text = row.Cells["Kredit"].Value?.ToString();
        }

        private void btnCourseAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Fənn adını daxil edin!");
                return;
            }

            if (!int.TryParse(txtCredits.Text, out int credits) || credits <= 0)
            {
                MessageBox.Show("Kredit müsbət tam ədəd olmalıdır!");
                return;
            }

            _courseRepo.Add(new Cours
            {
                CourseName = txtCourseName.Text.Trim(),
                Credits = credits
            });

            txtCourseName.Clear();
            txtCredits.Clear();
            LoadCourses();
            MessageBox.Show("Fənn əlavə olundu!");
        }

        private void btnCourseUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == 0)
            {
                MessageBox.Show("Əvvəlcə cədvəldən fənn seçin!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCourseName.Text) || !int.TryParse(txtCredits.Text, out int credits) || credits <= 0)
            {
                MessageBox.Show("Fənn adını və krediti düzgün daxil edin!");
                return;
            }

            _courseRepo.Update(new Cours
            {
                CourseId = _selectedCourseId,
                CourseName = txtCourseName.Text.Trim(),
                Credits = credits
            });

            _selectedCourseId = 0;
            txtCourseName.Clear();
            txtCredits.Clear();
            LoadCourses();
            MessageBox.Show("Fənn yeniləndi!");
        }

        private void btnCourseDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == 0)
            {
                MessageBox.Show("Əvvəlcə silmək istədiyiniz fənni seçin!");
                return;
            }

            var confirm = MessageBox.Show("Bu fənni silmək istədiyinizə əminsiniz?", "Təsdiq", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _courseRepo.Delete(_selectedCourseId);
                _selectedCourseId = 0;
                txtCourseName.Clear();
                txtCredits.Clear();
                LoadCourses();
                MessageBox.Show("Fənn silindi!");
            }
            catch (DbUpdateException ex)
            {
                var sql = ex.InnerException?.InnerException as SqlException;
                if (sql != null && sql.Number == 547)
                {
                    MessageBox.Show("Bu fənnə aid tələbə qiymətləri mövcud olduğu üçün silinə bilməz!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Baza xətası: " + ex.Message);
                }
            }
        }
    }
}