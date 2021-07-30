namespace Academy.Domain.Test.Unit.Builder
{
    public class CourseBuilder
    { 
        string _name = "Test";
        const bool _isOnline = true;
        double _tuition = 750000;
        private string _instructor = "Hamid";

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

        public Academy.Domain.Entities.Course Build() => new Academy.Domain.Entities.Course(_name, _isOnline, _tuition,_instructor);

    }
}