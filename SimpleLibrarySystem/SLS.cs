using SimpleLibrarySystem.LibaryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class SLS
    {
        public Catalog _catalog;
        public Librarian _librarian;
        public List<Student> _students;
        public List<Instructor> _instructors;


        /// <summary>
        /// Creates an SLS(Simple Library System) with an auto generated catalog, librarian, and students (constructor)
        /// </summary>
        /// <param name="populateLibrary">when set to true, the catalog is filled with random books</param>
        /// <param name="n">determines how many books we want generated</param>
        public SLS(bool populateLibrary, int n)
        {
            Random rand = new Random();
            int employeeId = rand.Next(1, 1000);
            _catalog = new Catalog(employeeId);
            _librarian = new Librarian("Aric", "Campbell", "100 Dogwood Drive, Williamsburg VA", 1234567, employeeId);
            _students = new List<Student>();
            _instructors = new List<Instructor>();
            if (populateLibrary)
            {
                List<Book> books = GetListOfRandomBooks(n);
                List<EBook> eBooks = GetListOfRandomEBooks(n);
                List<Journal> journals = GetListOfRandomJournals(n);
                List<Magazine> magazines = GetListOfRandomMagazines(n);

                for(int i = 0; i <  n; i++)
                {
                    _catalog.AddAnItem(_librarian, books.ElementAt(i));
                    _catalog.AddAnItem(_librarian, eBooks.ElementAt(i));
                    _catalog.AddAnItem(_librarian, journals.ElementAt(i));
                    _catalog.AddAnItem(_librarian, magazines.ElementAt(i));
                }

                _students = GetListOfRandomStudents(n);
                _instructors = GetListOfRandomInstructors(n);
            }
            
            //_numOfStudents = _students.Count();
        }

        /// <summary>
        /// Creates a SLS(Simple Library System) with a catalog, librarian, & students (constructor)
        /// </summary>
        /// <param name="librarian">librarian object to be the SLS's only librarian that can add and remove books</param>
        public SLS(Librarian librarian)
        {
            _catalog = new Catalog(librarian.GetId());
            _librarian = librarian;
            _students = new List<Student>();
            _instructors = new List<Instructor>();
        }

        /// <summary>
        /// Creates a SLS(Simple Library System) with a catalog, librarian, & students (constructor)
        /// </summary>
        /// <param name="librarian">librarian object to be the SLS's only librarian that can add and remove books</param>
        /// <param name="students">student object to be the SLS's students</param>
        /// <param name="books">list of books for the SLS's catalog</param>
        public SLS(Librarian librarian, List<Student> students, List<Instructor> instructors, List<LibraryItem> items)
        {
            _catalog = new Catalog(librarian.GetId());
            foreach(LibraryItem i in items)
            {
                _catalog.AddAnItem(librarian, i);
            }
            _librarian = librarian;
            _students = students;
            _instructors = instructors;
        }


        /// <summary>
        /// Adds a student to the SLS
        /// </summary>
        /// <param name="student"></param>
        public void AddAStudent(Student student)
        {
            _students.Add(student);
        }

        /// <summary>
        /// Removes a student from the SLS
        /// </summary>
        /// <param name="student"></param>
        public void RemoveAStudent(Student student)
        {
            if(_students.Contains(student))
            {
                _students.Remove(student);
            }
        }

        /// <summary>
        /// Returns how many students are in the SLS
        /// </summary>
        /// <returns></returns>
        public int NumberOfStudents
        {
            get
            {
                return _students.Count;
            }
        }

        public int NumberOfInstructors
        {
            get
            {
                return _instructors.Count;
            }
        }

        /// <summary>
        /// Generates a list of random students and adds them to the Students list
        /// </summary>
        /// <param name="n">how many students we want to generate</param>
        public void GenerateRandomStudents(int n)
        {
            for(int i = 0; i < n; i++)
            {
                _students.Add(new Student("Student" + i, "lastName", "123 Street", i.ToString(), (2000 + i).ToString(), "S" + (3000 + i).ToString()));
            }
        }

        public void GenerateRandomInstructors(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _instructors.Add(new Instructor("Instructor" + i, "lastName", "123 Street", i.ToString(), (2000 + i).ToString(), "E" + (3000 + i).ToString()));
            }
        }

        /// <summary>
        /// Generates a list of random books and adds them to the catalog
        /// </summary>
        /// <param name="n">how many books we want to generate</param>
        public void GenerateRandomBooks(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _catalog.AddAnItem(this._librarian, new Book("Book" + i, "author", (1000 + i).ToString(), BookType.art, BookLocation.firstFloor));
            }
        }

        public void GenerateRandomEBooks(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _catalog.AddAnItem(this._librarian, new EBook("EBook" + i, "author", (1000 + i).ToString(), BookType.art, "URL"+ i + ".com"));
            }
        }

        public void GenerateRandomJournals(int n)
        {
            List<string> authors = new List<string>();
            for(int i = 0; i < 5; i++)
            {
                authors.Add("Author " + i);
            }

            for (int i = 0; i < n; i++)
            {
                _catalog.AddAnItem(this._librarian, new Journal("Journal" + i, authors, i));
            }
        }

        public void GenerateRandomMagazines(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _catalog.AddAnItem(this._librarian, new Magazine("Magazine" + i, "magazine info " + i));
            }
        }

        /// <summary>
        /// Creates a list of random students and returns them
        /// </summary>
        /// <param name="n">how many students we want</param>
        /// <returns></returns>
        public List<Student> GetListOfRandomStudents(int n)
        {
            List<Student> students = new List<Student>();
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                students.Add(new Student("Student" + i, "lastName", "123 Street", i.ToString(), (2000 + i).ToString(), "S" + (3000 + i).ToString()));
            }

            return students;
        }

        public List<Instructor> GetListOfRandomInstructors(int n)
        {
            List<Instructor> instructors = new List<Instructor>();
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                instructors.Add(new Instructor("Instructor" + i, "lastName", "123 Street", i.ToString(), (2000 + i).ToString(), "E" + (3000 + i).ToString()));
            }

            return instructors;
        }

        /// <summary>
        /// Generates a list of random books and returns them
        /// </summary>
        /// <param name="n">how many books we want</param>
        /// <returns></returns>
        public List<Book> GetListOfRandomBooks(int n)
        {
            Book b;
            List<Book> books = new List<Book>();
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                books.Add(new Book("Book" + i, "author", (1000 + i).ToString(), BookType.art, BookLocation.firstFloor));
            }

            return books;
        }

        public List<EBook> GetListOfRandomEBooks(int n)
        {
            List<EBook> Ebooks = new List<EBook>();
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                Ebooks.Add(new EBook("EBook" + i, "author", (1000 + i).ToString(), BookType.art, "genericUrl" + n + ".com"));
            }

            return Ebooks;

        }

        public List<Journal> GetListOfRandomJournals(int n)
        {
            List<Journal> Journals = new List<Journal>();
            List<string> Authors = new List<string>();
            for(int i = 0; i < 5; i++)
            {
                Authors.Add("Author " + i);
            }
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                Journals.Add(new Journal("Book" + i, Authors, i));
            }

            return Journals;
        }

        public List<Magazine> GetListOfRandomMagazines(int n)
        {
            List<Magazine> Magazines = new List<Magazine>();
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                Magazines.Add(new Magazine("Magazine" + i, "info " + i));
            }

            return Magazines;
        }


        /// <summary>
        /// Returns the list of students in the SLS
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public List<Instructor> GetAllInstructors()
        {
            return _instructors;
        }

    }
}
