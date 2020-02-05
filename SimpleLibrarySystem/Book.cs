using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public enum BookType
    {
        science = 0,
        art = 1,
        math = 2,
        history = 3,
        education = 4
    }

    public enum BookLocation
    {
        firstFloor = 0,
        secondFloor = 1,
        thirdFloor = 2
    }

    public class Book
    {
        private long _bookId;
        private string _title;
        private string _author;
        private string _isbn;
        private BookType _type;
        private BookLocation _location;
        private bool _checkedOut;
        private DateTime _checkoutDate;
        private DateTime _returnDate;

        /// <summary>
        /// Creates a book object (constructor)
        /// </summary>
        public Book()
        {

        }

        /// <summary>
        /// Creates a book object where all the fields can be custom set (constructor)
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="isbn"></param>
        /// <param name="type"></param>
        /// <param name="location"></param>
        public Book(long bookId, string title, string author, string isbn, BookType type, BookLocation location)
        {
            _bookId = bookId;
            _title = title;
            _author = author;
            _isbn = isbn;
            _type = type;
            _location = location;
            _checkedOut = false;
        }

        public DateTime CheckoutDate
        {
            set
            {
                _checkoutDate = value;
            }
            get
            {
                return _checkoutDate;
            }
        }

        public DateTime ReturnDate
        {
            set
            {
                _returnDate = value;
            }
            get
            {
                return _returnDate;
            }
        }

        /// <summary>
        /// Returns the BookID
        /// </summary>
        /// <returns></returns>
        public long GetBookId()
        {
            return _bookId;
        }

        /// <summary>
        /// Returns the title
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return _title;
        }

        public string GetAuthor()
        {
            return _author;
        }

        /// <summary>
        /// Returns the Type
        /// </summary>
        /// <returns></returns>
        public BookType GetType()
        {
            return _type;
        }

        /// <summary>
        /// Returns the location
        /// </summary>
        /// <returns></returns>
        public BookLocation GetLocation()
        {
            return _location;
        }

        /// <summary>
        /// Returns whether the book is checked out or not
        /// </summary>
        /// <returns></returns>
        public bool IsCheckedOut()
        {
            return _checkedOut;
        }

        /// <summary>
        /// Marks the book as checked out
        /// </summary>
        public void MarkCheckOut()
        {
            if(!_checkedOut)
            {
                _checkedOut = true;
                //CheckoutDate = DateTime.Today;
                
                
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public void MarkCheckOut(Person p)
        {
            if (!_checkedOut)
            {
                _checkedOut = true;
                if(p.RentLimit == 3)
                {
                    CheckoutDate = DateTime.Today;
                    ReturnDate = CheckoutDate.AddMonths(1);
                }
                else if(p.RentLimit == 5)
                {
                    CheckoutDate = DateTime.Today;
                    ReturnDate = CheckoutDate.AddMonths(2);
                }
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public void MarkCheckOut(Student s)
        {
            if (!_checkedOut)
            {
                _checkedOut = true;
                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(1);
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public void MarkCheckOut(Instructor i)
        {
            if (!_checkedOut)
            {
                _checkedOut = true;
                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(2);
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        /// <summary>
        /// Marks the book as returned
        /// </summary>
        public void MarkReturned()
        {
            if (_checkedOut)
            {
                _checkedOut = false;
                CheckoutDate = new DateTime();
                ReturnDate = new DateTime();
            }
            else
            {
                throw new System.InvalidOperationException();
            }
        }

        /// <summary>
        /// Prints the information on a specific book
        /// </summary>
        public void PrintBookInfo()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("BookId: " + _bookId);
            Console.WriteLine("Title: " + _title);
            Console.WriteLine("Author: " + _author);
            Console.WriteLine("ISBN: " + _isbn);
            Console.WriteLine("Type: " + _type);
            Console.WriteLine("Location: " + _location);
            Console.WriteLine("Checked Out: " + _checkedOut);
            if(_checkedOut)
            {
                Console.WriteLine("Checkout Date: " + CheckoutDate.ToShortDateString());
                Console.WriteLine("Return Date: " + ReturnDate.ToShortDateString());
            }
            Console.WriteLine("------------------------------------------");
        }

        /// <summary>
        /// Returns the isbn
        /// </summary>
        /// <returns></returns>
        public string GetIsbn()
        {
            return _isbn;
        }

        /// <summary>
        /// Checkes to see if an isbn passed in matches this books isbn
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsbnMatch(Book b)
        {
            return _isbn == b.GetIsbn();
        }
    }

    
}
