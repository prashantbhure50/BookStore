using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Database
{
    public class Books
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookAurthor { get; set; }
        public string BookCategory { get; set; }
        public string BookLanguage { get; set; }

        public static void ToList()
        {
            throw new NotImplementedException();
        }
    }
}
