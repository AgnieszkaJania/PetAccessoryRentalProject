using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{
    public class PetType {
        public int Id {
            get; set;
        }
        [Required]
        [StringLength(30)]
        public string PetTypeName {
            get; set;
        }
        public IEnumerable<Accessory> Accessories {
            get; set;
        }
    }

}
