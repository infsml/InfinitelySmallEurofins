using AIRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AIRecommendationEngine.DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        public string dataDirectory { get; set; } = "";
        public CSVDataLoader() { }
        public BookDetails Load()
        {
            const string userFile = "BX-Users.csv";
            const string bookFile = "BX-Books.csv";
            const string ratingFile = "BX-Book-Ratings.csv";

            BookDetails bookDetails = new BookDetails();
            //E T L
            //Extract
            //Transfer
            List<List<string>> users = loadCSVLines(dataDirectory + userFile,delimiter:';',containsHeader:true);
            List<List<string>> books = loadCSVLines(dataDirectory + bookFile,delimiter:';',containsHeader:true);
            List<List<string>> ratings = loadCSVLines(dataDirectory + ratingFile,delimiter:';',containsHeader:true);

            

            //Load
            foreach (var user in users)
            //Parallel.ForEach<List<string>>(users, user =>
            {
                string userID = "";
                string[] userLocation = new string[1];
                int c = user.Count;
                int age=0;
                if (c >= 3)age = ParseInt(user[2]);
                if (c >= 2)userLocation = user[1].Split(',');
                if(c >= 1)userID = user[0];
                
                string[] userLocationAugment = new string[3] { "", "", "" };
                for (int i = 0; i < userLocation.Length && i < 3; i++)
                {
                    userLocationAugment[i] = userLocation[i];
                }
                User userObject = new User()
                {
                    Age = age,
                    UserID = userID,
                    City = userLocationAugment[0],
                    State = userLocationAugment[1],
                    Country = userLocationAugment[2],
                };
                bookDetails.Users[userID] = userObject;
            }

            foreach(var book in books)
            //Parallel.ForEach<List<string>>(books, book =>
            {
                bookDetails.Books[book[0]] = new Book()
                {
                    ISBN = book[0],
                    BookTitle = book[1],
                    BookAuthor = book[2],
                    YearOfPublication = ParseInt(book[3]),
                    Publisher = book[4],
                    ImageUrlSmall = book[5],
                    ImageUrlMedium = book[6],
                    ImageUrlLarge = book[7]
                };
            }//);

            foreach (var rating in ratings)
            //Parallel.ForEach<List<string>>(ratings, rating =>
            {
                User myUser = null;
                Book myBook = null;
                BookUserRating ratingObject = new BookUserRating()
                {
                    UserID = rating[0],
                    ISBN = rating[1],
                    Rating = ParseInt(rating[2])
                };
                if (bookDetails.Users.ContainsKey(rating[0]))
                {
                    myUser = bookDetails.Users[rating[0]];
                    ratingObject.User = myUser;
                    myUser.UserRating.Add(ratingObject);
                }
                if (bookDetails.Books.ContainsKey(rating[1]))
                {
                    myBook = bookDetails.Books[rating[1]];
                    ratingObject.Book = myBook;
                    myBook.UserRating.Add(ratingObject);
                }
                //bookDetails.Users[rating[0]].UserRating.Add(ratingObject);
                //bookDetails.Books[rating[1]].UserRating.Add(ratingObject);
            }//);
            return bookDetails;
        }

        private int ParseInt(string str)
        {
            char[] chars = str.ToCharArray();
            if(chars.Length == 0 ) return 0;
            if (!(chars[0] <= '9' && chars[0] >= '0')) return 0;
            return int.Parse(str);
        }

        private List<List<string>> loadCSVLines(string filePath, char delimiter = ',',bool containsHeader=false)
        {
            List<List<string>> lines = new List<List<string>>();
            StreamReader reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                List<string> line = new List<string>();
                foreach(string column in reader.ReadLine().Split(delimiter))
                {
                    line.Add(column.Trim('"'));
                }
                lines.Add(line);
            }
            //remove header if exists
            if (containsHeader) lines.RemoveAt(0);
            return lines;
        }
    }

    
}
