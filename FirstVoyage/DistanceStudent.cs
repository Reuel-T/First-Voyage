namespace FirstVoyage
{
    //Liskov's Something Principle - A child class of student can be used in the place of a student class
    public class DistanceStudent : Student
    {
        private string facilitator;

        public DistanceStudent(string id, string firstName, string lastName, bool enrolled, string facilitator) : base(id, firstName, lastName, enrolled)
        {
            this.facilitator = facilitator;
        }

        public string Facilitator { get => facilitator; set => facilitator = value; }
    }
}