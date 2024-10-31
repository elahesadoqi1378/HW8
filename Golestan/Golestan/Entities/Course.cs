namespace Golestan.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Student> Students { get; set; } = new List<Student>();
        public int Capacity { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Course(string name,int unit,int capacity, DayOfWeek day,TimeOnly starttime, TimeOnly endtime)
        {
            Name = name;
            Unit = unit;
            Capacity = capacity;
            Day = day;
            StartTime = starttime;
            EndTime = endtime;
        }
        public override string ToString()
        {
            return $"{Name} - Capacuty: {Capacity} - Unit: {Unit} -  CourseId: {Id}, Day of week: {Day}, StartTime : {StartTime}, End time : {EndTime}";
        }
    }
}
