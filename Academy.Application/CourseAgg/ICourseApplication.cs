using System.Collections.Generic;
using Academy.Domain.Entities;

namespace Academy.Application.CourseAgg
{
    public interface ICourseApplication
    {
        long Create(CreateCourseVM command);
        long Edit(EditCourseVM command);
        bool Delete(long id);
        List<Course> GetCourses();
    }
}