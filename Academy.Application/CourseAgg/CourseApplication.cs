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
            if (command is null) throw new ArgumentNullException();

            if (_courseRepository.GetCourseBy(command.Name) != null) throw new DuplicateNameException();

            var course = new Course(command.Name, command.IsOnline, command.Tuition, command.Instructor);
            _courseRepository.Create(course);
        }

        public void Edit(EditCourseVM command)
        {
            if (_courseRepository.GetCourseBy(command.Id) is null) throw new ArgumentNullException();

            if (_courseRepository.GetCourses().Exists(c => c.Name == command.Name && c.Id != command.Id))
                throw new DuplicateNameException();

            _courseRepository.Delete(command.Id);
            var course = new Course(command.Name, command.IsOnline, command.Tuition, command.Instructor);
            _courseRepository.Create(course);
        }

        public void Delete(long id)
        {
            if (_courseRepository.GetCourseBy(id) is null) throw new ArgumentNullException();

            _courseRepository.Delete(id);
        }

        public List<Course> GetCourses() => _courseRepository.GetCourses();

    }
}