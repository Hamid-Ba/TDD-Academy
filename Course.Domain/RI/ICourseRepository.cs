using System.Collections.Generic;
using Academy.Domain.Entities;

namespace Academy.Domain.RI
{
    public interface ICourseRepository
    {
        long Create(Course courseToAdd);
        List<Course> GetCourses();
        Course GetCourseBy(long id);
        bool Delete(Course expected);
        bool Delete(long id);
        Course GetCourseBy(string name);
        Course GetCourseBy(long id,string name);
    }
}
