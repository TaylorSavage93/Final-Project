﻿using System.ComponentModel.DataAnnotations;

namespace LibraryInventoryWeb.Models
{
    public class Books
    {
        public double Id { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InStock { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
