namespace Entities;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal CurrentAverage { get; set; }
    public Course Course { get; set; }

    public string CourseName => Course.CourseName;
}
