namespace Web1.Models
{
    public class MockData
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student{Id=1,Name="Ali" },
            new Student{Id=2,Name="Veli" },
            new Student{Id=3,Name="Ayşe" },
            new Student{Id=4,Name="Fatma" },
            new Student{Id=5,Name="Ahmet" }
        };

        public static List<Course> Courses { get; set; } = new List<Course>()
        {
            new Course{ Id=1,Name="Matematik" },
            new Course{ Id=2,Name="Fizik" },
            new Course{ Id=3,Name="Kimya" },
            new Course{ Id=4,Name="Biyoloji" },
            new Course{ Id=5,Name="Türkçe" }
        };
    }
}
