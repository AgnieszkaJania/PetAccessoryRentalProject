using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{
    /// <summary>
    ///  Klasa odpowiadająca za tabelę rodzaje zwierząt.
    /// Klasa tworzy wymagane kolumny tabeli.
    /// </summary>
    public class PetType {
        /// <summary>
        /// Property.
        /// Unikalne, auto wypełniane ID rodzaju zwierzęcia.
        /// Primary key.
        /// Tworzy kolumnę Id.
        /// </summary>
        [Key]
        public int Id {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Rodzaj zwierzęcia.
        /// Pole wymagane.
        /// Długość nie może przekraczać 30 znaków.
        /// </summary>
        [Required]
        [StringLength(30)]
        public string PetTypeName {
            get; set;
        }
        /// <summary>
        /// Akcesoria przeznaczone dla danego rodzaju zwierzęcia.
        /// </summary>
        public IEnumerable<Accessory> Accessories {
            get; set;
        }
    }

}
