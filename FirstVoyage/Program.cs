using System;

namespace FirstVoyage
{
    class Program
    {
        static void Main(string[] args)
        {
            FullTimeStudent fts = new FullTimeStudent("19012817","Reuel","Tyler",true,"Home");
            System.Console.WriteLine(fts.getFirstName());
        }
    }
}
