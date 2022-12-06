﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public List<Book> BookId { get; set; } = new List<Book>();

    }
}
