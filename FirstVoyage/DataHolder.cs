using System.Threading;
using System.Threading.Tasks;
using System.Security;
using System;
using System.Collections.Generic;

namespace FirstVoyage
{
    public static class DataHolder
    {
        private static List<Student> students = new List<Student>();

        public static void addStudent(Student st){
            students.Add(st);
        }

        public static string numStudents(){
            int fullTime = 0;
            int partTime = 0;
            
            foreach (Student item in students)
            {
                if (item is FullTimeStudent)
                {
                    fullTime++;
                }
                
                else if (item is DistanceStudent)
                {
                    partTime++;
                }
            }

            return $"There are {fullTime} Full Time Students \nThere are {partTime} Part Time Students";

        }

    }
}