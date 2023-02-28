using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.CoreRecommender
{
    public class PearsonCorrelation : IRecommender
    {
        public double GetCorrelation(List<int> baseData, List<int> otherData)
        {
            int len = baseData.Count;
            int diff = otherData.Count-baseData.Count;
            
            // If other data is larger than base data trim other array to the size of base array
            if(diff>0)otherData.RemoveRange(len, diff);
            
            // If other data is smaller than base data add 1 to both corresponding element
            if (diff < 0) {
                for (int i = otherData.Count; i < baseData.Count; i++)
                {
                    baseData[i]++;
                }
                otherData.AddRange(Enumerable.Repeat(1, -diff));
            }
            
            //If any array element value is 0, add 1 to both the corresponding array element
            for(int i=0; i < baseData.Count; i++)
            {
                if (baseData[i] ==0 || otherData[i] == 0)
                {
                    baseData[i]++;
                    otherData[i]++;
                }
                if (baseData[i] > 10) baseData[i] = 10;
                if (otherData[i] > 10) otherData[i]= 10;
            }

            double sx = 0,sy= 0,sx2=0,sy2= 0,sxy= 0;

            for(int i=0;i<baseData.Count ; i++)
            {
                sx += baseData[i];
                sy += otherData[i];

                sx2 += baseData[i] * baseData[i];
                sy2 += otherData[i] * otherData[i];

                sxy += baseData[i] * otherData[i];
            }
            double numerator = len*sxy - (sx * sy);
            double denominator = Math.Sqrt(len*sx2 - (sx * sx)) * Math.Sqrt(len*sy2 - (sy * sy));
            return numerator/denominator;
        }
    }
}
