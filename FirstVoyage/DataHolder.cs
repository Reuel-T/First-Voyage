using System.Threading;
using System.Threading.Tasks;
using System.Security;
using System;
using System.Collections.Generic;

namespace FirstVoyage
{
    public static class DataHolder
    {
        //move the list to another class, have list workers
        private static List<Student> students = new List<Student>();

        public static void addStudent(Student st){
            students.Add(st);
        }

        public static string studentReport(){
            int fullTime = 0;
            int distance = 0;
            string ftStudents = String.Empty;
            string dtStudents = String.Empty;
            
            foreach (Student item in students)
            {
                if (item is FullTimeStudent)
                {
                    FullTimeStudent fts = (FullTimeStudent)item;
                    fullTime++;
                    ftStudents += $"{fts.getId()}\t{fts.getFirstName()}\t{fts.getLectureHours()}\t{fts.getCampus()}\n";
                }
                
                else if (item is DistanceStudent)
                {
                    DistanceStudent dts = (DistanceStudent)item;
                    distance++;
                    dtStudents += $"{dts.getId()}\t{dts.getFirstName()}\t{dts.getLectureHours()}\t{dts.getFacilitator()}\n";
                    
                }
            }

            return $"There are {fullTime} Full Time Students\nThere are {distance} Part Time Students\n\nFULL TIME STUDENTS:\n{ftStudents}\n\nPART TIME STUDENTS:\n{dtStudents}";

        }

    }
}