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
        public long Create(CreateCourseVM course) => _courseApplication.Create(course);

        [HttpPut]
        public long Edit(EditCourseVM course) => _courseApplication.Edit(course);

        [HttpDelete("{courseId}")]
        public bool Delete(long courseId) => _courseApplication.Delete(courseId);
    }
}