using DAL.Helpers;
using Entities;
using Mapper;

namespace DAL;

public class StudentDao
{
    public StudentDao() 
    { 
    }
    public void AddStudent(Student student)
    {
        using (var connection = DataAccessHelper.GetConnection())
        {
            connection.Open();
            var query = "INSERT INTO ESTUDIANTE (NOMBRE, FECHA_NACIMIENTO, PROMEDIO_ACTUAL, ID_CURSO) VALUES (@Name, @BirthDate, @CurrentAverage, @CourseId)";
            var parameters = StudentMapper.MapStudentToParameters(student);
            using (var command = DataAccessHelper.GetCommand(query, connection, parameters))
            {
                command.ExecuteNonQuery();
            }
        }

    }

    public List<Student> GetAllStudents()
    {
        var students = new List<Student>();
        var query = "SELECT E.ID_ESTUDIANTE, E.NOMBRE, E.FECHA_NACIMIENTO, E.PROMEDIO_ACTUAL, " +
                            "C.ID_CURSO, C.NOMBRE_CURSO, C.PROFESOR, C.HORARIO " +
                    "FROM ESTUDIANTE E INNER JOIN CURSO C ON E.ID_CURSO = C.ID_CURSO";
        using (var connection = DataAccessHelper.GetConnection())
        {
            connection.Open();
            using (var command = DataAccessHelper.GetCommand(query, connection))
            {
                using (var reader = DataAccessHelper.GetDataReader(command))
                {
                    while (reader.Read())
                    {
                        var student = StudentMapper.MapReaderToStudent(reader);
                        students.Add(student);
                    }
                }
            }
        }

        return students;

    }

    public Student GetById(int studentId)
    {
        var student = new Student();
        var query = "SELECT E.ID_ESTUDIANTE, E.NOMBRE, E.FECHA_NACIMIENTO, E.PROMEDIO_ACTUAL, " +
                            "C.ID_CURSO, C.NOMBRE_CURSO, C.PROFESOR, C.HORARIO " +
                    "FROM ESTUDIANTE E INNER JOIN CURSO C ON E.ID_CURSO = C.ID_CURSO " +
                    "WHERE ID_ESTUDIANTE = @StudentId";
        using (var connection = DataAccessHelper.GetConnection())
        {
            connection.Open();
            var parameters = StudentMapper.MapStudentIdToParameters(studentId);
            using (var command = DataAccessHelper.GetCommand(query, connection, parameters))
            {
                using (var reader = DataAccessHelper.GetDataReader(command))
                {
                    if (reader.Read())
                    {
                        student = StudentMapper.MapReaderToStudent(reader);
                    }
                }
            }
        }
        return student;
    }

    public void Modify(Student student)
    {
        using (var connection = DataAccessHelper.GetConnection())
        {
            connection.Open();
            var query = "UPDATE ESTUDIANTE SET NOMBRE = @Name, FECHA_NACIMIENTO = @BirthDate, " +
                            "PROMEDIO_ACTUAL = @CurrentAverage, ID_CURSO = @CourseId " +
                                   "WHERE ID_ESTUDIANTE = @StudentId";
            var parameters = StudentMapper.MapStudentToParameters(student);
            using (var command = DataAccessHelper.GetCommand(query, connection, parameters))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteById(int studentId)
    {
        using (var connection = DataAccessHelper.GetConnection())
        {
            connection.Open();
            var query = "DELETE ESTUDIANTE WHERE ID_ESTUDIANTE = @StudentId";
            var parameters = StudentMapper.MapStudentIdToParameters(studentId);

            using (var command = DataAccessHelper.GetCommand(query, connection, parameters))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
