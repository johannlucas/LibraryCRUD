﻿using System;

namespace LibraryCRUD.Models
{
    public class Book
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
    }
}
