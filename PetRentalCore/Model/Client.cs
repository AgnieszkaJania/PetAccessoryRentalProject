using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model {

    public class Client {

        public int Id {
            get; set;
        }
        [Required]
        [StringLength(15)]
        public string Name {
            get; set;
        }
        [Required]
        [StringLength(20)]
        public string Surname {
            get; set;
        }
        [Required]
        public DateTime DateOfBirth {
            get; set;
        }
        [Required]
        public DateTime RegistrationDate {
            get; set;
        }
        public IEnumerable<Rental> Rentals {
            get; set;
        }


        public string DateBirth => DateOfBirth.ToString("yyyy.MM.dd");
    }
}
