using System.Collections.Generic;
using System.Data;
using System.Linq;
using Academy.Domain.Entities;
using Academy.Domain.RI;
using Academy.Infrastructure.Context;

namespace Academy.Infrastructure.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademyContext _context;

        public CourseRepository(AcademyContext context) => _context = context;
         
        public long Create(Course courseToAdd)
        {
            if (_context.Courses.Any(c => c.Name == courseToAdd.Name))
                throw new DuplicateNameException();

            _context.Add(courseToAdd);
            _context.SaveChanges();
            return courseToAdd.Id;
        }

        public List<Course> GetCourses() => _context.Courses.ToList();

        public Course GetCourseBy(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Course expected)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Course GetCourseBy(string name) => _context.Courses.FirstOrDefault(c => c.Name == name);

        public Course GetCourseBy(long id, string name)
        {
            throw new System.NotImplementedException();
        }
    }
}