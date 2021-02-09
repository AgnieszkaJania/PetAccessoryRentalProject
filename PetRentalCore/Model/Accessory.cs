using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{
    public class Accessory
    {
        public int Id
        {
            get; set;
        }
        [Required]
        [StringLength(30)]
        public string AccessoryName
        {
            get; set;
        }
        [Required]
        public decimal OneDayRentalPrice
        {
            get; set;
        }

        public IEnumerable<Rental> Rentals
        {
            get; set;
        }

        public int PetTypeId
        {
            get; set;
        }
        public virtual PetType PetType
        {
            get; set;
        }

        public int SizeId
        {
            get; set;
        }
        public virtual Size Size
        {
            get; set;
        }


    }
}
