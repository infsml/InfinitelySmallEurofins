using StudentMarks.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarks.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get student name and marks in subjects. Display sum and average of the marks
            //Get student name
            Console.Write("Enter the Student name : ");
            string studentName = Console.ReadLine();
            Console.Write("Enter the number of subjects : ");
            int numSubjects = int.Parse(Console.ReadLine());
            int[] marks= new int[numSubjects];
            for(int i=0; i<numSubjects; i++)
            {
                Console.Write($"Enter subject{i} marks : ");
                marks[i] = int.Parse(Console.ReadLine());
            }
            
            // Find sum and average of marks
            Student studentMarks = new Student(marks);
            int sumOfMarks = studentMarks.FindSum();
            double averageOfMarks = studentMarks.FindAverage();
            string grade = studentMarks.FindGrade();

            //Display the result
            Console.WriteLine($"The {studentName} has {sumOfMarks} total, {averageOfMarks} average and {grade} grade");
        }
    }
}
