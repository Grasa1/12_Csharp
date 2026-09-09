namespace Ismetles2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Books a = new Books("The Great Gatsby", "F. Scott Fitzgerald", 180);
            Books b = new Books("To Kill a Mockingbird", "Harper Lee", -281);
            Console.WriteLine(Books.Count);
            Books c = new Books("1984", "George Orwell", 328);
            Books d = new Books("Pride and Prejudice", "Jane Austen");
            Console.WriteLine(Books.Count);
            a.Pagecount = 50;
            Console.WriteLine(b.Pagecount);
            Console.WriteLine(a.Title);
            Console.WriteLine(c.IsLongBook());


        }
    }
}
