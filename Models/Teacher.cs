using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApi.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
    }
}
