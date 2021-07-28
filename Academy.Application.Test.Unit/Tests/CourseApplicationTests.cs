using System;
using System.Collections.Generic;
using System.Data;
using Academy.Application.CourseAgg;
using Academy.Domain.Entities;
using Academy.Domain.RI;
using Academy.Domain.Test.Unit.Builder;
using Academy.Infrastructure.Repository;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Academy.Application.Test.Unit.Tests
{
    public class CourseApplicationTests
    {
        private readonly CourseBuilder _courseBuilder;
        private readonly CourseApplication _courseApplication;
        private readonly ICourseRepository _courseRepository;

        //public CourseApplicationTests()
        //{
        //    _courseBuilder = new CourseBuilder();
        //    _courseRepository = Substitute.For<ICourseRepository, CourseRepository>();
        //    _courseApplication = new CourseApplication(_courseRepository);
        //}

        //[Fact]
        //public void CreateCourse_ShouldWork_Properly()
        //{
        //    //arrange
        //    var command = InitializeCreateCourseVm();

        //    //act
        //    _courseApplication.Create(command);

        //    //assertion
        //    _courseRepository.ReceivedWithAnyArgs().Create(Arg.Any<Course>());
        //}

        //[Fact]
        //public void CrateCourseVM_CanNotBeNull_When_Course_Is_Being_Created()
        //{
        //    //arrange
        //    CreateCourseVM command = null;

        //    //act
        //    Action actual = () => _courseApplication.Create(command);

        //    //assertion
        //    actual.Should().ThrowExactly<ArgumentNullException>();
        //}

        //[Fact]
        //public void Should_ThrowDuplicatedException_When_Passing_Name_IsExist()
        //{
        //    //arrange
        //    var command = InitializeCreateCourseVm();

        //    var course = _courseBuilder.Build();
        //    _courseRepository.GetCourseBy(Arg.Any<string>()).Returns(course);

        //    //act
        //    Action actual = () => _courseApplication.Create(command);

        //    //assert
        //    actual.Should().Throw<DuplicateNameException>();
        //}

        //[Fact]
        //public void EditCourse_ShouldWork_Properly()
        //{
        //    //arrange
        //    var command = InitializeEditCourseVm();
        //    var course = _courseBuilder.Build();
        //    _courseRepository.GetCourseBy(command.Id).Returns(course);
        //    _courseRepository.GetCourses().Returns(new List<Course>());

        //    //act
        //    _courseApplication.Edit(command);

        //    //assertion
        //    Received.InOrder(() =>
        //    {
        //        _courseRepository.Received().Delete(command.Id);
        //        _courseRepository.Received().Create(Arg.Any<Course>());
        //    });
        //}

        //[Fact]
        //public void Should_ThrownNullException_WhenCourse_NotExist_While_ItIsBeingModified()
        //{
        //    //arrange
        //    var command = InitializeEditCourseVm();
        //    _courseRepository.GetCourseBy(command.Id).ReturnsNull();
        //    _courseRepository.GetCourses().Returns(new List<Course>());

        //    //act
        //    Action action = () => _courseApplication.Edit(command);
        //    Action editAction = () => _courseApplication.Delete(command.Id);

        //    //assert
        //    action.Should().Throw<Exception>();
        //    editAction.Should().Throw<ArgumentNullException>();
        //}

        //[Fact]
        //public void Should_Passing_IdAndName_Be_Unique_While_IsIsBeingEdited()
        //{
        //    //arrange
        //    var command = InitializeEditCourseVm();
        //    var course = _courseBuilder.Build();
        //    _courseRepository.GetCourseBy(command.Id).Returns(course);
        //    _courseRepository.GetCourses().Returns(new List<Course>() { course });

        //    //act
        //    Action actual = () => _courseApplication.Edit(command);

        //    //assertion
        //    actual.Should().ThrowExactly<DuplicateNameException>();
        //}

        //[Fact]
        //public void DeleteCourse_Should_Work_Properly()
        //{
        //    //arrange
        //    var course = _courseBuilder.WithId(3).Build();
        //    _courseRepository.GetCourseBy(Arg.Any<long>()).Returns(course);

        //    //act
        //    _courseApplication.Delete(course.Id);

        //    //assertion
        //    _courseRepository.Received().Delete(Arg.Any<long>());
        //}

        //[Fact]
        //public void Getting_List_Of_Courses_Should_Properly_Work()
        //{
        //    //arrange
        //    _courseRepository.GetCourses().Returns(new List<Course>());

        //    //act
        //    _courseApplication.GetCourses();

        //    //assertion
        //    _courseRepository.Received().GetCourses();
        //}

        private static CreateCourseVM InitializeCreateCourseVm() =>
            new()
            {
                Id = 1,
                Name = "Asp.Net Core 5",
                Instructor = "Hamid",
                IsOnline = true,
                Tuition = 450000
            };

        private static EditCourseVM InitializeEditCourseVm() =>
            new()
            {
                Id = 2,
                Name = "Asp.Net Core 5",
                Instructor = "Hamid",
                IsOnline = true,
                Tuition = 450000
            };
    }
}