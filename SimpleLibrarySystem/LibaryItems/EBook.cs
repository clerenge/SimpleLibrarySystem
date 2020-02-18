using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem.LibaryItems
{
    public class EBook : Book
    {
        private string _url;

        public EBook(string title, string author, string isbn, BookType type, string url)
        : base(title, author, isbn, type, BookLocation.online)
        {
            URL = url;
        }

        public string URL
        {
            get
            {
                if(!string.IsNullOrEmpty(_url))
                {
                    return _url;
                }
                else
                {
                    return "URL is nill";
                }
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _url = value;
                }
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
                ReturnDate = CheckoutDate.AddMonths(3);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(3);
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public override void MarkCheckedOut(Person p)
        {
            if (!CheckedOut)
            {
                CheckedOut = true;

                //if you want book overdue
                /*
                CheckoutDate = DateTime.Today.AddYears(-1);
                ReturnDate = CheckoutDate.AddMonths(3);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(3);
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
                ReturnDate = CheckoutDate.AddMonths(3);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(3);
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public override object Clone()
        {
            BookType type;
            if (this.Type == BookType.art)
            {
                type = BookType.art;
            }
            else if (this.Type == BookType.education)
            {
                type = BookType.education;
            }
            else if (this.Type == BookType.history)
            {
                type = BookType.history;
            }
            else if (this.Type == BookType.math)
            {
                type = BookType.math;
            }
            else
            {
                type = BookType.science;
            }

            return new EBook(this.Title.ToString(), this.Author.ToString(), this.ISBN.ToString(), type, this.URL.ToString());
        }

        public void Update(Guid id, string title, string author, string isbn, BookType type, BookLocation location, string url)
        {
            base.Update(id, title);
            Author = author;
            ISBN = isbn;
            Type = type;
            Location = location;
            URL = url;
        }

        public override void PrintItemInfo()
        {
            Console.WriteLine("-----------------EBook Info-------------------------");
            Console.WriteLine("Id: " + ID);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Location: " + Location);
            Console.WriteLine("URL: " + URL);
            Console.WriteLine("Checked Out: " + CheckedOut);
            if (CheckedOut)
            {
                Console.WriteLine("Checkout Date: " + CheckoutDate.ToShortDateString());
                Console.WriteLine("Return Date: " + ReturnDate.ToShortDateString());
                if (ChargeFee() > 0)
                {
                    Console.WriteLine("Overdue late fee: $" + ChargeFee());
                }
            }
            
            Console.WriteLine("------------------------------------------");
        }
    }
}
