using System;
using System.Collections.Generic;
using System.Text;


namespace V8Features.Models
{
    public class Book : IDefaultBook 
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Author Author { get; set; }
        public int Rating { get; set; }

        public readonly List<Book> Books ; // readonly 
        public Book()
        {    
        }
        public Book(List<Book> books)
        {
            Books = new List<Book>();
            Books.AddRange(books);
        }
        public Book(string name, int id , Author author)
        {
            Name = name;
            Id = id;
            Author = author;
        }
        public List<Book> GetAll()
        {
            return Books;
        }

        public void Add(Book obj)
        {
            Books.Add(obj);
        }

        public void remove(Book obj)
        {
            if (Books.FindIndex(o => o.Equals(obj)) != 0)
            {
                Books.Remove(obj);
            }
        }

        public Book SetProperty(int obj)
        {
            Rating = obj;
            return this;
        }

        public Book GetByID(int obj)
        {
            return Books.Find( book => book.Id.Equals(obj));
        }

        public Book BuildNewEntity()
        {
            return this;
        }
    }
}
