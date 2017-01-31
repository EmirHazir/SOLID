using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Entities.SSConcrete
{
    public class ShippnigDetails
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(18,75)]//alış verişi yapacak adamın en az ve en cok kac yaşında olması gerektiği
        public int Age { get; set; }
    }
}
