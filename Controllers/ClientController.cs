using System;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio01.Controllers
{
    public class ClientController
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

    }
}

