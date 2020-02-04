using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Student
    {
        private string _firstName;
        private string _lastName;
        private long _wNum;
        private long _ssn;
        private Book[] _booksCheckedOut;
        private int _numOfBooksCheckedOut;

        /// <summary>
        /// Initializes a student object with fill-ins for personal information (constructor)
        /// </summary>
        public Student()
        {
            _firstName = "John";
            _lastName = "Doe";
            _wNum = 0;
            _ssn = 0;
            _booksCheckedOut = new Book[3];
            _numOfBooksCheckedOut = 0;
        }

        /// <summary>
        /// Initializes a student that can be custom made (constructor)
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="wNum"></param>
        /// <param name="ssn"></param>
        public Student(string fName, string lName, long wNum, long ssn)
        {
            _firstName = fName;
            _lastName = lName;
            _wNum = wNum;
            _ssn = ssn;
            _booksCheckedOut = new Book[3];
            _numOfBooksCheckedOut = 0;
        }

        /// <summary>
        /// Checks to see if the student has checked out 3 or more books (book rental limit)
        /// </summary>
        /// <returns></returns>
        public bool ReachedRentLimit()
        {
            if(_numOfBooksCheckedOut >= 3)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Allows student to check out a book from a catalog
        /// </summary>
        /// <param name="book"></param>
        /// <param name="catalog"></param>
        public void CheckOutBook(Book book, Catalog catalog)
        {
            if(!ReachedRentLimit())
            {
                for (int i = 0; i < _booksCheckedOut.Length; i++)
                {
                    if (_booksCheckedOut[i] == null)
                    {
                        catalog.CheckOutBook(this, book);
                        book.MarkCheckOut();
                        _booksCheckedOut[i] = book;
                        _numOfBooksCheckedOut++;
                        i = _booksCheckedOut.Length;
                    }
                }
            }
            else
            {
                throw new Exception("Student has too many Books Being Rented");
            }
        }

        /// <summary>
        /// Allows a student to return a book to a catalog
        /// </summary>
        /// <param name="book"></param>
        /// <param name="catalog"></param>
        public void ReturnBook(Book book, Catalog catalog)
        {
            if(book != null && catalog != null && _booksCheckedOut.Any(x=> x.GetIsbn() == book.GetIsbn()))
            {
                for(int i = 0; i < _booksCheckedOut.Length; i++)
                {
                    if(_booksCheckedOut[i] != null && _booksCheckedOut[i].GetIsbn() == book.GetIsbn())
                    {
                        catalog.ReturnBook(this, book);
                        _booksCheckedOut[i] = null;
                        _numOfBooksCheckedOut--;
                        i = _booksCheckedOut.Length;
                        
                    }
                }
            }
        }

        /// <summary>
        /// Prints the information on a specific student object
        /// </summary>
        public void PrintStudentInfo()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Student Info");
            Console.WriteLine("Name: " + _firstName + " " + _lastName);
            Console.WriteLine("W#: " + _wNum);
            Console.WriteLine("SSN: " + _ssn);
            Console.WriteLine("-----------------------------");
        }

        /// <summary>
        /// Prints out all the books a student has checked out
        /// </summary>
        public void PrintBooksCheckedOut()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Printing Books Checked Out");
            foreach(Book b in _booksCheckedOut)
            {
                if(b != null)
                {
                    b.PrintBookInfo();
                }
                
            }
        }
        
        /// <summary>
        /// Returns the array of books that a specific student has checked out
        /// </summary>
        /// <returns></returns>
        public Book[] GetBooksCheckedOut()
        {
            return _booksCheckedOut;
        }


    }
}
