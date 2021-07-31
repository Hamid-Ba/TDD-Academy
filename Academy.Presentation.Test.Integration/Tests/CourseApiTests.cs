using System;
using System.Collections.Generic;
using Academy.Application.CourseAgg;
using Academy.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using Xunit;

namespace Academy.Presentation.Test.Integration.Tests
{
    public class CourseApiTests
    {
        const string Url = "https://localhost:5001/api/course";
        private readonly RESTFulApiFactoryClient _httpRequest;

        public CourseApiTests()
        {
            var factory = new WebApplicationFactory<Startup>();
            var httpClient = factory.CreateClient();
            _httpRequest = new(httpClient);
        }

        [Fact]
        public async void Should_GetCourses_Api_Work_Properly()
        {
            //act
            var actual = await _httpRequest.GetContentAsync<List<Course>>(Url);

            //assertion
            actual.Should().HaveCountGreaterOrEqualTo(0);
        }

        [Fact]
        public async void Should_CreateCourse_Api_Work_Properly()
        {
            //arrange
            var course = SomeCreateCode();

            //act
            var actual = await _httpRequest.PostContentAsync<CreateCourseVM, long>(Url, course);

            var courses = await _httpRequest.GetContentAsync<List<Course>>(Url);

            //assertion
            actual.Should().BeGreaterThan(0);
            //courses.Should().ContainSingle(c => c.Id == actual);

            //teardown
            await _httpRequest.DeleteContentAsync($"{Url}/{actual}");
        }

        [Fact]
        public async void Should_EditCourse_Api_Work_Properly()
        {
            //arrange
            var course = SomeCreateCode();
            var courseId = await _httpRequest.PostContentAsync<CreateCourseVM, long>(Url, course);
            var expectedCourse = SomeEditCode(courseId);

            //act
            var actual = await _httpRequest.PutContentAsync<EditCourseVM, long>(Url, expectedCourse);

            //assertion
            actual.Should().NotBe(courseId).And.BeGreaterThan(courseId);

            //teardown
            await _httpRequest.DeleteContentAsync($"{Url}/{actual}");
        }

        [Fact]
        public async void Should_DeleteCourse_Api_Work_Properly()
        {
            //arrange
            var course = SomeCreateCode();
            var courseId = await _httpRequest.PostContentAsync<CreateCourseVM, long>(Url, course);

            //act
            var actual = await _httpRequest.DeleteContentAsync<bool>($"{Url}/{courseId}");

            //assertion
            actual.Should().BeTrue();
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
                Instructor = "Khosro",
                IsOnline = true,
                Tuition = new Random().Next(100, 1000)
            };
        }
    }
}