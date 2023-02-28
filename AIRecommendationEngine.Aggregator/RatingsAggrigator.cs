using AIRecommendationEngine.Common;
using AIRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Aggregator
{
    public class RatingsAggrigator : IRatingsAggregator
    {
        IAgeGroup ageGroup;
        public RatingsAggrigator(IAgeGroup ageGroup)
        {
            this.ageGroup = ageGroup;
        }
        public Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference)
        {
            Dictionary<string,List<int>> res = new Dictionary<string,List<int>>();
            List<User> users = new List<User>();
            int preferenceAgeGroup = ageGroup.GetGroup(preference.Age);
            foreach(User u in bookDetails.Users.Values)
            {
                if (preference.State.Equals(u.State) && preferenceAgeGroup == ageGroup.GetGroup(u.Age))
                    users.Add(u);
            }
            for(int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                foreach (BookUserRating rating in user.UserRating)
                {
                    if (!res.ContainsKey(rating.ISBN)) res[rating.ISBN] = new List<int>(Enumerable.Repeat(0,users.Count));
                    int mRating = rating.Rating;
                    if(mRating<0)mRating = 0;
                    if(mRating>10)mRating = 10;
                    res[rating.ISBN][i]= mRating;
                }
            }
            return res;
        }
    }
}
