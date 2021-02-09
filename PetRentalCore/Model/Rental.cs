using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{
    public class Rental {
        public int Id {
            get; set;
        }

        public int ClientId {
            get; set;
        }

        public virtual Client Client {
            get; set;
        }

        public int AccessoryId {
            get; set;
        }
        public virtual Accessory Accessory {
            get; set;
        }
        [Required]
        public int RentalDate {
            get; set;
        }
        public int ReturnDate {
            get; set;
        }
    }
}
