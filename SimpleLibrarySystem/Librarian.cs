using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Librarian
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private long _ssn;
        private long _employeeId;
        
        /// <summary>
        /// Creates a libraraian object (constructor)
        /// </summary>
        public Librarian()
        {
            
        }

        /// <summary>
        /// Creates a custom librarian object where you can set all the fields (constructor)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="ssn"></param>
        /// <param name="employeeId"></param>
        public Librarian(string firstName, string lastName, string address, long ssn, long employeeId)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _ssn = ssn;
            _employeeId = employeeId;
            
        }

        /// <summary>
        /// Returns the employeeId of the librarian object
        /// </summary>
        /// <returns></returns>
        public long GetId()
        {
            return _employeeId;
        }

        /// <summary>
        /// Allows the librarian to add a book to a catalog
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="book"></param>
        public void AddABook(Catalog catalog, Book book)
        {
            catalog.AddABook(this, book);
        }

        /// <summary>
        /// Allows the librarian to remove a book from the catalog
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="book"></param>
        public void RemoveABook(Catalog catalog, Book book)
        {
            catalog.RemoveABook(this, book);
        }

        /// <summary>
        /// Prints the information on a specific librarian
        /// </summary>
        public void PrintLibrarianInfo()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Printing Librarian Info");
            Console.WriteLine("Name: " + _firstName + " " + _lastName);
            Console.WriteLine("Address: " + _address);
            Console.WriteLine("SSN: " + _ssn);
            Console.WriteLine("EmplyeeId: " + _employeeId);
        }
    
    }
}
