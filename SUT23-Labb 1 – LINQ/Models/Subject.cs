﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb_1___LINQ.Models
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
