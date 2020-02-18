using SimpleLibrarySystem.LibaryItems;
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
        private LibraryItem[] _itemsCheckedOut;
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
            _itemsCheckedOut = new LibraryItem[RentLimit];
        }

        /// <summary>
        /// Allows instructor to check out a book from a catalog
        /// </summary>
        /// <param name="book"></param>
        /// <param name="catalog"></param>
        public void CheckOutItem(LibraryItem item, Catalog catalog)
        {
            if (!ReachedRentLimit())
            {
                for (int i = 0; i < _itemsCheckedOut.Length; i++)
                {
                    if (_itemsCheckedOut[i] == null)
                    {
                        catalog.CheckOutItem(this, item);
                        _itemsCheckedOut[i] = item;
                        i = _itemsCheckedOut.Length;
                    }
                }
            }
            else
            {
                if(RentLimit == 3)
                {
                    throw new Exception("Student has too many items Being Rented");
                }
                else if(RentLimit == 5)
                {
                    throw new Exception("Instructor has too many items Being Rented");
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
        public void ReturnItem(LibraryItem item, Catalog catalog)
        {
            if (item != null && catalog != null && _itemsCheckedOut.Any(x => x != null && x.ID == item.ID))
            {
                for (int i = 0; i < _itemsCheckedOut.Length; i++)
                {
                    if (_itemsCheckedOut[i] != null && _itemsCheckedOut[i].ID == item.ID)
                    {
                        catalog.ReturnAnItem(this, item);
                        _itemsCheckedOut[i] = null;
                        i = _itemsCheckedOut.Length;
                    }
                }
            }
        }

        public LibraryItem[] GetItemsCheckedOut()
        {
            return _itemsCheckedOut;
        }

        /// <summary>
        /// Returns the array of books that a specific instructor has checked out
        /// </summary>
        /// <returns></returns>
        public Book[] GetBooksCheckedOut()
        {
            Book[] books = new Book[NumOfBooksCheckedOut];
            int i = 0;
            foreach(LibraryItem item in _itemsCheckedOut)
            {
                if(item is Book)
                {
                    books[i] = (Book)item;
                    i++;
                }
            }
            return books;
        }

        public EBook[] GetEBooksCheckedOut()
        {
            EBook[] Ebooks = new EBook[NumOfEBooksCheckedOut];
            int i = 0;
            foreach (LibraryItem item in _itemsCheckedOut)
            {
                if (item is EBook)
                {
                    Ebooks[i] = (EBook)item;
                    i++;
                }
            }
            return Ebooks;
        }

        public Journal[] GetJournalsCheckedOut()
        {
            Journal[] journals = new Journal[NumOfJournalsCheckedOut];
            int i = 0;
            foreach (LibraryItem item in _itemsCheckedOut)
            {
                if (item is Journal)
                {
                    journals[i] = (Journal)item;
                    i++;
                }
            }
            return journals;
        }

        public Magazine[] GetMagazinesCheckedOut()
        {
            Magazine[] magazines = new Magazine[NumOfMagazinesCheckedOut];
            int i = 0;
            foreach (LibraryItem item in _itemsCheckedOut)
            {
                if (item is Magazine)
                {
                    magazines[i] = (Magazine)item;
                    i++;
                }
            }
            return magazines;
        }



        public void UserInfo()
        {
            Console.WriteLine("-----------------------------");
            if (_itemsCheckedOut.Length == 3)
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
        public void PrintItemsCheckedOut()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Printing Items Checked Out");
            foreach (LibraryItem item in _itemsCheckedOut)
            {
                if (item != null)
                {
                    item.PrintItemInfo();
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
                for (int i = 0; i < _itemsCheckedOut.Length; i++)
                {
                    if (_itemsCheckedOut[i] != null && _itemsCheckedOut[i] is Book)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int NumOfEBooksCheckedOut
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _itemsCheckedOut.Length; i++)
                {
                    if (_itemsCheckedOut[i] != null && _itemsCheckedOut[i] is EBook)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int NumOfJournalsCheckedOut
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _itemsCheckedOut.Length; i++)
                {
                    if (_itemsCheckedOut[i] != null && _itemsCheckedOut[i] is Journal)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int NumOfMagazinesCheckedOut
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _itemsCheckedOut.Length; i++)
                {
                    if (_itemsCheckedOut[i] != null && _itemsCheckedOut[i] is Magazine)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int NumOfItemsCheckedOut
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _itemsCheckedOut.Length; i++)
                {
                    if (_itemsCheckedOut[i] != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
