using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem
{
    public class Journal : LibraryItem
    {
        private List<string> _authors;
        private int _edition;

       public Journal(string title, List<string> authors, int edition)
       : base(title, false)
        {
            Authors = authors;
            Edition = edition;
        }

        public List<string> Authors
        {
            get
            {
                if(_authors != null)
                {
                    return _authors;
                }
                else
                {
                    return new List<string>();
                }
            }
            set
            {
                if(value != null)
                {
                    _authors = value;
                }
            }
        }

        public int Edition
        {
            get
            {
                if(_edition > -1)
                {
                    return _edition;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if(value > -1)
                {
                    _edition = value;
                }
            }
        }

        public override object Clone()
        {
            return new Journal(this.Title, this.Authors, this.Edition);
        }

        public override void MarkCheckedOut(Person p)
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
                throw new Exception("Journal is already checked out");
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
                ReturnDate = CheckoutDate.AddMonths(2);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddMonths(2);
            }
            else
            {
                throw new Exception("Journal is already checked out");
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
                throw new Exception("Journal is already checked out");
            }
        }
        

        public override void PrintItemInfo()
        {
            int i = 1;
            Console.WriteLine("-----------------Journal Info-------------------------");
            Console.WriteLine("Id: " + ID);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Edition: " + Edition);
            foreach(string author in Authors)
            {
                Console.WriteLine("Author " + i + ": " + author);
                i++;
            }
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

        public override decimal ChargeFee()
        {
            decimal daysInDecimal = 0;
            decimal lateFee = 0;
            decimal Dailycharge = .5M;

            if (DateTime.Today < ReturnDate)
            {
                TimeSpan variable = DateTime.Today - this.ReturnDate;
                double days = variable.TotalDays;
                daysInDecimal = decimal.Parse(days.ToString());
                lateFee = Dailycharge * daysInDecimal;
            }

            return lateFee;
        }

        public void Update(Guid id, string title, List<string> authors, int edition)
        {
            base.Update(id, title);
            Authors = authors;
            Edition = edition;
        }
    }
}
