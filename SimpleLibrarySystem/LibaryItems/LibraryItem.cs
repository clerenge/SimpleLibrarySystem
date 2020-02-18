using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{

    public abstract class LibraryItem : ICloneable, ILateFee
    {
        private Guid _id;
        private string _title;
        private bool _checkedOut;
        private DateTime _checkoutDate;
        private DateTime _returnDate;
        Random rand = new Random();

        public LibraryItem(string title, bool checkedOut)
        {
            ID = Guid.NewGuid();
            Title = title;
            CheckedOut = checkedOut;
            CheckoutDate = new DateTime();
            ReturnDate = new DateTime();
        }

        public Guid ID
        {
            get
            {
                return _id;
            }

            set
            {
                if(value != null)
                {
                    _id = value;
                }
            }
        }

        public string Title
        {
            get
            {
                if(!string.IsNullOrEmpty(_title))
                {
                    return _title;
                }
                else
                {
                    return "title is null";
                }
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _title = value;
                }
            }
        }

        public bool CheckedOut
        {
            get
            {
                return _checkedOut;
            }
            set
            {
                _checkedOut = value;
            }
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
        /// Marks the book as checked out
        /// </summary>
        public void MarkChecedkOut()
        {
            if (!CheckedOut)
            {
                CheckedOut = true;
            }
            else
            {
                throw new Exception("Book is already checked out, redirecting to main page");
            }
        }

        public abstract void MarkCheckedOut(Person p);

        public abstract void MarkCheckedOut(Student s);

        public abstract void MarkCheckedOut(Instructor i);

        public abstract void PrintItemInfo();

        public abstract object Clone();

        public abstract decimal ChargeFee();

        public virtual void Update(Guid id, string title)
        {
            ID = id;
            Title = title;
        }

        /// <summary>
        /// Marks the book as returned
        /// </summary>
        public void MarkReturned()
        {
            if (_checkedOut)
            {
                CheckedOut = false;
                CheckoutDate = new DateTime();
                ReturnDate = new DateTime();
            }
            else
            {
                throw new System.InvalidOperationException();
            }
        }

       
    }
}
