using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{

    public class Size {
        public int Id {
            get; set;
        }
        [Required]
        public SizeType SizeName {
            get; set;
        }
        public enum SizeType {
            XS,
            S,
            M,
            L,
            XL
        }
        public IEnumerable<Accessory> Accessories {
            get; set;
        }
    }
}
