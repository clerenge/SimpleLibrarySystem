using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Catalog
    {
        private List<Book> _books;
        private long _numOfBooks;
        private long _staffPassKey;

        /// <summary>
        /// Creates a catalog with no pass key (constructor)
        /// </summary>
        public Catalog()
        {
            _books = new List<Book>();
            _numOfBooks = 0;
        }

        /// <summary>
        /// Creates a catalog with a pass key that only allows a librarian with an identical employeeId to add and remove books (constructor)
        /// </summary>
        /// <param name="key"></param>
        public Catalog(long key)
        {
            _books = new List<Book>();
            _numOfBooks = 0;
            _staffPassKey = key;
        }

        /// <summary>
        /// Adds a book to the catalog (only a valid librarian has the ability to do this)
        /// </summary>
        /// <param name="librarian"></param>
        /// <param name="book"></param>
        public void AddABook(Librarian librarian, Book book)
        {
            if(StaffAuthorized(librarian))
            {
                if(book != null && !_books.Any(x => x.GetIsbn() == book.GetIsbn()))
                {
                    _books.Add(new Book(book.GetBookId(), book.GetTitle(), book.GetAuthor(), book.GetIsbn(), book.GetType(), book.GetLocation()));
                    _numOfBooks = _books.Count();
                }
                else
                {
                    Exception ex = new Exception("Can't add a null book or a book that already exists");
                    throw ex;
                }
            }
           
        }

        /// <summary>
        /// Removes a book from the catalog (only a valid librarian has the ability to do this)
        /// </summary>
        /// <param name="librarian"></param>
        /// <param name="book"></param>
        public void RemoveABook(Librarian librarian, Book book)
        {
            if(StaffAuthorized(librarian))
            {
                if(book != null && _books.Any(x => x.GetIsbn() == book.GetIsbn()))
                {
                    _books.Remove(book);
                    _numOfBooks = _books.Count();
                }
                else
                {
                    Exception ex = new Exception("Can't remove a null book or a book that does not exist");
                    throw ex;
                }
            }
           
        }

        /// <summary>
        /// Validates a librarian
        /// </summary>
        /// <param name="librarian"></param>
        /// <returns></returns>
        public bool StaffAuthorized(Librarian librarian)
        {
            if(librarian.GetId() == _staffPassKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Allows student to check out a book
        /// </summary>
        /// <param name="student"></param>
        /// <param name="book"></param>
       public void CheckOutBook(Person person, Book book)
       {
            if(book != null && person != null && _books.Any(x => x.GetIsbn() == book.GetIsbn()) && !person.ReachedRentLimit())
            {
                foreach(Book b in _books)
                {
                    if(b.IsbnMatch(book))
                    {
                        b.MarkCheckOut(person);
                    }
                }
            }
       }



        public void ReturnBook(Person person, Book book)
        {
            if(book != null && person != null && _books.Any(x => x.GetIsbn() == book.GetIsbn()))
            {
                foreach(Book b in _books)
                {
                    if(b.IsbnMatch(book))
                    {
                        b.MarkReturned();
                    }
                }
            }
        }

 

        public void PrintBooks()
        {
            Console.WriteLine("Printing all Books in Catalog");
            foreach(Book b in _books)
            {
                b.PrintBookInfo();
            }
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }
    }
}
