namespace SchoolApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int coef { get; set; }
        public DateTime date { get; set; }
        public string TeacheName { get; set;} 
    }
}
