using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Specialized;
using System.Text;
using System;

namespace FirstVoyage
{
    class Program
    {
        static bool mainLoop = true;
        static void Main(string[] args)
        {            
            String greetResponse = String.Empty;

            //while exit condition
            while(!greetResponse.Equals("q"))
            {
                greet();
                greetResponse = Console.ReadLine();
                
                if(greetResponse.Equals("q"))
                {
                    System.Console.WriteLine("QUIT");
                }
                else if(greetResponse.Equals("a"))
                {
                    Console.Clear();
                    addStudents();
                        
                }else if(greetResponse.Equals("v"))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine(DataHolder.studentReport());
                    System.Console.WriteLine("\nPress Any Key to Return to the Main menu");
                    Console.ReadKey();
                }else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("INPUT NOT RECOGNIZED");
                    Console.ReadKey();
                }
                                
            }
            

        }

        static void greet(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("UNIVERSITY MANAGEMENT SYSTEM\n\n");
            System.Console.WriteLine("Would you like to:");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Add Students  [a]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("View Students [v]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Quit          [q]");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write(">>>    ");
        }

        static void addStudents(){
            string addResponse = String.Empty;
            
            while(!addResponse.Equals("n"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string studentType = String.Empty;
                while(!studentType.Equals("f") && !studentType.Equals("d"))
                {
                    if(studentType.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.WriteLine($"{studentType} is not a valid input");
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("\nSelect Student Type:");
                    System.Console.WriteLine("Full Time [f]");
                    System.Console.WriteLine("Distance  [d]");
                    System.Console.WriteLine(">>>    ");
                    studentType = Console.ReadLine();
                } 

                System.Console.Write("\n\nSTUDENT ID >>> ");
                string id = Console.ReadLine();
                System.Console.Write("FIRST NAME >>> ");
                string firstName = Console.ReadLine();
                System.Console.Write("LAST NAME  >>> ");
                string lastName = Console.ReadLine();

                switch (studentType)
                {
                    case "f":                 
                        System.Console.Write("CAMPUS     >>> ");
                        string campus = Console.ReadLine();

                        DataHolder.addStudent(new FullTimeStudent(id, firstName, lastName, true, campus));
                        System.Console.WriteLine($"\nFull Time Student with id:{id} added\n\n");
                        break;
                    case "d":
                        System.Console.Write("FACILITATOR >>> ");
                        string facilitator = Console.ReadLine();

                        DataHolder.addStudent(new DistanceStudent(id, firstName, lastName, true, facilitator));
                        System.Console.WriteLine($"\nPart Time Student with id:{id} added");
                        break;
                    default:
                        break;
                }

                System.Console.WriteLine("\n\nWould you like to add a student?[y/n]");
                addResponse = Console.ReadLine();
            }
        }

    }
}
