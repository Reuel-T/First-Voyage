namespace FirstVoyage
{
    //Open/Closed - This class can be extended (and is extended), but does not need to be modified 
    public class FullTimeStudent : Student, IWorkFromHome
    {
        private string campus;

        public FullTimeStudent(string id, string firstName, string lastName, bool enrolled, string campus) : base( id,  firstName,  lastName,  enrolled)
        {
            this.campus = campus;
        }

        public string Campus { get => campus; set => campus = value; }

        public void studyFromHome(){
            //Studies from home, but differently from Distance Student
        }

        public override int getLectureHours(){
            return 100;
        }
    }
}