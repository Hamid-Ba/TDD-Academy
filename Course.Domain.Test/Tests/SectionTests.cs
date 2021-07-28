using Academy.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Academy.Domain.Test.Unit.Tests
{
    public class SectionTests
    {
        [Fact]
        public void Constructor_ShouldInitializeModelProperly()
        {
            //Setup Fixture
            const long _id = 1;
            const long _courseId = 1;
            const string _title = "Basement";

            var section = new Section(_id, _courseId, _title);

            section.Id.Should().Be(_id);
            section.CourseId.Should().Be(_courseId);
            section.Title.Should().Be(_title);
        }
    }
}
