using System;
using System.Collections.Generic;

namespace Academy.Domain.Entities
{
    public class Course
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public bool IsOnline { get; private set; }
        public double Tuition { get; private set; }
        public string Instructor { get; private set; }

        public List<Section> Sections { get; private set; }

        public Course(string name, bool isOnline, double tuition, string instructor)
        {
            GuardAgainstInvalidName(name);
            GuardAgainstInvalidTuition(tuition);

            Name = name;
            IsOnline = isOnline;
            Tuition = tuition;
            Instructor = instructor;
            Sections = new List<Section>();
        }

        private void GuardAgainstInvalidName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception();
        }

        private void GuardAgainstInvalidTuition(double tuition)
        {
            if (tuition <= 0) throw new Exception("Tuition Must Be Greater Than 0");
        }

        public void AddSection(Section section) => Sections.Add(section);

        public override bool Equals(object? obj)
        {
            var course = obj as Course;

            if (course is null) return false;

            return Id == course.Id;
        }
    }
}