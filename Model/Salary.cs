﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OAKAPI.Model
{
    public class Salary
    {
        public Salary()
        {
            Persons = new HashSet<Person>();
        }
        [Key] public int SalaryId { get; set; }
        public string Amount { get; set; }
        public virtual ICollection<Person>Persons { get; set; }
    }
}
