namespace FirstVoyage
{
    //Liskov's Substitution Principle - A child class of student can be used in the place of a parent student class
    //Kinda forced this one, we made Student abstract
    //Interface Segregation - Distance Student implements the WorkFromHome interface. It can be implemented elsewhere if needed
    //Dependency Inversion - Both Full Time and Distance students need access to the study from home methods, but their implementation
    //would be different. These concepts are hard to implement in such a basic app
    public class DistanceStudent : Student, IWorkFromHome
    {
        private string facilitator;

        public DistanceStudent(string id, string firstName, string lastName, bool enrolled, string facilitator) : 
            base(id, firstName, lastName, enrolled)
        {
            this.facilitator = facilitator;
        }

        public string Facilitator { get => facilitator; set => facilitator = value; }

        public void studyFromHome(){
            //do study from home things
        }

        public override int getLectureHours(){
            return 50;
        }
    }
}