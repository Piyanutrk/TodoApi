using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApi.Models
{
    public partial class StudentRegister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsRegister { get; set; }
    }
}
