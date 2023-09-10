﻿using System.ComponentModel.DataAnnotations;

namespace Lab.EF.MVC.Models
{
    public class CustomersView
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

        public string Address { get; set; }

        public string Region { get; set; }
    }
}
