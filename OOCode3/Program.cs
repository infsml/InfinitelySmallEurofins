using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            ide.languages.Add(new C());
            ide.languages.Add(new Java());
            ide.languages.Add (new CSharp());
            ide.WorkWithLanguages();
        }
    }
    class IDE
    {
        public List<ILanguage> languages { get; set; } = new List<ILanguage>();
        public void WorkWithLanguages()
        {
            foreach(ILanguage language in languages)
            {
                Console.WriteLine(language.GetName());
                Console.WriteLine(language.GetParadigm());
                Console.WriteLine(language.GetUnit());
                Console.WriteLine("------------");
            }
        }
    }
    interface ILanguage
    {
        string GetUnit();
        string GetParadigm();
        string GetName();
    }
    abstract class ProceduralLanguage : ILanguage
    {
        public string GetParadigm()
        {
            return "Procedural";
        }
        public string GetUnit()
        {
            return "Function";
        }
        public abstract string GetName();
    }
    abstract class ObjectOrientedLanguage : ILanguage
    {
        public string GetParadigm()
        {
            return "ObjectOriented";
        }
        public string GetUnit()
        {
            return "Class";
        }
        public abstract string GetName();
    }
    class CSharp : ObjectOrientedLanguage
    {
        public override string GetName()
        {
            return "CSharp";
        }
    }
    class C : ProceduralLanguage
    {
        public override string GetName()
        {
            return "C";
        }
    }
    class Java : ObjectOrientedLanguage
    {
        public override string GetName()
        {
            return "Java";
        }
    }
}
