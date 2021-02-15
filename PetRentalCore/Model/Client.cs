using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model {
    /// <summary>
    /// Klasa odpowiadająca za tabelę klienci.
    /// Klasa tworzy wymagane kolumny tabeli.
    /// </summary>

    public class Client {
        /// <summary>
        /// Property.
        /// Unikalne, auto wypełniane ID klienta.
        /// Primary key.
        /// Tworzy kolumnę Id.
        /// </summary>
        [Key]
        public int Id {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Imię klienta.
        /// Pole wymagane.
        /// Tworzy kolumnę Name.
        /// Długość nie może przekraczać 15 znaków.
        /// </summary>
        [Required]
        [StringLength(15)]
        public string Name {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Nazwisko klienta.
        /// Pole wymagane.
        /// Tworzy kolumnę Surname.
        /// Długość nie może przekraczać 20 znaków.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Surname {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Data urodzenia klienta.
        /// Pole wymagane.
        /// Tworzy kolumnę DateOfBirth.
        /// </summary>
        [Required]
        public DateTime DateOfBirth {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Data rejestracji klienta w bazie - czas pobierany w momencie rejestracji klienta.
        /// Pole wymagane.
        /// Tworzy kolumnę RegistrationDate.
        /// </summary>
        [Required]
        public DateTime RegistrationDate {
            get; set;
        }
        /// <summary>
        /// Wypożyczenia akcesoriów wykonane przez klienta.
        /// </summary>
        public IEnumerable<Rental> Rentals {
            get; set;
        }

        /// <summary>
        /// Property.
        /// Zwraca datę urodzenia klienta bez czasu.
        /// </summary>
        public string DateBirth => DateOfBirth.ToString("yyyy.MM.dd");
        /// <summary>
        /// Property.
        /// Zwraca datę rejestracji klienta bez czasu.
        /// </summary>
        public string DateRegistration => RegistrationDate.ToString("yyyy.MM.dd");
    }
}
