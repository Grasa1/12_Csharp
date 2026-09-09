using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismetles2
{
    public class Books
    {
        public string Title { get; set; }
        public string AuthorProprty { get; set; }
        public int Pagecount
        {
            get { return pagecount; }
            set
            {
                if (value < 0)
                {
                    pagecount = 0;

                }
                else
                {
                    pagecount = value;
                }
                    
            }
        }
        public bool Isavailable = true;

        private int pagecount = 0;

        public Books(string title, string author, int pagecount)
        {
            Title = title;
            AuthorProprty = author;
            Pagecount = pagecount;
            Count++;
        }

        public string Describe()
        {
            return $"Title: {Title}, Author: {AuthorProprty}, Pagecount: {Pagecount}";
        }

        public bool IsLongBook()
        {
            return Pagecount > 300;
        }

        public Books(string title, string author)
        {
            Title = title;
            AuthorProprty = author;
            Count++;

        }

        public static int Count = 0;
        
        public bool Borrow()
        {
            if (Isavailable)
            {
                Isavailable = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Return()
        {
               Isavailable = true;
        }

    }
}
