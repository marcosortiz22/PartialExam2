using BLL;
using Entities;
using System.Xml.Linq;

namespace UI
{
    public partial class MainForm : Form
    {
        private StudentBusiness _studentBusiness;
        private CourseBusiness _courseBusiness;
        private List<Student> _students = new List<Student>();
        private Student _student;

        public MainForm()
        {
            InitializeComponent();
            _studentBusiness = new StudentBusiness();
            _courseBusiness = new CourseBusiness();
            InitializeDgvStudentList();
            LoadCourses();
        }

        private void InitializeDgvStudentList()
        {
            dgvStudentList.DataSource = _studentBusiness.GetAllStudents();
            dgvStudentList.Columns[nameof(Student.StudentId)].HeaderText = "Id";
            dgvStudentList.Columns[nameof(Student.Name)].HeaderText = "Nombre";
            dgvStudentList.Columns[nameof(Student.Course)].Visible = false;
            dgvStudentList.Columns[nameof(Student.CurrentAverage)].HeaderText = "Promedio";
            dgvStudentList.Columns[nameof(Student.BirthDate)].HeaderText = "Fecha Nacimiento";
            dgvStudentList.Columns[nameof(Student.BirthDate)].Width = 180;
            dgvStudentList.Columns[nameof(Student.CourseName)].HeaderText = "Curso";
            dgvStudentList.Columns[nameof(Student.CourseName)].Width = 250;
        }

        private void LoadCourses()
        {
            cmbCourse.DataSource = _courseBusiness.GetAllCourses();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseId";
        }

        private void btnAddSingleStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var student = GetStudentFromForm();
                _studentBusiness.AddSingleStudent(student);
                MessageBox.Show("Estudiante cargado con éxito.");
                InitializeDgvStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAddToMemoryList_Click(object sender, EventArgs e)
        {
            try
            {
                var student = GetStudentFromForm();
                _studentBusiness.AddStudentToMemoryList(student);
                _students.Add(student);
                MessageBox.Show("Estudiante agregado a la lista en memoria.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnConfirmChanges_Click(object sender, EventArgs e)
        {
            try
            {
                _studentBusiness.ConfirmChanges();
                MessageBox.Show("Todos los estudiantes en la lista fueron guardados con éxito.");
                InitializeDgvStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar estudiantes: " + ex.Message);
            }
        }

        // Método auxiliar para obtener datos del estudiante desde el formulario
        private Student GetStudentFromForm()
        {
            return new Student
            {
                Name = txtName.Text,
                BirthDate = dtpBirthDate.Value,
                CurrentAverage = decimal.Parse(txtCurrentAverage.Text),
                Course = (cmbCourse.SelectedItem as Course)
            };
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            var studentIdTxt = txtStudentId.Text;
            if (studentIdTxt == null || studentIdTxt.Length == 0)
            {
                MessageBox.Show("Debe proporcionar un Id de estudiante");
                return;
            }

            int studentId;
            if (int.TryParse(studentIdTxt, out studentId))
            {
                var student = _studentBusiness.GetById(studentId);
                if (student == null || student.StudentId == 0)
                {
                    MessageBox.Show("Estudiante no encontrado.");
                    return;
                }
                btnModifyStudent.Enabled = true;
                btnDeleteStudent.Enabled = true;
                txtStudentId.Enabled = false;
                _student = student;
                txtName.Text = student.Name;
                txtCurrentAverage.Text = student.CurrentAverage.ToString();
                dtpBirthDate.Value = student.BirthDate;
                cmbCourse.SelectedValue = student.Course.CourseId;
            }
            else
            {
                MessageBox.Show("Formato de id de estudiante no válido.");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnModifyStudent.Enabled = false;
            btnDeleteStudent.Enabled = false;
            txtStudentId.Enabled = true;
        }

        private void btnModifyStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var student = GetStudentFromForm();
                student.StudentId = _student.StudentId;
                _studentBusiness.Modify(student);
                MessageBox.Show("Estudiante modifcado con éxito.");
                InitializeDgvStudentList();
                btnCancel_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                _studentBusiness.DeleteById(_student.StudentId);
                MessageBox.Show("Estudiante modifcado con éxito.");
                InitializeDgvStudentList();
                btnCancel_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

}
