using SimpleLibrarySystem.LibaryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Student student = librarySystem.GetAllStudents()[0];
            Instructor instructor = librarySystem.GetAllInstructors()[1];
            List<Book> books = librarySystem._catalog.GetAllBooks();
            List<EBook> ebooks = librarySystem._catalog.GetAllEBooks();
            List<Journal> journals = librarySystem._catalog.GetAllJournals();
            List<Magazine> magazines = librarySystem._catalog.GetAllMagazines();

            List<LibraryItem> items = new List<LibraryItem>();

            int milliseconds = 2500;
            
            //Catalog librarySystem._catalog = librarySystem._catalog;
            //Librarian librarySystem._librarian = librarySystem._librarian;
            Console.WriteLine("Library System");
            Console.WriteLine();

            Book book = books.ElementAt(1);
            Book clonedBook = (Book)librarySystem._librarian.CloneAnItem(librarySystem._catalog, book);
            Book clonedBook2 = (Book)librarySystem._librarian.CloneAnItem(librarySystem._catalog, clonedBook);
            EBook eBook = ebooks.ElementAt(2);
            EBook clonedEBook = (EBook)librarySystem._librarian.CloneAnItem(librarySystem._catalog, eBook);
            Journal journal = journals.ElementAt(3);
            Journal clonedJournal = (Journal)librarySystem._librarian.CloneAnItem(librarySystem._catalog, journal);
            Magazine magazine = magazines.ElementAt(4);
            Magazine clonedMagazine = (Magazine)librarySystem._librarian.CloneAnItem(librarySystem._catalog, magazine);

            //STUDENT PART
            Console.WriteLine("Student will check out book");
            student.CheckOutItem(book, librarySystem._catalog);

            Console.WriteLine("Student will check out an ebook");
            student.CheckOutItem(eBook, librarySystem._catalog);

            Console.WriteLine("Student will check out an journal");
            student.CheckOutItem(journal, librarySystem._catalog);

            student.PrintItemsCheckedOut();

            Console.WriteLine("Student will return journal");
            student.ReturnItem(journal, librarySystem._catalog);

            student.PrintItemsCheckedOut();

            Console.WriteLine("Student will check out a magazine");
            student.CheckOutItem(magazine, librarySystem._catalog);

            student.PrintItemsCheckedOut();

            Console.WriteLine("Student will return magazine, ebook, book");
            student.ReturnItem(magazine, librarySystem._catalog);
            student.ReturnItem(eBook, librarySystem._catalog);
            student.ReturnItem(book, librarySystem._catalog);

            student.PrintItemsCheckedOut();

            Console.WriteLine("Student will rent clones of the same item");
            student.CheckOutItem(book, librarySystem._catalog);
            student.CheckOutItem(clonedBook, librarySystem._catalog);
            student.CheckOutItem(clonedBook2, librarySystem._catalog);

            student.PrintItemsCheckedOut();

            Console.WriteLine("Student will return all cloned books");
            student.ReturnItem(book, librarySystem._catalog);
            student.ReturnItem(clonedBook, librarySystem._catalog);
            student.ReturnItem(clonedBook2, librarySystem._catalog);

            student.PrintItemsCheckedOut();




            //INSTRUCTOR PART
            Console.WriteLine("Instructor will check out book");
            instructor.CheckOutItem(book, librarySystem._catalog);

            Console.WriteLine("Instructor will check out an ebook");
            instructor.CheckOutItem(eBook, librarySystem._catalog);

            Console.WriteLine("Instructor will check out an journal");
            instructor.CheckOutItem(journal, librarySystem._catalog);

            instructor.PrintItemsCheckedOut();

            Console.WriteLine("Instructor will return journal");
            instructor.ReturnItem(journal, librarySystem._catalog);

            instructor.PrintItemsCheckedOut();

            Console.WriteLine("Instructor will check out a magazine");
            instructor.CheckOutItem(magazine, librarySystem._catalog);

            instructor.PrintItemsCheckedOut();

            Console.WriteLine("Instructor will return magazine, ebook, book");
            instructor.ReturnItem(magazine, librarySystem._catalog);
            instructor.ReturnItem(eBook, librarySystem._catalog);
            instructor.ReturnItem(book, librarySystem._catalog);

            instructor.PrintItemsCheckedOut();

            Console.WriteLine("Instructor will rent clones of the same item");
            instructor.CheckOutItem(book, librarySystem._catalog);
            instructor.CheckOutItem(clonedBook, librarySystem._catalog);
            instructor.CheckOutItem(clonedBook2, librarySystem._catalog);

            instructor.PrintItemsCheckedOut();























































            /*
            Console.WriteLine("Printing items in system");
            Thread.Sleep(milliseconds);
            librarySystem._catalog.PrintItems();
            Thread.Sleep(milliseconds+milliseconds);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Printing books in system");
            Thread.Sleep(milliseconds);
            librarySystem._catalog.PrintItems();
            Thread.Sleep(milliseconds + milliseconds);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Printing User Information");
            student.UserInfo();
            Thread.Sleep(milliseconds);
          
            instructor.UserInfo();
            Thread.Sleep(milliseconds + milliseconds);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Student " + student.FullName + " will now check out 3 books");
            Thread.Sleep(milliseconds + milliseconds);
            student.CheckOutBook(books.ElementAt(0), catalog);
            student.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            student.CheckOutBook(books.ElementAt(1), catalog);
            student.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            student.CheckOutBook(books.ElementAt(2), catalog);
            student.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            //Throws exception as it should
            /*
            student.CheckOutBook(books.ElementAt(3), catalog);
            student.PrintBooksCheckedOut();
            */
            /*
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Student " + student.FullName + " will now return all books");
            Thread.Sleep(milliseconds + milliseconds);
            student.ReturnBook(books.ElementAt(2), catalog);
            student.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            student.ReturnBook(books.ElementAt(1), catalog);
            student.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            student.ReturnBook(books.ElementAt(0), catalog);
            student.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Instructor " + instructor.FullName + " will now check out 5 books");
            Thread.Sleep(milliseconds + milliseconds);
            instructor.CheckOutBook(books.ElementAt(0), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.CheckOutBook(books.ElementAt(1), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.CheckOutBook(books.ElementAt(2), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.CheckOutBook(books.ElementAt(3), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.CheckOutBook(books.ElementAt(4), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            //Throws Exception as it should
            /*
            instructor.CheckOutBook(books.ElementAt(4), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            */
            /*
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Instructor " + instructor.FullName + " will now return books");
            Thread.Sleep(milliseconds + milliseconds);
            instructor.ReturnBook(books.ElementAt(4), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.ReturnBook(books.ElementAt(3), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.ReturnBook(books.ElementAt(2), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.ReturnBook(books.ElementAt(1), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);
            //Console.ReadLine();

            instructor.ReturnBook(books.ElementAt(0), catalog);
            instructor.PrintBooksCheckedOut();
            Thread.Sleep(milliseconds);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            librarySystem._catalog.PrintBooks();



            Console.WriteLine("Enter any key to quit");
            Console.ReadLine();
            */




            /*
            int n = 10;
            SLS librarySystem = new SLS(true, n);
            Random rand = new Random();
            List<Student> students = librarySystem.GetAllStudents();
            List<Instructor> instructors = librarySystem.GetAllInstructors();
            List<Book> books = librarySystem._catalog.GetAllBooks();
            Librarian librarian = librarySystem._librarian;
            Student s = students.ElementAt(rand.Next(n));
            Instructor i = instructors.ElementAt(rand.Next(n));
            bool quit = false;
            String isbn = "";
            String bookIdInput = "";
            String title = "";
            String author = "";
            BookType type = BookType.art;
            BookLocation location = BookLocation.firstFloor;
            long bookID = 0;

            while(!quit)
            {
                Console.WriteLine("****     Welcome to Da Library!!      ******");
                Console.WriteLine();
                Console.WriteLine("Student Mode or Librarian Mode?");
                Console.WriteLine("'1' for Student");
                Console.WriteLine("'2' for Instructor");
                Console.WriteLine("'3' for Librarian");


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
                                s.UserInfo();
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
                            Book b2;
                            bool loop2 = true;
                            while (loop2)
                            {
                                Console.WriteLine("**************** Instructor Mode **********************");
                                i.UserInfo();
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

                                        b2 = books.Where(x => x.GetIsbn() == input1).FirstOrDefault();
                                        i.CheckOutBook(new Book(b2.GetBookId(), b2.GetTitle(), b2.GetAuthor(), b2.GetIsbn(), b2.GetType(), b2.GetLocation()), librarySystem._catalog);
                                        Console.WriteLine("Book with ISBN#: " + b2.GetIsbn() + " Checked Out!");
                                        Console.WriteLine();
                                        break;
                                    case '2':
                                        s.PrintBooksCheckedOut();
                                        Console.Write("Type the isbn of the book you want to return: ");
                                        string input2 = Console.ReadLine();

                                        b2 = s.GetBooksCheckedOut().Where(x => x.GetIsbn() == input2).FirstOrDefault();
                                        i.ReturnBook(new Book(b2.GetBookId(), b2.GetTitle(), b2.GetAuthor(), b2.GetIsbn(), b2.GetType(), b2.GetLocation()), librarySystem._catalog);
                                        Console.WriteLine("Book with ISBN#: " + b2.GetIsbn() + " Returned!");
                                        Console.WriteLine();
                                        break;
                                }
                                Console.WriteLine("Continue in Instructor Mode?");
                                Console.WriteLine("1 for yes");
                                Console.WriteLine("2 for no");
                                char looper = Console.ReadKey().KeyChar;
                                if (looper == '2')
                                {
                                    loop = false;
                                }
                            }
                            
                            break;
                        case '3':

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
            
            */
        }
    }
}
