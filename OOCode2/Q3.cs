using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode2_3
{
    class Q3
    {
        public static void Main()
        {
            Random random= new Random();
            SkillAssureTrainingModel model= new SkillAssureTrainingModel();
            for(int n1 = 0; n1 < 3; n1++)
            {
                Iteration iteration= new Iteration();
                Course course = new Course();
                int extra_assess = random.Next(6, 11);
                for(int n2=0;n2<extra_assess;n2++)
                {
                    Assessment assessment= new Assessment();
                    int questions = random.Next(50, 61);
                    assessment.NoQuestions = questions;
                    for(int n3=0;n3<questions;n3++)
                    {
                        double coin = random.NextDouble();
                        if (coin < 0.5) assessment.QuestionList.Add(new MCQQuestion());
                        else assessment.QuestionList.Add(new HandsOnQuestion());
                    }
                    double coin2 = random.NextDouble();
                    if (coin2 < 0.5) iteration.AssessmentList.Add(assessment);
                    else course.AssessmentList.Add(assessment);
                }
                iteration.Course= course;
            }
        }
    }
    class SkillAssureTrainingModel
    {
        public string ClientName { get; set; }
        public Iteration[] Iterations { get; set; } = new Iteration[3];
        public int GetTotalAssessmentsInTheTraining()
        {
            int res = 0;
            foreach (Iteration iteration in Iterations)
            {
                res += iteration.GetTotalAssesment();
            }
            return res;
        }
        public int GetMCQBasedAssesments()
        {
            int res = 0;
            foreach (Iteration iteration in Iterations)
            {
                res += iteration.GetMCQAssesment();
            }
            return res;
        }
        public int GetHandsOnBasedAssesments()
        {
            int res = 0;
            foreach (Iteration iteration in Iterations)
            {
                res += iteration.GetHandsOnAssesment();
            }
            return res;
        }
    }
    class Iteration
    {
        public int IterationNo { get; set; }
        public string Goal { get; set; }
        public Course Course { get; set; }
        public List<Assessment> AssessmentList { get; set; } = new List<Assessment>();

        public int GetTotalAssesment()
        {
            return AssessmentList.Count + Course.GetTotalAssessment();
        }
        public int GetMCQAssesment()
        {
            int res = Course.GetMCQAssesment();
            foreach(Assessment assessment in AssessmentList)
            {
                res += assessment.GetMCQQuestions();
            }
            return res;
        }
        public int GetHandsOnAssesment()
        {
            int res = Course.GetHandsOnAssesment();
            foreach (Assessment assessment in AssessmentList)
            {
                res += assessment.GetHandsOnQuestions();
            }
            return res;
        }
    }
    class Course
    {
        public string CourseId{ get; set; }
        public string Name{ get; set; }
        public List<Assessment> AssessmentList { get; set; } = new List<Assessment>();
        public int GetTotalAssessment()
        {
            return AssessmentList.Count;
        }
        public int GetMCQAssesment()
        {
            int res = 0;
            foreach(Assessment assessment in AssessmentList)
            {
                res += assessment.GetMCQQuestions();
            }
            return res;
        }
        public int GetHandsOnAssesment()
        {
            int res = 0;
            foreach (Assessment assessment in AssessmentList)
            {
                res += assessment.GetHandsOnQuestions();
            }
            return res;
        }
    }
    class Assessment
    {
        public string AssessmentId { get; set; }
        public string Description { get; set; }
        public int NoQuestions { get; set; }
        public DateTime DtAssessment { get; set; }
        public List<Question> QuestionList { get; set; } = new List<Question>();

        public int GetMCQQuestions()
        {
            int res = 0;
            foreach(Question question in QuestionList)
            {
                if(question is MCQQuestion)
                {
                    res++;
                }
            }
            return res;
        }
        public int GetHandsOnQuestions()
        {
            int res = 0;
            foreach (Question question in QuestionList)
            {
                if (question is HandsOnQuestion)
                {
                    res++;
                }
            }
            return res;
        }
    }
    abstract class Question
    {
        public int Marks { get; set; }
    }
    class MCQQuestion : Question
    {
        public string QuestionName { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string RightOption { get; set; }
    }
    class HandsOnQuestion : Question
    {
        public string QuestionDesc { get; set; }
        public string ReferenceDocument { get; set; }

    }
}
