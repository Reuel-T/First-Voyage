namespace FirstVoyage
{
    //Single Responsibility - This has everything to do with a student, and nothing else
    //Open/Closed - This class can be extended (and is extended), but does not need to be modified 
    public class FullTimeStudent : Student
    {
        private string campus;

        public FullTimeStudent(string id, string firstName, string lastName, bool enrolled, string campus) : base( id,  firstName,  lastName,  enrolled)
        {
            this.campus = campus;
        }

        public string Campus { get => campus; set => campus = value; }
    }
}