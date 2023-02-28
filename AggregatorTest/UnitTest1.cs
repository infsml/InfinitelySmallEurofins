using AIRecommendationEngine.Aggregator;
using AIRecommendationEngine.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AggregatorTest
{
    [TestClass]
    public class UnitTest1
    {
        BookDetails details;
        IRatingsAggregator aggregator;
        [TestInitialize] 
        public void Init() {
            aggregator = new RatingsAggrigator(new AgeGroup());


            details = new BookDetails();
            Book book = new Book()
            {
                ISBN = "74108520",
            };
            Book book1 = new Book()
            {
                ISBN = "98765432"
            };
            Book book2 = new Book()
            {
                ISBN = "98764545"
            };
            User user = new User()
            {
                UserID = "1",
                Age = 25,
                State = "Alabama"
            };
            User user1 = new User()
            {
                UserID = "2",
                Age = 135,
                State = "Kimolasa"
            };
            User user2 = new User()
            {
                UserID = "3",
                Age = 17,
                State = "Alabama"
            };
            BookUserRating rating = new BookUserRating()
            {
                UserID = user1.UserID,
                Book = book,
                Rating = 5,
                User = user1,
                ISBN = book.ISBN
            };
            user1.UserRating.Add(rating);
            book.UserRating.Add(rating);
            BookUserRating rating1 = new BookUserRating()
            {
                UserID = user2.UserID,
                User = user2,
                Rating = 6,
                Book = book,
                ISBN=book.ISBN
            };
            user2.UserRating.Add(rating1);
            book.UserRating.Add(rating1);
            BookUserRating rating2 = new BookUserRating()
            {
                UserID = user.UserID,
                Book = book1,
                Rating = 9,
                User = user,
                ISBN = book1.ISBN
            };
            user.UserRating.Add(rating2);
            book1.UserRating.Add(rating2);

            BookUserRating rating3 = new BookUserRating()
            {
                UserID = user.UserID,
                Book = book,
                Rating = -1,
                User = user,
                ISBN = book.ISBN
            };
            user.UserRating.Add(rating3);
            book.UserRating.Add(rating3);
            
            BookUserRating rating4 = new BookUserRating()
            {
                UserID = user.UserID,
                Book = book2,
                Rating = 19,
                User = user,
                ISBN = book2.ISBN
            };
            user.UserRating.Add(rating4);
            book2.UserRating.Add(rating4);

            details.Users[user.UserID] = user;
            details.Users[user1.UserID] = user1;
            details.Users[user2.UserID] = user2;

            details.Books[book.ISBN] = book;
            details.Books[book1.ISBN] = book1;
            details.Books[book2.ISBN] = book2;

            details.UserRating.Add(rating);
            details.UserRating.Add(rating1);
            details.UserRating.Add(rating2);
            details.UserRating.Add(rating3);
            details.UserRating.Add(rating4);
        }
        [TestCleanup]
        public void Cleanup()
        {
            details = null;
        }
        [TestMethod]
        public void RatingsAggrigator_ValidInput_ValidOutput()
        {
            Preference preference = new Preference()
            {
                State = "Alabama",
                Age = 20
            };
            Dictionary<string,List<int>> result = aggregator.Aggrigate(details, preference);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        /*[TestMethod]
        public void RatingsAggrigator_*/
    }
}
