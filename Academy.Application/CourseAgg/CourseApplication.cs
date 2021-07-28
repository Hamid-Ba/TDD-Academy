using System;
using System.Collections.Generic;
using System.Data;
using Academy.Domain.Entities;
using Academy.Domain.RI;

namespace Academy.Application.CourseAgg
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courseRepository;

        public CourseApplication(ICourseRepository courseRepository) => _courseRepository = courseRepository;


        public void Create(CreateCourseVM command)
        {
            throw new NotImplementedException();
        }

        public void Edit(EditCourseVM command)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}