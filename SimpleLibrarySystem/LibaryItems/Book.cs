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
        thirdFloor = 2,
        online = 3
    }

    public class Book : LibraryItem
    {
        //private long _bookId;
        //private string _title;
        //private bool _checkedOut;
        private string _author;
        private string _isbn;
        private BookType _type;
        private BookLocation _location;
        //private DateTime _checkoutDate;
        //private DateTime _returnDate;

        /// <summary>
        /// Creates a book object (constructor)
        /// </summary>
        public Book()
            : base("poop", false)
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
        public Book(string title, string author, string isbn, BookType type, BookLocation location)
        : base(title, false)
        {
            Author = author;
            ISBN = isbn;
            Type = type;
            Location = location;
        }

       
        /*
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
        */
        public string Author
        {
            get
            {
                if(!string.IsNullOrEmpty(_author))
                {
                    return _author;
                }
                else
                {
                    return "author is nill";
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _author = value;
                }
            }
        }

        public string ISBN
        {
            get
            {
                if(!string.IsNullOrEmpty(_isbn))
                {
                    return _isbn;
                }
                else
                {
                    return "ISBN is nill";
                }
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _isbn = value;
                }
            }
        }

        public BookType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public BookLocation Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }


        public override void MarkCheckedOut(Person p)
        {
            if (!CheckedOut)
            {
                CheckedOut = true;
                if(p.RentLimit == 3)
                {
                    //if you want book overdue
                    /*
                    CheckoutDate = DateTime.Today.AddYears(-1);
                    ReturnDate = CheckoutDate.AddMonths(1);
                    */

                    CheckoutDate = DateTime.Today;
                    ReturnDate = CheckoutDate.AddMonths(1);
                }
                else if(p.RentLimit == 5)
                {
                    //if you want book overdue
                    /*
                    CheckoutDate = DateTime.Today.AddYears(-1);
                    ReturnDate = CheckoutDate.AddMonths(2);
                    */

                    CheckoutDate = DateTime.Today;
                    ReturnDate = CheckoutDate.AddMonths(2);
                }
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public override void MarkCheckedOut(Student s)
        {
            if (!CheckedOut)
            {
                CheckedOut = true;

                //if you want book overdue
                /*
                CheckoutDate = DateTime.Today.AddYears(-1);
                ReturnDate = CheckoutDate.AddMonths(1);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(1);
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public override void MarkCheckedOut(Instructor i)
        {
            if (!CheckedOut)
            {
                CheckedOut = true;

                //if you want book overdue
                /*
                CheckoutDate = DateTime.Today.AddYears(-1);
                ReturnDate = CheckoutDate.AddMonths(2);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(2);
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }


        /// <summary>
        /// Prints the information on a specific book
        /// </summary>
        public override void PrintItemInfo()
        {
            Console.WriteLine("-----------------Book Info-------------------------");
            Console.WriteLine("Id: " + ID);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Location: " + Location);
            Console.WriteLine("Checked Out: " + CheckedOut);
            if(CheckedOut)
            {
                Console.WriteLine("Checkout Date: " + CheckoutDate.ToShortDateString());
                Console.WriteLine("Return Date: " + ReturnDate.ToShortDateString());
                if (ChargeFee() > 0)
                {
                    Console.WriteLine("Overdue Late Fee: $" + ChargeFee());
                }
            }
            
            Console.WriteLine("------------------------------------------");
        }

   
        /// <summary>
        /// Checkes to see if an isbn passed in matches this books isbn
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsbnMatch(Book b)
        {
            return _isbn == b.ISBN;
        }

        public override object Clone()
        {
            BookType type;
            BookLocation location;
            if(this.Type == BookType.art)
            {
                type = BookType.art;
            }
            else if(this.Type == BookType.education)
            {
                type = BookType.education;
            }
            else if(this.Type == BookType.history)
            {
                type = BookType.history;
            }
            else if(this.Type == BookType.math)
            {
                type = BookType.math;
            }
            else
            {
                type = BookType.science;
            }
            

            if (this.Location == BookLocation.firstFloor)
            {
                location = BookLocation.firstFloor;
            }
            else if (this.Location == BookLocation.online)
            {
                location = BookLocation.online;
            }
            else if(this.Location == BookLocation.secondFloor)
            {
                location = BookLocation.secondFloor;
            }
            else
            {
                location = BookLocation.thirdFloor;
            }
            return new Book(this.Title.ToString(), this.Author.ToString(), this.ISBN.ToString(), type, location);
        }

        public override decimal ChargeFee()
        {
            decimal daysInDecimal = 0;


            if(DateTime.Today > this.ReturnDate)
            {
                TimeSpan variable = DateTime.Today - this.ReturnDate;
                double days = variable.TotalDays;
                daysInDecimal = decimal.Parse(days.ToString());

            }

            return daysInDecimal;
        }

        public void Update(Guid id, string title, string author, string isbn, BookType type, BookLocation location)
        {
            base.Update(id, title);
            Author = author;
            ISBN = isbn;
            Type = type;
            Location = location;
        }
    }

    
}
