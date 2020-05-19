using System;
using System.Collections.Generic;
using System.Text;
using V8Features.Models;

namespace V8Features
{
    public interface IDefaultBook : IOperation<Book>
    {
        private static int rating = 0; //can use static variable and methods in C#8.0 interfaces

        static void setRatings(int ratingval)
        {
            rating = ratingval;
        }
        Book rateBook(int bookID)
        {
            //default logic here  
            var book = SetProperty(bookID);
            Console.WriteLine("Executed the Default implementation in the interface");
            return book;
        }
    }
}
