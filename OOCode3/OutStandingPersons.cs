using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode3
{
    class OutStandingPersons
    {
        public static void Main()
        {
            Person[] people = new Person[10];
            Random random= new Random();
            for(int i = 0; i < 10; i++)
            {
                double coin = random.NextDouble();
                if (coin < 0.5) people[i] = new Student($"S{i}", random.NextDouble() * 100);
                else people[i] = new Professor($"P{i}", random.Next(10));
            }
            foreach(Person person in people)
            {
                if (person.isOutstnding())
                {
                    person.disp();
                }
            }
        }
    }
    class Person
    {
        public string name { get; set; }
        public Person() { }
        public Person(string name) { this.name = name; }
        public virtual bool isOutstnding()
        {
            return name.Length > 5;
        }
        public virtual void disp()
        {
            Console.WriteLine($"Name : {name}");
        }
    }
    class Professor : Person
    {
        public int BooksPublished { get; set; }
        public Professor() { }
        public Professor(string name, int booksPublished) : base(name)
        {
            BooksPublished = booksPublished;
        }
        public void print()
        {
            Console.WriteLine($"Professor {name} : {BooksPublished} books");
        }
        public override void disp()
        {
            print();
        }
        public override bool isOutstnding() { return BooksPublished > 4; }
    }
    class Student : Person
    {
        public double Percentage { get; set; }
        public Student() { }
        public Student(string name, double percentage) : base(name)
        {
            Percentage = percentage;
        }
        public void display()
        {
            Console.WriteLine($"Student {name} : {Percentage}%");
        }
        public override void disp()
        {
            display();
        }
        public override bool isOutstnding() { return Percentage > 85; }
    }
}
