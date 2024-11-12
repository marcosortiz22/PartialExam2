using Entities;
using System.Data.SqlClient;

namespace Mapper;

public static class CourseMapper
{
    public static Course MapReaderToCourse(SqlDataReader reader)
    {
        return new Course
        {
            CourseId = Convert.ToInt32(reader["ID_CURSO"]),
            CourseName = reader["NOMBRE_CURSO"].ToString(),
            Teacher = reader["PROFESOR"].ToString(),
            Schedule = reader["HORARIO"].ToString()
        };
    }
}
