using System;
using System.Data;
using Academy.Domain.Test.Unit.Builder;
using Academy.Infrastructure.Repository;
using Academy.Infrastructure.Test.Integration.SetupFixtures;
using FluentAssertions;
using Xunit;

namespace Academy.Infrastructure.Test.Integration.Tests
{
    public class CourseRepositoryTests : IClassFixture<RealDataBaseFixture>
    {
        private readonly CourseBuilder _builder;
        private readonly CourseRepository _repository;

        public CourseRepositoryTests(RealDataBaseFixture fixture)
        {
            _builder = new CourseBuilder();
            _repository = new CourseRepository(fixture.Context);
        }

        [Fact]
        public void Should_ReturnCoursesList()
        {
            //act
            var courses = _repository.GetCourses();

            //assertion
            courses.Should().HaveCountGreaterOrEqualTo(0);
        }

        [Fact]
        public void Should_CreateCourse_Work_Properly()
        {
            //arrange
            var course = _builder.WriteName("Onion1").Build();

            //act
            _repository.Create(course);

            //assertion
            _repository.GetCourses().Should().ContainEquivalentOf(course);
        }

        [Fact]
        public void Should_CreateCourse_And_Return_ItsId_Properly()
        {
            //arrange
            var course = _builder.WriteName("Onion2").Build();

            //act
            var id = _repository.Create(course);

            //assertion
            id.Should().Be(course.Id);
        }

        [Fact]
        public void Should_ThrowDuplicatedNameException_WhenCourse_WithPassing_Name_IsExist()
        {
            //arrange
            var course = _builder.WriteName("Git1").Build();
            _repository.Create(course);

            var duplicatedCourse = _builder.WriteName("Git1").Build();

            //act
            Action actual = () => _repository.Create(course);

            //assertion
            actual.Should().ThrowExactly<DuplicateNameException>();
        }

        [Theory]
        [InlineData("Git")]
        public void Should_GetCourse_ByName_Properly(string name)
        {
            //arrange
            var expectedCourse = _builder.WriteName(name).Build();
            _repository.Create(expectedCourse);

            //act
            var course = _repository.GetCourseBy(name);

            //assertion
            course.Should().BeEquivalentTo(expectedCourse);
        }

        [Fact]
        public void Should_DeleteCourse_Work_Properly()
        {
            //arrange
            var expectedCourse = _builder.WriteName("Test1").Build();
            _repository.Create(expectedCourse);

            //act
            _repository.Delete(expectedCourse);

            //assertion
            _repository.GetCourses().Should().NotContain(expectedCourse);
        }

        [Fact]
        public void Should_GetCourse_ById_Work_Properly()
        {
            //arrange
            var expectedCourse = _builder.WriteName("Test2").Build();
            _repository.Create(expectedCourse);

            //act
            var actual = _repository.GetCourseBy(expectedCourse.Id);

            //assertion
            actual.Should().Be(expectedCourse);
        }

        [Fact]
        public void Should_DeleteCourse_ById_Work_Properly()
        {
            //arrange
            var expectedCourse = _builder.WriteName("Test3").Build();
            _repository.Create(expectedCourse);

            //act
            _repository.Delete(expectedCourse.Id);

            //assertion
            _repository.GetCourseBy(expectedCourse.Id).Should().BeNull();
        }
    }

}