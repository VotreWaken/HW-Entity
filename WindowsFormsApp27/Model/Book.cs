using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEx.Model
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int Id_Author { get; set; }
        public int Id_Press { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return "Name: " + Name.ToString() + " Pages: " + Pages.ToString() + " " + "Year Press:" + YearPress;
        }

    }
}
