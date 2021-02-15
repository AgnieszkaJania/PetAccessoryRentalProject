using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{   
    /// <summary>
    /// Klasa odpowiadająca za tabelę wypożyczenia.
    /// Klasa tworzy wymagane kolumny tabeli.
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
        /// </summary>
        public int ClientId {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Klient, który wypożyczył akcesorium.
        /// </summary>
        public virtual Client Client {
            get; set;
        }
        /// <summary>
        /// ID akcesorium, które zostało wypożyczone.
        /// </summary>
        public int AccessoryId {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Akcesorium, które zostało wypożyczone.
        /// Tworzy kolumnę AccessoryId.
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
        /// <summary>
        /// Property.
        /// Data wypożyczenia akcesorium w formacie zawierającym tylko datę, bez czasu.
        /// </summary>
        public string DateRental => RentalDate.ToString("yyyy.MM.dd");
        //public string DateReturn => ReturnDate is null ? ReturnDate.ToString() : ReturnDate.ToString("yyyy.MM.dd");
    }
}
