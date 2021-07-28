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
            var course = _builder.WriteName("Onion").WithId(0).Build();

            //act
            _repository.Create(course);

            //assertion
            _repository.GetCourses().Should().ContainEquivalentOf(course);
        }

        [Fact]
        public void Should_CreateCourse_And_Return_ItsId_Properly()
        {
            //arrange
            var course = _builder.WriteName("Onion").WithId(0).Build();

            //act
            var id = _repository.Create(course);

            //assertion
            id.Should().Be(course.Id);
        }

        [Fact]
        public void Should_ThrowDuplicatedNameException_WhenCourse_WithPassing_Name_IsExist()
        {
            //arrange
            var course = _builder.WriteName("Git").WithId(0).Build();
            _repository.Create(course);

            var duplicatedCourse = _builder.WriteName("Git").WithId(0).Build();

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
            var expectedCourse = _builder.WriteName("Git").WithId(0).Build();
            _repository.Create(expectedCourse);

            //act
            var course = _repository.GetCourseBy(name);

            //assertion
            course.Should().BeEquivalentTo(expectedCourse);
        }
    }
}