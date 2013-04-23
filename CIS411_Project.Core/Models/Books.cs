using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS411_Project.Core.Models
{
    public class Books
    {
        public decimal BOOK_ID { get; set; }

        public string BOOK_TITLE { get; set; }

        public string BOOK_DESC { get; set; }

        public string BOOK_AUTHOR { get; set; }

        public Nullable<decimal> BOOK_EDITION { get; set; }

        public string BOOK_PUBLISHER { get; set; }

        public Nullable<decimal> ISBN10 { get; set; }

        public Nullable<decimal> ISBN13 { get; set; }

        public decimal CONDITION_ID { get; set; }

        public decimal CATEGORY_ID { get; set; }

        public decimal USER_ID { get; set; }

        public Nullable<double> BOOK_PRICE { get; set; }

        public Nullable<DateTime> CREATED_TIMESTAMP { get; set; }


    }
}