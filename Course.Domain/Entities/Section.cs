namespace Academy.Domain.Entities
{
    public class Section
    {
        public long Id { get; private set; }
        public long CourseId { get; private set; }
        public string Title { get; private set; }

        public Section(long id, long courseId, string title)
        {
            Id = id;
            CourseId = courseId;
            Title = title;
        }
    }
}