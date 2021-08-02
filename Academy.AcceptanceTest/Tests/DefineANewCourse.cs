using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Academy.AcceptanceTest.Core;
using Academy.AcceptanceTest.Fixtures;
using Academy.AcceptanceTest.NetCoreHosting;
using Academy.Application.CourseAgg;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using RestSharp;
using TestStack.BDDfy;
using Xunit;

namespace Academy.AcceptanceTest.Tests
{
    [Story(AsA = "Acamdemy Manager", IWant = "To Define A Course", SoThat = "I Can Do It In Admin Panel")]
    public class DefineANewCourse : IClassFixture<HostBuilderFixture>
    {
        private CreateCourseVM _course;
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public DefineANewCourse()
        {
            _client = new RestClient(HostConstants.Endpoint);
            _request = new RestRequest("Course", DataFormat.Json);
        }

        [Fact]
        public void DefineACourse()
        {
            var course = SomeCreateCourse();

            this.Given(_ => _.IWantToCreateACourse(course), "Given I Want To Create A Course")
                .When(_ => _.IPressTheButton(), "When I Press The Button To Add")
                .Then(_ => _.TheCourseShouldBeAvailableOnList(), "Then The Course Should be Available On List")
                .BDDfy();
        }

        [Fact]
        public void AvoidToDefineAExistedCourse()
        {
            var course = SomeCreateCourse();

            this.Given(_ => _.IWantToCreateACourseThatHasBeenAlreadyCreated(course), "Given I Want To Create A Course That Has Been Already Created")
                .When(_ => _.IPressTheButton(), "When I Press The Button To Add")
                .Then(_ => _.TheCourseShouldNotAddToList(), "Then The Course Should Not Add To List")
                .BDDfy();
        }

        #region Steps

        private void IWantToCreateACourse(CreateCourseVM course) => _course = course;

        private void IPressTheButton() => _course.Id = PostTheCourse(_course);

        private void TheCourseShouldBeAvailableOnList() => _course.Id.Should().BeGreaterThan(0);

        private void IWantToCreateACourseThatHasBeenAlreadyCreated(CreateCourseVM course)
        {
            _course = course;
            PostTheCourse(course);
        }

        private void TheCourseShouldNotAddToList() => _course.Id.Should().Be(0);

        #endregion

        #region Useful Func

        private long PostTheCourse(CreateCourseVM course)
        {
            _request.AddJsonBody(_course);

            var result = _client.Post<long>(_request);

            return JsonConvert.DeserializeObject<long>(result.Content);
        }

        private CreateCourseVM SomeCreateCourse() => new()
        {
            Name = Guid.NewGuid().ToString(),
            Instructor = "Hamid",
            IsOnline = true,
            Tuition = 500
        };

        #endregion
    }
}
