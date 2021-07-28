using Academy.Domain.Entities;

namespace Academy.Domain.Test.Unit.Factories
{
    public class SectionFactory
    {
        const long _id = 1;
        const long _courseId = 1;
        const string _title = "Basement";

        public static Section Create() => new Section(_id, _courseId, _title);
    }
}