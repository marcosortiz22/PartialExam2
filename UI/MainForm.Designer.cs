namespace UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Limpia los recursos que se están usando.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            lblName = new Label();
            labelBirthDate = new Label();
            labelCurrentAverage = new Label();
            labelCourse = new Label();
            txtName = new TextBox();
            txtCurrentAverage = new TextBox();
            cmbCourse = new ComboBox();
            btnAddSingleStudent = new Button();
            btnAddToList = new Button();
            btnConfirmChanges = new Button();
            dgvStudentList = new DataGridView();
            dtpBirthDate = new DateTimePicker();
            txtStudentId = new TextBox();
            lblStudentId = new Label();
            btnSearchStudent = new Button();
            btnModifyStudent = new Button();
            btnDeleteStudent = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudentList).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(30, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre:";
            // 
            // labelBirthDate
            // 
            labelBirthDate.Location = new Point(30, 70);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(164, 23);
            labelBirthDate.TabIndex = 2;
            labelBirthDate.Text = "Fecha de nacimiento:";
            // 
            // labelCurrentAverage
            // 
            labelCurrentAverage.Location = new Point(30, 110);
            labelCurrentAverage.Name = "labelCurrentAverage";
            labelCurrentAverage.Size = new Size(124, 23);
            labelCurrentAverage.TabIndex = 4;
            labelCurrentAverage.Text = "Promedio actual:";
            // 
            // labelCourse
            // 
            labelCourse.Location = new Point(30, 150);
            labelCourse.Name = "labelCourse";
            labelCourse.Size = new Size(100, 23);
            labelCourse.TabIndex = 6;
            labelCourse.Text = "Curso:";
            // 
            // txtName
            // 
            txtName.Location = new Point(191, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(192, 27);
            txtName.TabIndex = 1;
            // 
            // txtCurrentAverage
            // 
            txtCurrentAverage.Location = new Point(191, 110);
            txtCurrentAverage.Name = "txtCurrentAverage";
            txtCurrentAverage.Size = new Size(192, 27);
            txtCurrentAverage.TabIndex = 5;
            // 
            // cmbCourse
            // 
            cmbCourse.Location = new Point(191, 150);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(192, 28);
            cmbCourse.TabIndex = 7;
            // 
            // btnAddSingleStudent
            // 
            btnAddSingleStudent.Location = new Point(30, 200);
            btnAddSingleStudent.Name = "btnAddSingleStudent";
            btnAddSingleStudent.Size = new Size(150, 30);
            btnAddSingleStudent.TabIndex = 8;
            btnAddSingleStudent.Text = "Agregar un solo estudiante";
            btnAddSingleStudent.Click += btnAddSingleStudent_Click;
            // 
            // btnAddToList
            // 
            btnAddToList.Location = new Point(233, 200);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(150, 30);
            btnAddToList.TabIndex = 9;
            btnAddToList.Text = "Agregar a la lista";
            btnAddToList.Click += btnAddToMemoryList_Click;
            // 
            // btnConfirmChanges
            // 
            btnConfirmChanges.Location = new Point(121, 251);
            btnConfirmChanges.Name = "btnConfirmChanges";
            btnConfirmChanges.Size = new Size(150, 30);
            btnConfirmChanges.TabIndex = 10;
            btnConfirmChanges.Text = "Confirmar cambios";
            btnConfirmChanges.Click += btnConfirmChanges_Click;
            // 
            // dgvStudentList
            // 
            dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentList.Location = new Point(398, 30);
            dgvStudentList.Name = "dgvStudentList";
            dgvStudentList.RowHeadersWidth = 51;
            dgvStudentList.Size = new Size(877, 218);
            dgvStudentList.TabIndex = 11;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.Location = new Point(191, 70);
            dtpBirthDate.MaxDate = new DateTime(2008, 11, 11, 0, 0, 0, 0);
            dtpBirthDate.MinDate = new DateTime(1964, 11, 11, 0, 0, 0, 0);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(192, 27);
            dtpBirthDate.TabIndex = 3;
            dtpBirthDate.Value = new DateTime(2008, 11, 11, 0, 0, 0, 0);
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(607, 254);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(153, 27);
            txtStudentId.TabIndex = 12;
            // 
            // lblStudentId
            // 
            lblStudentId.Location = new Point(399, 258);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(202, 23);
            lblStudentId.TabIndex = 13;
            lblStudentId.Text = "Id Para Modificar o Eliminar:";
            // 
            // btnSearchStudent
            // 
            btnSearchStudent.Location = new Point(821, 254);
            btnSearchStudent.Name = "btnSearchStudent";
            btnSearchStudent.Size = new Size(150, 30);
            btnSearchStudent.TabIndex = 14;
            btnSearchStudent.Text = "Buscar Estudiante";
            btnSearchStudent.Click += btnSearchStudent_Click;
            // 
            // btnModifyStudent
            // 
            btnModifyStudent.Enabled = false;
            btnModifyStudent.Location = new Point(399, 294);
            btnModifyStudent.Name = "btnModifyStudent";
            btnModifyStudent.Size = new Size(157, 30);
            btnModifyStudent.TabIndex = 15;
            btnModifyStudent.Text = "Modificar Estudiante";
            btnModifyStudent.Click += btnModifyStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Enabled = false;
            btnDeleteStudent.Location = new Point(607, 294);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(153, 30);
            btnDeleteStudent.TabIndex = 16;
            btnDeleteStudent.Text = "Eliminar Estudiante";
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(821, 294);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 30);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancelar";
            btnCancel.Click += btnCancel_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1287, 336);
            Controls.Add(btnCancel);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnModifyStudent);
            Controls.Add(btnSearchStudent);
            Controls.Add(lblStudentId);
            Controls.Add(txtStudentId);
            Controls.Add(dgvStudentList);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(labelBirthDate);
            Controls.Add(dtpBirthDate);
            Controls.Add(labelCurrentAverage);
            Controls.Add(txtCurrentAverage);
            Controls.Add(labelCourse);
            Controls.Add(cmbCourse);
            Controls.Add(btnAddSingleStudent);
            Controls.Add(btnAddToList);
            Controls.Add(btnConfirmChanges);
            Name = "MainForm";
            Text = "Formulario de estudiantes";
            ((System.ComponentModel.ISupportInitialize)dgvStudentList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Form controls
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.Label labelCurrentAverage;
        private System.Windows.Forms.Label labelCourse;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCurrentAverage;
        private System.Windows.Forms.ComboBox cmbCourse;

        private System.Windows.Forms.Button btnAddSingleStudent;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnConfirmChanges;
        private DataGridView dgvStudentList;
        private DateTimePicker dtpBirthDate;
        private TextBox txtStudentId;
        private Label lblStudentId;
        private Button btnSearchStudent;
        private Button btnModifyStudent;
        private Button btnDeleteStudent;
        private Button btnCancel;
    }
}
