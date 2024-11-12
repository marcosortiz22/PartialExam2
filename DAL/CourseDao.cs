using DAL.Helpers;
using Entities;
using Mapper;

namespace DAL;

public class CourseDao
{
    public CourseDao() { }
    public List<Course> GetAllCourses()
    {
        var courses = new List<Course>();
        var query = "SELECT ID_CURSO, NOMBRE_CURSO, PROFESOR, HORARIO FROM CURSO";
        using (var connection = DataAccessHelper.GetConnection())
        {
            connection.Open();
            using (var command = DataAccessHelper.GetCommand(query, connection))
            {
                using (var reader = DataAccessHelper.GetDataReader(command))
                {
                    while (reader.Read())
                    {
                        var course = CourseMapper.MapReaderToCourse(reader);
                        courses.Add(course);
                    }
                }
            }
        }

        return courses;
    }
}
