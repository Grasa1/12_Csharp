using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles2
{
    public class Library
    {
        public string Name { get; set; }

        public int BookCount
        {
            get { return _books.Count; }
        }

        private List<Books> _books = new List<Books>();

        public Library(string name)
        {
            Name = name;
        }

        public void Addbook(Books book)
        {
            _books.Add(book);
        }

        public void Printall()
        {
            Console.WriteLine($"Books in {Name}:");
            foreach (var book in _books)
            {
                Console.WriteLine(book.Describe());
            }
        }   
        public Books Findbylittle(string title)
        {
            foreach (var book in _books)
            {
                if (book.Title == title)
                {
                    return book;
                }
            }
            return null;
        }
        public Books Findbylittle(string author)
        {
            foreach (var book in _books)
            {
                if (book.AuthorProprty == author)
                {
                    return book.Title  ;
                }
            }
            return null;
        }
    }
}
