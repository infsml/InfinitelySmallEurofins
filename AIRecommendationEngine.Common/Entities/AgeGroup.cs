using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Common.Entities
{
    public class AgeGroup : IAgeGroup
    {
        private int[] bounds = { 0, 16, 30, 50, 60, 100 };
        public int GetGroup(int age)
        {
            int grp = 0;
            while (age > bounds[grp] && grp<bounds.Length) grp++;
            return grp;
        }
    }
}
