using SimpleLibrarySystem.LibaryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Catalog
    {
        private List<LibraryItem> _libraryItems;
        //private long _numOfBooks;
        private long _staffPassKey;

        /// <summary>
        /// Creates a catalog with no pass key (constructor)
        /// </summary>
        public Catalog()
        {
            _libraryItems = new List<LibraryItem>();
            //_numOfBooks = 0;
        }

        /// <summary>
        /// Creates a catalog with a pass key that only allows a librarian with an identical employeeId to add and remove books (constructor)
        /// </summary>
        /// <param name="key"></param>
        public Catalog(long key)
        {
            _libraryItems = new List<LibraryItem>();
            //_numOfBooks = 0;
            _staffPassKey = key;
        }

        /// <summary>
        /// Adds a book to the catalog (only a valid librarian has the ability to do this)
        /// </summary>
        /// <param name="librarian"></param>
        /// <param name="book"></param>
        public void AddAnItem(Librarian librarian, LibraryItem item)
        {
            if(StaffAuthorized(librarian))
            {
                if(item != null)
                {
                    if (item is EBook)
                    {
                        EBook eb = (EBook)item;

                        _libraryItems.Add(new EBook(eb.Title, eb.Author, eb.ISBN, eb.Type, eb.URL));
                    }
                    else
                    {
                        if (item is Book)
                        {
                            Book b = (Book)item;

                            _libraryItems.Add(new Book(b.Title, b.Author, b.ISBN, b.Type, b.Location));
                        }
                        else if (item is Journal)
                        {
                            Journal j = (Journal)item;

                            _libraryItems.Add(new Journal(j.Title, j.Authors, j.Edition));
                        }
                        else if (item is Magazine)
                        {
                            Magazine m = (Magazine)item;

                            _libraryItems.Add(new Magazine(m.Title, m.MagazineInfo));
                        }
                    }
                }
                else
                {
                    Exception ex = new Exception("Can't add a null book or a book that already exists");
                    throw ex;
                }
            }


           
        }

        public void AddAClone(Librarian librarian, LibraryItem clone)
        {
            if (StaffAuthorized(librarian))
            {
                if (clone != null)
                {
                    _libraryItems.Add(clone);
                }
            }
        }

        public int NumOfItems
        {
            get
            {
                if(_libraryItems != null)
                {
                    return _libraryItems.Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Removes a book from the catalog (only a valid librarian has the ability to do this)
        /// </summary>
        /// <param name="librarian"></param>
        /// <param name="book"></param>
        public void RemoveAnItem(Librarian librarian, LibraryItem item)
        {
            if(StaffAuthorized(librarian))
            {
                if(item != null && _libraryItems.Any(x => x.ID == item.ID))
                {
                    _libraryItems.Remove(item);
                }
                else
                {
                    Exception ex = new Exception("Can't remove a null book or a book that does not exist");
                    throw ex;
                }
            }
        }

        public bool ItemExists(LibraryItem item)
        {
            foreach(LibraryItem i in _libraryItems)
            {
                if(i.ID == item.ID)
                {
                    return true;
                }
            }

            return false;
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
       public void CheckOutItem(Person person, LibraryItem item)
       {
            if(item != null && person != null && _libraryItems.Any(x => x.ID == item.ID) && !person.ReachedRentLimit())
            {
                foreach(LibraryItem i in _libraryItems)
                {
                    if(i.ID == item.ID)
                    {
                        i.MarkCheckedOut(person);
                    }
                }
            }
       }



        public void ReturnAnItem(Person person, LibraryItem item)
        {
            if(item != null && person != null && _libraryItems.Any(x => x.ID == item.ID))
            {
                foreach(LibraryItem i in _libraryItems)
                {
                    if(i.ID == item.ID)
                    {
                        i.MarkReturned();
                    }
                }
            }
        }

 

        public void PrintItems()
        {
            Console.WriteLine("Printing all items in Catalog");
            foreach(LibraryItem item in _libraryItems)
            {
                item.PrintItemInfo();
            }
        }

        public void PrintBooks()
        {
            Console.WriteLine("Printing all the books in the Catalog");
            foreach(LibraryItem item in _libraryItems)
            {
                if(item is Book)
                {
                    item.PrintItemInfo();
                }
            }
        }

        public void PrintEBooks()
        {
            Console.WriteLine("Printing all the Ebooks in the Catalog");
            foreach (LibraryItem item in _libraryItems)
            {
                if (item is EBook)
                {
                    item.PrintItemInfo();
                }
            }
        }

        public void PrintJournals()
        {
            Console.WriteLine("Printing all the journals in the Catalog");
            foreach (LibraryItem item in _libraryItems)
            {
                if (item is Journal)
                {
                    item.PrintItemInfo();
                }
            }
        }

        public void PrintMagazines()
        {
            Console.WriteLine("Printing all the magazines in the Catalog");
            foreach (LibraryItem item in _libraryItems)
            {
                if (item is Magazine)
                {
                    item.PrintItemInfo();
                }
            }
        }

        public List<LibraryItem> GetAllItems()
        {
            return _libraryItems;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            foreach(LibraryItem item in _libraryItems)
            {
                if (!(item is EBook))
                {
                    if (item is Book)
                    {
                        books.Add((Book)item);
                    }
                }
            }

            return books;
        }

        public List<EBook> GetAllEBooks()
        {
            List<EBook> EBooks = new List<EBook>();
            foreach (LibraryItem item in _libraryItems)
            {
                if (item is EBook)
                {
                    EBooks.Add((EBook)item);
                }
            }
            return EBooks;
        }

        public List<Journal> GetAllJournals()
        {
            List<Journal> Journals = new List<Journal>();
            foreach(LibraryItem item in _libraryItems)
            {
                if(item is Journal)
                {
                    Journals.Add((Journal)item);
                }
            }
            return Journals;
        }

        public List<Magazine> GetAllMagazines()
        {
            List<Magazine> magazines = new List<Magazine>();
            foreach(LibraryItem item in _libraryItems)
            {
                if(item is Magazine)
                {
                    magazines.Add((Magazine)item);
                }
            }
            return magazines;
        }
    }
}
