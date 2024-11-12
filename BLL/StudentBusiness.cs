using DAL;
using Entities;
using System.Transactions;
namespace BLL;

public class StudentBusiness
{
    private readonly StudentDao _studentDao;
    private readonly List<Student> _studentMemoryList;

    public StudentBusiness()
    {
        _studentDao = new StudentDao();
        _studentMemoryList = new List<Student>();
    }

    public void AddSingleStudent(Student student)
    {
        ValidateStudent(student);
        student.CurrentAverage = 0;
        _studentDao.AddStudent(student);

    }

    public void AddStudentToMemoryList(Student student)
    {
        ValidateStudent(student);
        using (var trx = new TransactionScope())
        {
            student.CurrentAverage = 0;
            _studentMemoryList.Add(student);
            trx.Complete();
        }
    }

    public void ConfirmChanges()
    {
        using (var trx = new TransactionScope())
        {
            foreach (var student in _studentMemoryList)
            {
                ValidateStudent(student);
                _studentDao.AddStudent(student);
            }
            trx.Complete();
        }   
    }

    private void ValidateStudent(Student student)
    {
        if (student.Name.Length < 3)
            throw new Exception("El nombre del estudiante debe tener al menos 3 caracteres.");

        int age = DateTime.Today.Year - student.BirthDate.Year;
        if (student.BirthDate > DateTime.Today.AddYears(-age)) age--;

        if (age < 16 || age > 60)
            throw new Exception("La edad del estudiante debe estar entre 16 y 60 años.");

        if (student.CurrentAverage < 0 || student.CurrentAverage > 10)
            throw new Exception("El promedio debe estar entre 0 y 10.");
    }

    public List<Student> GetAllStudents()
    {
        return _studentDao.GetAllStudents();
    }

    public Student GetById(int studentId)
    {
        return _studentDao.GetById(studentId);
    }

    public void Modify(Student student)
    {
        ValidateStudent(student);
        using (var trx = new TransactionScope())
        {
            _studentDao.Modify(student);
            trx.Complete();
        }
    }

    public void DeleteById(int studentId)
    {
        using (var trx = new TransactionScope())
        {
            _studentDao.DeleteById(studentId);
            trx.Complete();
        }
    }
}

