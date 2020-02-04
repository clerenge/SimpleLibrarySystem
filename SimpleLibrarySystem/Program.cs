using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    /// <summary>
    /// Demonstrates the basic functionality of my SLS as per the requirements for Assignment 2
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            int n = 10;
            SLS librarySystem = new SLS(true, n);
            Random rand = new Random();
            List<Student> students = librarySystem.GetAllStudents();
            List<Book> books = librarySystem._catalog.GetAllBooks();
            Librarian librarian = librarySystem._librarian;
            Student s = students.ElementAt(rand.Next(n));
            bool quit = false;
            String isbn = "";
            String bookIdInput = "";
            String title = "";
            String author = "";
            BookType type = BookType.art;
            BookLocation location = BookLocation.firstFloor;
            long bookID = 0;
            //bool checkedOut = false;

            while(!quit)
            {
                Console.WriteLine("****     Welcome to Da Library!!      ******");
                Console.WriteLine();
                Console.WriteLine("Student Mode or Librarian Mode?");
                Console.WriteLine("'1' for Student");
                Console.WriteLine("'2' for Librarian");


                try
                {
                    char key = Console.ReadKey().KeyChar;
                    switch(key)
                    {
                        case '1':
                            
                            Book b;
                            bool loop = true;
                            while (loop)
                            {
                                Console.WriteLine("**************** Student Mode **********************");
                                s.PrintStudentInfo();
                                Console.WriteLine("Checking Out or Returning?");
                                Console.WriteLine("'1' for Checking Out");
                                Console.WriteLine("'2' for Returning");
                                key = Console.ReadKey().KeyChar;
                           
                                switch (key)
                                {
                                    case '1':
                                        librarySystem._catalog.PrintBooks();
                                        Console.Write("Type the isbn of the book you want to check out: ");
                                        string input1 = Console.ReadLine();

                                        b = books.Where(x => x.GetIsbn() == input1).FirstOrDefault();
                                        s.CheckOutBook(new Book(b.GetBookId(), b.GetTitle(), b.GetAuthor(), b.GetIsbn(), b.GetType(), b.GetLocation()), librarySystem._catalog);
                                        Console.WriteLine("Book with ISBN#: " + b.GetIsbn() + " Checked Out!");
                                        Console.WriteLine();
                                        break;
                                    case '2':
                                        s.PrintBooksCheckedOut();
                                        Console.Write("Type the isbn of the book you want to return: ");
                                        string input2 = Console.ReadLine();

                                        b = s.GetBooksCheckedOut().Where(x => x.GetIsbn() == input2).FirstOrDefault();
                                        s.ReturnBook(new Book(b.GetBookId(), b.GetTitle(), b.GetAuthor(), b.GetIsbn(), b.GetType(), b.GetLocation()), librarySystem._catalog);
                                        Console.WriteLine("Book with ISBN#: " + b.GetIsbn() + " Returned!");
                                        Console.WriteLine();
                                        break;
                                }
                                Console.WriteLine("Continue in Student Mode?");
                                Console.WriteLine("1 for yes");
                                Console.WriteLine("2 for no");
                                char looper = Console.ReadKey().KeyChar;
                                if(looper == '2')
                                {
                                    loop = false;
                                }
                            }
                            break;
                        case '2':

                            Console.WriteLine("**************** Librarian Mode **********************");
                            Console.WriteLine("Librarians Can Add Books to the Catalog");
                            Console.WriteLine();
                            librarySystem._librarian.PrintLibrarianInfo();
                            Console.WriteLine();
                            Console.WriteLine("Enter book info");
                            Console.Write("BookId: ");
                            bookIdInput = Console.ReadLine();
                            bookID = long.Parse(bookIdInput);
                            Console.Write("ISBN #: ");
                            isbn = Console.ReadLine();
                            Console.Write("Title: ");
                            title = Console.ReadLine();
                            Console.Write("Author: ");
                            author = Console.ReadLine();
                            Console.WriteLine("Book Types are as Follows");
                            Console.WriteLine("Science = 1");
                            Console.WriteLine("Arts = 2");
                            Console.WriteLine("Maths = 3");
                            Console.WriteLine("History = 4");
                            Console.WriteLine("Education = 5");
                            Console.WriteLine();
                            Console.Write("Enter Book Type #: ");
                            key = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            switch(key)
                            {
                                case '1':
                                    type = BookType.science;
                                    break;
                                case '2':
                                    type = BookType.art;
                                    break;
                                case '3':
                                    type = BookType.math;
                                    break;
                                case '4':
                                    type = BookType.history;
                                    break;
                                case '5':
                                    type = BookType.education;
                                    break;
                            }

                            b = new Book(bookID, title, author, isbn, type, location);
                            librarySystem._catalog.AddABook(librarySystem._librarian, b);
                            Console.WriteLine(b.GetTitle() + " Successfully Added to the Catalog");
                            Console.WriteLine();

                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                   
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    Console.WriteLine("Press any key to continue: ");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                
            }
            
            
        }
    }
}
