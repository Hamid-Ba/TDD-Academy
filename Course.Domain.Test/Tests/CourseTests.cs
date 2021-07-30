using System;
using Academy.Domain.Test.Unit.Builder;
using Academy.Domain.Test.Unit.Factories;
using FluentAssertions;
using Xunit;

namespace Academy.Domain.Test.Unit.Tests
{
    public class CourseTests : IDisposable
    {
        private readonly CourseBuilder _courseBuilder;

        public CourseTests() => _courseBuilder = new CourseBuilder();

        [Fact]
        public void Constructor_ShouldInitializeModelProperly()
        {
            const string _name = "Asp.Net Core 5";
            const bool _isOnline = true;
            const double _tuition = 750000;
            const string _instructor = "Hamid";

            var course = new Academy.Domain.Entities.Course(_name, _isOnline, _tuition, _instructor);

            course.Name.Should().Be(_name);
        }

        [Fact]
        public void Constructor_ShouldThrowException_For_WrongFormat_Data()
        {
            Action Course = () => _courseBuilder.WriteName("Asp Net Core5").WriteTuition(0).Build();

            Course.Should().Throw<Exception>();

            //Assert.Throws<Exception>((Action)Course);
        }

        [Fact]
        public void AddSection_ToSpecifyCourse()
        {
            var section = SectionFactory.Create();

            var course =  _courseBuilder.Build();
            
            course.AddSection(section);

            course.Sections.Should().BeEquivalentTo(section);
        }

        //[Theory]
        //[InlineData(1)]
        //public void Courses_ShouldBeEqual_ByEqualId(long sameId)
        //{
        //    //Arrange
        //    var course1 = _courseBuilder.Build();
        //    var course2 = _courseBuilder.Build();

        //    //Act
        //    var actual = course1.Equals(course2);

        //    //Assert
        //    actual.Should().BeTrue();
        //}

        public void Dispose()
        {
        }
    }
}