using System;
using System.Collections.Generic;
using System.Text;
using V8Features.Models;

namespace V8Features
{
    public class InMemoryDb 
    {
        public readonly List<Comment> comments = new List<Comment>(); //readonly members
        public readonly List<Author> authors = new List<Author>();
        public readonly List<BlogPost> blogPosts = new List<BlogPost>();
        public readonly List<Book> books = new List<Book>();
        public IOperation<Book> booksRepository;
        public readonly int Salary;

        public InMemoryDb()
        {
            BuildAuthors(); //readonly can be initisialized at time of object creation only
            BuildCommnets();
            BuildBlogs();
            BuildBooks();
            booksRepository = new Book(books);
        }

        private void BuildAuthors()
        {
            authors.AddRange(new[] {
                new Author("abc", "abc.com",true,"admin"),
                new Author("sab", "sab.com",false,"user"),
                new Author("xyz", "xyz.com",true,"poweruser"),
                new Author("bc", "bc.com",false,"admin")
            });
        }

        private void BuildCommnets()
        {
            comments.AddRange(new[] {
                new Comment("Comments1 for author1", authors[0]),
                new Comment("Comments1 for author2", authors[1]),
                new Comment("Comments2 for author1", authors[2]),
                new Comment("Comments2 for author2", authors[3])
            });
        }

        private void BuildBlogs()
        {
            blogPosts.AddRange(new[] {
                new BlogPost("Public",comments.ToArray()[0..2],"Post1"), // here 0 is starting index which is included but 2 is excluded same like length - 1 
                new BlogPost("Public",comments.ToArray()[^2..],"Post2"), // last ^0 is length ^1 is length -1 ; ^2 is length -2 
            });
        }

        private void BuildBooks()
        {
            books.AddRange(new[] {
                new Book("God of small things",1,authors[0]),
                new Book("The white Tiger",2,authors[1]),
                new Book("A Suitable Boy",3,authors[2]),
                new Book("The palace of Illusion",4,authors[3]),
            }); ;
        }
        public  Book BuildNewEntity()
        {
            return new Book();
        }
    }
}
