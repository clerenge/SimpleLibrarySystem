using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _ssn;
        private string _wNum;
        private Book[] _booksCheckedOut;
        private int _rentLimit;

        public Person()
        {

        }

        public Person(string fName, string lName, string addy, string social, string wnum, int bookRentLimit)
        {
            FirstName = fName;
            LastName = lName;
            Address = addy;
            SSN = social;
            WNum = wnum;
            RentLimit = bookRentLimit;
            _booksCheckedOut = new Book[RentLimit];
        }

        /// <summary>
        /// Allows instructor to check out a book from a catalog
        /// </summary>
        /// <param name="book"></param>
        /// <param name="catalog"></param>
        public void CheckOutBook(Book book, Catalog catalog)
        {
            if (!ReachedRentLimit())
            {
                for (int i = 0; i < _booksCheckedOut.Length; i++)
                {
                    if (_booksCheckedOut[i] == null)
                    {
                        catalog.CheckOutBook(this, book);
                        //book.MarkCheckOut(this);
                        _booksCheckedOut[i] = book;
                        i = _booksCheckedOut.Length;
                    }
                }
            }
            else
            {
                if(RentLimit == 3)
                {
                    throw new Exception("Student has too many Books Being Rented");
                }
                else if(RentLimit == 5)
                {
                    throw new Exception("Instructor has too many Books Being Rented");
                }
                else
                {
                    throw new Exception("Something Strange is Happening...");
                }
                
            }
        }


        /// <summary>
        /// Allows an instructor to return a book to a catalog
        /// </summary>
        /// <param name="book"></param>
        /// <param name="catalog"></param>
        public void ReturnBook(Book book, Catalog catalog)
        {
            if (book != null && catalog != null && _booksCheckedOut.Any(x => x.GetIsbn() == book.GetIsbn()))
            {
                for (int i = 0; i < _booksCheckedOut.Length; i++)
                {
                    if (_booksCheckedOut[i] != null && _booksCheckedOut[i].GetIsbn() == book.GetIsbn())
                    {
                        catalog.ReturnBook(this, book);
                        _booksCheckedOut[i] = null;
                        i = _booksCheckedOut.Length;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the array of books that a specific instructor has checked out
        /// </summary>
        /// <returns></returns>
        public Book[] GetBooksCheckedOut()
        {
            return _booksCheckedOut;
        }

        public void UserInfo()
        {
            Console.WriteLine("-----------------------------");
            if (_booksCheckedOut.Length == 3)
            {
                Console.WriteLine("Student Info");
            }
            else
            {
                Console.WriteLine("Instructor Info");
            }
            Console.WriteLine("Name: " + FullName);
            Console.WriteLine("W#: " + WNum);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("SSN: " + SSN);
            Console.WriteLine("-----------------------------");
        }

        /// <summary>
        /// Prints out all the books an instructor has checked out
        /// </summary>
        public void PrintBooksCheckedOut()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Printing Books Checked Out");
            foreach (Book b in _booksCheckedOut)
            {
                if (b != null)
                {
                    b.PrintBookInfo();
                }

            }
        }

        /// <summary>
        /// Checks to see if the student has checked out 3 or more books (book rental limit)
        /// </summary>
        /// <returns></returns>
        public bool ReachedRentLimit()
        {
            if (NumOfBooksCheckedOut >= RentLimit)
            {
                return true;
            }
            return false;
        }

        public int RentLimit
        {
            set
            {
                if(value == 3 || value == 5)
                {
                    _rentLimit = value;
                }
            }
            get
            {
                if(_rentLimit == 3 || _rentLimit == 5)
                {
                    return _rentLimit;
                }
                else
                {
                    return 0;
                }
            }
        }


        public string FirstName
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
            }
            get
            {
                if (!string.IsNullOrEmpty(_firstName))
                {
                    return _firstName;
                }
                else
                {
                    return "No First Name Set";
                }

            }
        }

        public string LastName
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _lastName = value;
                }
            }
            get
            {
                if (!string.IsNullOrEmpty(_lastName))
                {
                    return _lastName;
                }
                else
                {
                    return "No Last Name Set";
                }

            }
        }

        public string FullName
        {
            get
            {
                if(!string.IsNullOrEmpty(_firstName) && !string.IsNullOrEmpty(_lastName))
                {
                    return _firstName + " " + _lastName;
                }
                else
                {
                    return "First name and last name not set";
                }
            }
        }

        public string Address
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _address = value;
                }
            }
            get
            {
                if (!string.IsNullOrEmpty(_ssn))
                {
                    return _address;
                }
                else
                {
                    return "No Address Set";
                }

            }
        }

        public string SSN
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _ssn = value;
                }
            }
            get
            {
                if (!string.IsNullOrEmpty(_ssn))
                {
                    return _ssn;
                }
                else
                {
                    return "No SSN Set";
                }

            }
        }

        public string WNum
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _wNum = value;
                }

            }
            get
            {
                if (!string.IsNullOrEmpty(_wNum))
                {
                    return _wNum;
                }
                else
                {
                    return "No W# Set";
                }
            }
        }

        public int NumOfBooksCheckedOut
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _booksCheckedOut.Length; i++)
                {
                    if (_booksCheckedOut[i] != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
