using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{   
    /// <summary>
    /// Klasa odpowiadająca za tabelę wypożyczenia.
    /// Mapowanie kolumn.
    /// </summary>
    public class Rental {
        /// <summary>
        /// Property.
        /// Unikalne, auto generowane, ID wypożyczenia.
        /// Primary key.
        /// Tworzy kolumnę Id.
        /// </summary>
        [Key]
        public int Id {
            get; set;
        }
        /// <summary>
        /// Property.
        /// ID klienta, który wypożyczył dane akcesorium.
        /// Tworzy kolumnę ClientId.
        /// Zależność od klucza obcego.
        /// </summary>
        public int ClientId {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Klient, który wypożyczył akcesorium.
        /// Zależność od klucza obcego.
        /// </summary>
        public virtual Client Client {
            get; set;
        }
        /// <summary>
        /// ID akcesorium, które zostało wypożyczone.
        /// Zależność od klucza obcego.
        /// </summary>
        public int AccessoryId {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Akcesorium, które zostało wypożyczone.
        /// Tworzy kolumnę AccessoryId.
        /// Zależność od klucza obcego.
        /// </summary>
        public virtual Accessory Accessory {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Data wypożyczenia akcesorium.
        /// Pole wymagane.
        /// Tworzy kolumnę RentalDate.
        /// </summary>
        [Required]
        public DateTime RentalDate {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Data zwortu akcesorium.
        /// Pole może być puste co oznacza, że akcesorium nie zostało jeszcze zwrócone.
        /// Tworzy kolumnę ReturnDate.
        /// </summary>
        public DateTime? ReturnDate {
            get; set;
        }
        
    }
}
