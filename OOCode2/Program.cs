using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organization organization= new Organization() {Name = "Some.Org" };
            Trainer trainer= new Trainer() { Organization= organization };
            Training Training = new Training() { Trainer = trainer};
            Console.WriteLine($"TrainingOrganizationName: {Training.GetTrainingOrganizationName()}");

            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();
            Training.Trainees.Add(t1);
            Training.Trainees.Add(t2);
            Training.Trainees.Add(t3);
            Console.WriteLine($"NumberOfTrainees: {Training.GetNumberOfTrainees()}");

            Training.Course = new Course();
            Module m1 = new Module();
            m1.Units.Add(new Unit { Duration = 10 });
            m1.Units.Add(new Unit { Duration = 20 });
            m1.Units.Add(new Unit { Duration = 30 });
            Training.Course.Modules.Add(m1);
            m1 = new Module();
            m1.Units.Add(new Unit { Duration = 10 });
            m1.Units.Add(new Unit { Duration = 20 });
            m1.Units.Add(new Unit { Duration = 30 });
            Training.Course.Modules.Add(m1);
            Console.WriteLine($"TrainingDurationInHrs: {Training.GetTrainingDurationInHrs()}");

        }
    }
    class Organization
    {
        public string Name { get; set; }

    }

    class Trainer
    {

        public Organization Organization { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();

    }

    class Trainee
    {
        public Trainer Trainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();

    }

    class Training
    {
        public Trainer Trainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public Course Course { get; set; }

        public string GetTrainingOrganizationName()
        {
            return Trainer.Organization.Name;
        }

        public int GetNumberOfTrainees()
        {
            return Trainees.Count;
        }
        public int GetTrainingDurationInHrs()
        {
            int res = 0;
            foreach(Module module in Course.Modules)
            {
                foreach(Unit unit in module.Units)
                {
                    res += unit.Duration;
                }
            }
            return res;
        }
    }
    class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();

    }
    class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();

    }
    class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();


    }
    class Topic
    {
        public string Name { get; set; }
    }
}
