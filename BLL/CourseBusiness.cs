using DAL;
using Entities;

namespace BLL;

public class CourseBusiness
{
    private CourseDao _courseDao;
    public CourseBusiness() 
    {
        _courseDao = new CourseDao();
    }

    public List<Course> GetAllCourses()
    {
        return _courseDao.GetAllCourses();
    }
}
