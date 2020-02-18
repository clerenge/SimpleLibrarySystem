using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrarySystem.LibaryItems
{
    public class Magazine : LibraryItem
    {
        private string _magazineInfo;

        public Magazine(string title, string magazineInfo)
        :base(title, false)
        {
            MagazineInfo = magazineInfo;
        }

        public string MagazineInfo
        {
            get
            {
                if(!string.IsNullOrEmpty(_magazineInfo))
                {
                    return _magazineInfo;
                }
                else
                {
                    return "magazine info is nill";
                }
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _magazineInfo = value;
                }
            }
        }



        public override void MarkCheckedOut(Person p)
        {
            if (!CheckedOut)
            {
                CheckedOut = true;
                if (p.RentLimit == 3)
                {
                    //if you want book overdue
                    /*
                    CheckoutDate = DateTime.Today.AddYears(-1);
                    ReturnDate = CheckoutDate.AddDays(7);
                    */

                    CheckoutDate = DateTime.Today;
                    ReturnDate = CheckoutDate.AddDays(7);
                }
                else if (p.RentLimit == 5)
                {
                    //if you want book overdue
                    /*
                    CheckoutDate = DateTime.Today.AddYears(-1);
                    ReturnDate = CheckoutDate.AddDays(14);
                    */

                    CheckoutDate = DateTime.Today;
                    ReturnDate = CheckoutDate.AddDays(14);
                }
            }
            else
            {
                throw new Exception("Magazine is already checked out");
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
                ReturnDate = CheckoutDate.AddDays(7);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddDays(7);
            }
            else
            {
                throw new Exception("Magazine is already checked out");
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
                ReturnDate = CheckoutDate.AddDays(14);
                */

                CheckoutDate = DateTime.Today;
                ReturnDate = CheckoutDate.AddDays(14);
            }
            else
            {
                throw new Exception("Magazine is already checked out");
            }
        }

        public override object Clone()
        {
            return new Magazine(this.Title, this.MagazineInfo);
        }

        public override void PrintItemInfo()
        {
            Console.WriteLine("-----------------Magazine Info-------------------------");
            Console.WriteLine("Id: " + ID);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Magazine Info: " + MagazineInfo);
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

            if(DateTime.Today < ReturnDate)
            {
                TimeSpan variable = DateTime.Today - this.ReturnDate;
                double days = variable.TotalDays;
                daysInDecimal = decimal.Parse(days.ToString());
                lateFee = Dailycharge * daysInDecimal;
            }

            return lateFee;
        }

        public void Update(Guid id, string title, string magazineInfo)
        {
            base.Update(id, title);
            MagazineInfo = magazineInfo;
        }
    }
}
