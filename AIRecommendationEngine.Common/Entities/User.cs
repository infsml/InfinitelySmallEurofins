﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Common.Entities
{
    public class User
    {
        public string UserID {get; set;}
        public int Age {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public string Country { get; set; }

        public List<BookUserRating> UserRating { get; set; } = new List<BookUserRating>();
    }
}
