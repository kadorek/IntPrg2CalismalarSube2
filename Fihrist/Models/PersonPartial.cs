namespace Fihrist.Models
{
    public partial class Person
    {
        public string Fullname
        {
            get
            {
                return $"{Name} {Lastname}";
            }
        }
    }
}
