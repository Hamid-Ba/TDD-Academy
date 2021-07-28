namespace Academy.Infrastructure.Test.Unit
{
    //public class CourseRepositoryTests : IDisposable
    //{
    //    private readonly CourseBuilder _courseBuilder;
    //    private readonly CourseRepository _courseRepository;

    //    public CourseRepositoryTests()
    //    {
    //        _courseRepository = new();
    //        _courseBuilder = new();
    //    }

    //    [Fact]
    //    public void CreateCourse_Should_Properly_Work()
    //    {
    //        //arrange
    //        var courseToAdd = _courseBuilder.Build();

    //        //act
    //        // var courses = courseRepository.Create(courseToAdd);
    //        _courseRepository.Create(courseToAdd);

    //        //assert
    //        _courseRepository.GetCourses().Should().Contain(courseToAdd);
    //    }

    //    [Fact]
    //    public void GetCourses_Should_Properly_Work()
    //    {
    //        //arrange
    //        var courses = _courseRepository.GetCourses();

    //        //assert
    //        _courseRepository.GetCourses().Should().HaveCountGreaterOrEqualTo(0);
    //    }

    //    [Theory]
    //    [InlineData(4)]
    //    public void GetCourse_ById_Should_Properly_Work(long id)
    //    {
    //        //arrange
    //        var expectedCourse = _courseBuilder.WithId(id).Build();
    //        _courseRepository.Create(expectedCourse);

    //        //act
    //        var actual = _courseRepository.GetCourseBy(id);

    //        //assert
    //        _courseRepository.GetCourses().Should().Contain(actual);
    //    }

    //    [Theory]
    //    [InlineData("asp")]
    //    public void GetCourse_ByName_Should_Properly_Work(string name)
    //    {
    //        //arrange
    //        var expectedCourse = _courseBuilder.WriteName(name).Build();
    //        _courseRepository.Create(expectedCourse);

    //        //act
    //        var actual = _courseRepository.GetCourseBy(name);

    //        //assert
    //        _courseRepository.GetCourses().Should().Contain(actual);
    //    }

    //    [Theory]
    //    [InlineData(4,"asp")]
    //    public void GetCourse_ByIdAndName_Should_Properly_Work(long id,string name)
    //    {
    //        //arrange
    //        var expectedCourse = _courseBuilder.WithId(id).WriteName(name).Build();
    //        _courseRepository.Create(expectedCourse);

    //        //act
    //        var actual = _courseRepository.GetCourseBy(id,name);

    //        //assert
    //        _courseRepository.GetCourses().Should().Contain(actual);
    //    }

    //    [Theory]
    //    [InlineData(378126317863)]
    //    public void Should_ReturnNull_WhenThereIsNo_CourseWithPassedId(long passedId)
    //    {
    //        //act
    //        var course = _courseRepository.GetCourseBy(passedId);

    //        //assert
    //        course.Should().BeNull();
    //    }

    //    [Theory]
    //    [InlineData(1)]
    //    public void DeleteCourse_Should_Properly_Work_WhenIdPassed(long id)
    //    {
    //        //arrange
    //        var expected = _courseBuilder.WithId(id).Build();
    //        _courseRepository.Create(expected);

    //        //act
    //        var actual = _courseRepository.Delete(id);

    //        //assert
    //        actual.Should().BeTrue();
    //    }

    //    [Theory]
    //    [InlineData(1)]
    //    public void DeleteCourse_Should_Properly_Work_WhenCoursePassed(long id)
    //    {
    //        //arrange
    //        var expected = _courseBuilder.WithId(id).Build();
    //        _courseRepository.Create(expected);

    //        var course = _courseRepository.GetCourseBy(id);

    //        //act
    //        var actual = _courseRepository.Delete(course);

    //        //assert
    //        actual.Should().BeTrue();
    //    }

    //    public void Dispose()
    //    {
    //        //Tear Down
    //    }
    //}
}