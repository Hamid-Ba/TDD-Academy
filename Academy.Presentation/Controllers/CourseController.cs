using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Academy.Application.CourseAgg;
using Academy.Domain.Entities;

namespace Academy.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseApplication _courseApplication;

        public CourseController(ICourseApplication courseApplication) => _courseApplication = courseApplication;

        [HttpGet]
        public List<Course> GetCourses() => _courseApplication.GetCourses();

        [HttpPost]
        public void Create(CreateCourseVM course)
        {
            _courseApplication.Create(course);
        }

        [HttpPut]
        public void Edit(EditCourseVM course)
        {
            _courseApplication.Edit(course);
        }

        [HttpDelete]
        public void Delete(long courseId)
        {
            _courseApplication.Delete(courseId);
        }
    }
}