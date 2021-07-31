using System;
using System.Collections.Generic;
using Academy.Application.CourseAgg;
using Academy.Domain.Entities;
using Academy.Presentation.Controllers;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Academy.Presentation.Test.Unit.Tests
{
    public class CourseControllerTests
    {
        private readonly CourseController _controller;
        private readonly ICourseApplication _application;

        public CourseControllerTests()
        {
            _application = Substitute.For<ICourseApplication>();
            _controller = new CourseController(_application);
        }

        [Fact]
        public void Should_GetCourses_Action_Work_Properly()
        {
            //arrange
            _application.GetCourses().ReturnsForAnyArgs(new List<Course>());

            //act
            var actual = _controller.GetCourses();

            //assertion
            _application.Received().GetCourses();
            _application.GetCourses().Should().BeOfType(actual.GetType());
        }

        [Fact]
        public void Should_CreateCourse_Action_Work_Properly()
        {
            //arrange
            var course = SomeCreateCode();

            //act
            _controller.Create(course);

            //assertion
            _application.Received().Create(course);

        }

        [Fact]
        public void Should_EditCourse_Action_Work_Properly()
        {
            //arrange
            var course = SomeCreateCode();
            var courseId = _application.Create(course);
            var editCourse = SomeEditCode(courseId);

            //act
            _controller.Edit(editCourse);

            //assertion
            _application.Received().Edit(editCourse);
        }

        [Fact]
        public void Should_DeleteCourse_Action_Work_Properly()
        {
            //arrange
            var course = SomeCreateCode();
            var courseId = _application.Create(course);

            //act
            _controller.Delete(courseId);

            //assertion
            _application.Received().Delete(courseId);
        }

        private CreateCourseVM SomeCreateCode()
        {
            return new()
            {
                Name = Guid.NewGuid().ToString(),
                Instructor = "Hamid",
                IsOnline = true,
                Tuition = new Random().Next(100, 1000)
            };
        }

        private EditCourseVM SomeEditCode(long id)
        {
            return new()
            {
                Id = id,
                Name = Guid.NewGuid().ToString(),
                Instructor = "Hamid",
                IsOnline = true,
                Tuition = new Random().Next(100, 1000)
            };
        }
    }
}
