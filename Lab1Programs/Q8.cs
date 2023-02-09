using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q8
    {
        public static void Main()
        {
            Console.WriteLine("Enter total hours : ");
            int totalHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Rate per hour : ");
            int ratePerHour = int.Parse(Console.ReadLine());
            Console.WriteLine("Does company have external consultants : (y/n)");
            char hasExternalConsultantsChar = Console.ReadLine().ToCharArray()[0];
            bool hasExternalConsultants = hasExternalConsultantsChar == 'y' || hasExternalConsultantsChar == 'Y';
            int consultantHours = 0, consultantRatePerHour=0;
            if (hasExternalConsultants)
            {
                Console.WriteLine("Enter total hours : ");
                consultantHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Rate per hour : ");
                consultantRatePerHour = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Does company have hardware infrastructure : (y/n)");
            char hasHwInfraChar = Console.ReadLine().ToCharArray()[0];
            bool hasHwInfra = hasHwInfraChar == 'y' || hasHwInfraChar == 'Y';
            int hwInfraCost=0;
            if (hasHwInfra)
            {
                Console.WriteLine("Enter hardware infrastructure costs : ");
                hwInfraCost = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Does company have software license : (y/n)");
            char hasSwLicChar = Console.ReadLine().ToCharArray()[0];
            bool hasSwLic = hasSwLicChar == 'y' || hasSwLicChar == 'Y';
            int swLicCost=0;
            char swLicType='C';
            if (hasSwLic)
            {
                Console.WriteLine("Enter software license costs : ");
                swLicCost = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter software license type : ");
                swLicType = char.Parse(Console.ReadLine());
            }
            int projectCost = totalHours * ratePerHour+(hwInfraCost * 3) / 10;
            int swCost=swLicCost;
            if (swLicType == 'C')
            {
                swCost = swCost / 2;
            }
            projectCost = projectCost + swCost;
            Console.WriteLine($"Project cost {projectCost}");
            int profits = projectCost - ((consultantHours * consultantRatePerHour) + hwInfraCost + swLicCost);
            Console.WriteLine($"The profits is {profits}");
            if(profits> 0) { Console.WriteLine("It is profitable"); }
            else { Console.WriteLine("It is not profitable"); }
        }
    }
}
