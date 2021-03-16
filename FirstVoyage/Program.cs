using System;

namespace FirstVoyage
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FullTimeStudent fts = new FullTimeStudent("19012817","Reuel","Tyler",true,"Home");
            FullTimeStudent fts1 = new FullTimeStudent("19012817","Reuel","Tyler",true,"Home");
            FullTimeStudent fts2 = new FullTimeStudent("19012817","Reuel","Tyler",true,"Home");
            FullTimeStudent fts3 = new FullTimeStudent("19012817","Reuel","Tyler",true,"Home");
            FullTimeStudent fts4 = new FullTimeStudent("19012817","Reuel","Tyler",true,"Home");
            FullTimeStudent fts5 = new FullTimeStudent("19012817","Reuel","Tyler",true,"Home");

            

            System.Console.WriteLine(fts.getFirstName());
        }
    }
}
