namespace Course.api.Business.Entities
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
    }
}
