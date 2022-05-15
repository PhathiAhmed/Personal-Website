using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Personal.Models
{
    public partial class Tbaboutme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Freelancer { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
