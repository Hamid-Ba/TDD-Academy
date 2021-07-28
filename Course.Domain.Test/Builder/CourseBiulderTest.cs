namespace Academy.Domain.Test.Unit.Builder
{
    public class CourseBuilder
    { 
        long _id = 1;
        string _name = "Asp.Net Core 5";
        const bool _isOnline = true;
        double _tuition = 750000;
        private string _instructor = "Hamid";


        public CourseBuilder WithId(long id)
        {
            _id = id;
            return this;
        }


        public CourseBuilder WriteName(string name)
        {
            _name = name;
            return this;
        }

        public CourseBuilder WriteTuition(double tuition)
        {
            _tuition = tuition;
            return this;
        }

        public Academy.Domain.Entities.Course Build() => new Academy.Domain.Entities.Course(_id, _name, _isOnline, _tuition,_instructor);

    }
}