using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarks.BusinessLogic
{
    public class Student
    {
        int[] marks;
        int sum;
        bool sumAvailable;
        static string[] gradeNames = { "1st Class", "2nd Class", "Pass Class", "Fail" };
        static int[] gradeScore = { 60, 50, 35 };
        public Student(int[] marks) {
            this.marks = marks;
            this.sum= 0;
            this.sumAvailable = false;
        }
        public int FindSum()
        {
            if(this.sumAvailable) return this.sum;
            int sum = 0;
            for(int i = 0; i < marks.Length; i++)
            {
                sum += marks[i];
            }
            this.sum = sum;
            this.sumAvailable = true;
            return sum;
        }

        public double FindAverage()
        {
            double sum = this.FindSum();
            return sum / this.marks.Length;
        }
        public string FindGrade()
        {
            double average = FindAverage();
            int i;
            for(i=0; i < gradeScore.Length;i++)
            {
                if(average> gradeScore[i]) return gradeNames[i];
            }
            return gradeNames[i];
        }
    }
}
