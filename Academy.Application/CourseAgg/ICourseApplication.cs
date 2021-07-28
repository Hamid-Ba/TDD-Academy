using System.Collections.Generic;
using Academy.Domain.Entities;

namespace Academy.Application.CourseAgg
{
    public interface ICourseApplication
    {
        void Create(CreateCourseVM command);
        void Edit(EditCourseVM command);
        void Delete(long id);
        List<Course> GetCourses();
    }
}