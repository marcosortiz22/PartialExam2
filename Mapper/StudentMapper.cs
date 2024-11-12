using Entities;
using System.Data.SqlClient;

namespace Mapper;

public static class StudentMapper
{
    public static Dictionary<string, object> MapStudentToParameters(Student student)
    {
        return new Dictionary<string, object>
        {
            { "@StudentId", student.StudentId },
            { "@Name", student.Name },
            { "@BirthDate", student.BirthDate },
            { "@CourseId", student.Course.CourseId },
            { "@CurrentAverage", student.CurrentAverage }
        };
    }

    public static Dictionary<string, object> MapStudentIdToParameters(int studentId)
    {
        return new Dictionary<string, object>
        {
            { "@StudentId", studentId },
        };
    }

    public static Student MapReaderToStudent(SqlDataReader reader)
    {
        return new Student
        {
            StudentId = (int)reader["ID_ESTUDIANTE"],
            Name = reader["NOMBRE"].ToString(),
            BirthDate = (DateTime)reader["FECHA_NACIMIENTO"],
            CurrentAverage = (decimal)reader["PROMEDIO_ACTUAL"],
            Course = CourseMapper.MapReaderToCourse(reader)
        };
    }
}
