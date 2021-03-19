using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Specialized;
using System.Text;
using System;

namespace FirstVoyage
{
    class Program
    {
        //arrays to hold the various menu choices
        static string[] mainMenuChoices = {"Add Students", "View Students", "Quit"};
        static string[] studentMenuChoices = {"Full Time", "Distance", "Back"};
        static string[] booleanChoice = {"No", "Yes"};

        static string filename = "records.txt";

        //menu choice colors - because I'm extra
        static ConsoleColor[] mainMenuChoiceColors = {ConsoleColor.Green,ConsoleColor.Cyan, ConsoleColor.Yellow};

        static void Main(string[] args)
        {            
            FileWorker fw = new FileWorker(filename);
            ListHolder.setStudents(fw.readFile());
            titleScreen();
            mainMenu();
        }

        //main menu logic
        static void mainMenu()
        {
            int selection = 0;
            
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();

                mainMenuTitle();

                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("Use the Arrow Keys to pick an option");

                for (int i = 0; i < mainMenuChoices.Length; i++)
                {
                    Console.ForegroundColor = mainMenuChoiceColors[i];
                    if (selection == i)
                    {
                        System.Console.Write(mainMenuChoices[i].PadRight(35));
                        System.Console.WriteLine("<<");
                    }
                    else
                    {
                        System.Console.WriteLine(mainMenuChoices[i]);    
                    }
                }

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    selection++;
                    if (selection > mainMenuChoices.Length - 1) 
                    {
                        selection = 0;
                    }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = mainMenuChoices.Length - 1;
                    } 
                }
            } while (key.KeyChar != 13);

            switch (selection)
            {
                case 0:
                    addStudentMenu();
                    break;
                case 1:
                    viewStudents();
                    break;
                case 2:
                    Console.ResetColor();
                    Console.Clear();
                    break;
                default:
                    break;
            } 
        }

        static void addStudentMenu()
        {
            int selection = 0;
            
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("Use the Arrow Keys to pick an option");

                for (int i = 0; i < studentMenuChoices.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (selection == i)
                    {
                        System.Console.Write(studentMenuChoices[i].PadRight(35));
                        System.Console.WriteLine("<<");
                    }
                    else
                    {
                        System.Console.WriteLine(studentMenuChoices[i]);    
                    }
                }

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    selection++;
                    if (selection > studentMenuChoices.Length - 1) 
                    {
                        selection = 0;
                    }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = studentMenuChoices.Length - 1;
                    } 
                }


            } while (key.KeyChar != 13);

            if (selection != 2)
            {
                addStudent(selection);
            }
            else
            {
                mainMenu();
            }
        }

        //Displays the Title Screen
        static void titleScreen()
        {
            Console.Clear();
            int lineCount = 0;
            foreach (string item in TitleStringHolder.lines)
            {
                switch (lineCount)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 12:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 18:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    default:
                        break;
                }
                lineCount++;

                System.Console.WriteLine($"{item}");
            }

            Console.ReadKey();
        }

        //displays the main menu title
        static void mainMenuTitle()
        {
            Console.Clear();

            int lineCount = 0;

            foreach (string line in TitleStringHolder.main_menu)
            {
                if (lineCount < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                System.Console.WriteLine(line);
                lineCount++;
            }
        }

        static void addStudentMenuTitle()
        {
            //get a title string later
        }

        static void viewStudentsTitle()
        {
            //View Students Title goes here
        }

        static void addStudent(int selection)
        {
            Console.Write("STUDENT ID     >> ");
            string id = Console.ReadLine();
            Console.Write("FIRST NAME     >> ");
            string fName = Console.ReadLine();
            Console.Write("LAST NAME      >> ");
            string lName = Console.ReadLine();

            FileWorker fw = new FileWorker(filename);

            if(selection == 0)
            {
                Console.Write("CAMPUS         >> ");
                string campus = Console.ReadLine();
                FullTimeStudent fts = new FullTimeStudent(id,fName,lName,true,campus);
                ListHolder.addStudent(fts);
                fw.addToFile(StudentFormatter.formatForWrite(fts));
                
            }else
            {
                Console.Write("FACILITATOR    >> ");
                string facilitator = Console.ReadLine();
                DistanceStudent dts = new DistanceStudent(id,fName,lName,true,facilitator);
                ListHolder.addStudent(dts);
                fw.addToFile(StudentFormatter.formatForWrite(dts));
            }

            System.Console.WriteLine($"Student with id {id} added");
            System.Console.WriteLine("Press any key to go back ...");
            Console.ReadKey();
            addStudentMenu();
        }

        static void viewStudents()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("");
            
            System.Console.WriteLine(StudentFormatter.studentReport(ListHolder.getStudents()));

            System.Console.WriteLine("\n\n\nPress any Key to go back ...");
            Console.ReadKey();
    
            mainMenu();
        }

    }
}

//Menu Code from : https://www.dreamincode.net/forums/topic/365540-Console-Menu-with-Arrowkeys/
