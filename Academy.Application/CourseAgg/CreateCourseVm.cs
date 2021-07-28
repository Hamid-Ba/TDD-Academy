namespace Academy.Application.CourseAgg
{
    public class CreateCourseVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public bool IsOnline { get; set; }
        public double Tuition { get; set; }
    }
}