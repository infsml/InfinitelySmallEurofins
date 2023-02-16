using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode3_hopital
{
    class HopitalEmployee
    {
        public static void Main()
        {
            Random random= new Random();
            Hospital hospital= new Hospital();
            Console.WriteLine("Created Hospital");
            int n = random.Next(15, 20);
            Console.WriteLine($"Creating {n} Wards");
            WardType[] types = { WardType.IntensiveCareUnit, WardType.GeneralUint, WardType.PediatricUnit, WardType.SurgicalUnit };
            for(int i = 0; i < n; i++)
            {
                Ward ward = new Ward() {
                    WardName = $"Ward{i}",
                    WardType = types[random.Next(types.Length)],
                    BasicCost = random.NextDouble()*5000+5000
                };
                int n2 = random.Next(20, 25);
                Console.WriteLine($"Creating {n2} Patients");
                for(int j=0;j<n2; j++)
                {
                    ward.Patients.Add(new Patient());
                }
                hospital.Wards.Add(ward);
            }
            n = random.Next(135, 150);
            Console.WriteLine($"Creating {n} Doctors");
            for(int i = 0; i < n; i++)
            {
                double roulete = random.NextDouble();
                Employee emp = new Employee();
                if (roulete < 0.1) emp = new ConsultantDoctor();
                else if (roulete < 0.2) emp = new InternalDoctor();
                else if (roulete < 0.8) emp = new Doctor() { Speciality = $"S{random.Next(5,9)}"};
                else if (roulete < 0.9) emp = new Receptionist();
                else emp = new Nurse();
                hospital.Employees.Add(emp);
            }
            Console.WriteLine(hospital.GetTotalPatients());
            Console.WriteLine(hospital.GetTotalDoctors());
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ResidentalAddress { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
    }
    class Patient : Person {
        public DateTime AdmittedDate { get; set; }
        public List<string> Allergies { get; set; } = new List<string>();
        public string PatientName { get; set; }
        public int Age { get; set; }
    }
    class Ward {
        public string WardName { get; set; }
        public WardType WardType { get; set; }
        public double BasicCost { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public double GetWardCost()
        {
            return WardCostCalculator.FindWardCost(BasicCost, WardType);
        }
        public int GetTotalPatients()
        {
            return Patients.Count;
        }
    }
    enum WardType { 
        IntensiveCareUnit,GeneralUint,PediatricUnit,SurgicalUnit
    }
    class Employee : Person {
        public DateTime DateOfJoin { get; set; }
        public string Education { get; set; }
    }
    class Hospital {
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set;} = new List<Employee>();
        public List<Ward> Wards { get; set;} = new List<Ward>();


        public int GetTotalPatients()
        {
            int res = 0;
            foreach(Ward w in Wards)
            {
                res += w.GetTotalPatients();
            }
            return res;
        }
        public int GetTotalPatientsByWard(Ward ward)
        {
            return ward.GetTotalPatients();
        }
        public int GetTotalDoctors()
        {
            int res = 0;
            foreach(Employee e in Employees)
            {
                if (e is Doctor) res++;
            }
            return res;
        }
        public List<Doctor> GetDoctorsBySpeialization(string specialization)
        {
            List<Doctor> res = new List<Doctor>();
            foreach(Employee e in Employees)
            {
                if(e is Doctor)
                {
                    if((e as Doctor).Speciality == specialization)
                    {
                        res.Add(e as Doctor);
                    }
                }
            }
            return res;
        }
        public int GetTotalConsultants()
        {
            int res = 0;
            foreach (Employee e in Employees)
            {
                if (e is ConsultantDoctor) res++;
            }
            return res;
        }
        public double GetWardCostByType(WardType wardType)
        {
            double res = 0;
            foreach (Ward w in Wards)
            {
                if(w.WardType == wardType)
                {
                    res += w.GetWardCost();
                }
            }
            return res;
        }
    }
    class Doctor : Employee{
        public string Speciality { get; set; }
    }
    class Receptionist : Employee { }
    class Nurse : Employee { }
    class ConsultantDoctor : Doctor { }
    class InternalDoctor : Doctor { }

    class WardCostCalculator
    {
        public static double FindWardCost(double Basic, WardType wardType)
        {
            int percentWardCost = 0;
            if (wardType == WardType.GeneralUint) percentWardCost = 10;
            if(wardType == WardType.IntensiveCareUnit)percentWardCost = 20;
            if (wardType == WardType.PediatricUnit) percentWardCost = 25;
            if (wardType == WardType.SurgicalUnit) percentWardCost = 40;
            return Basic + (percentWardCost * Basic) / 100.0;
        }
    }
}
