using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PetRentalCore.Model
{
    /// <summary>
    /// Klasa odpowiadająca za tabelę akcesoria.
    /// Mapowanie kolumn.
    /// </summary>
    public class Accessory
    {
        /// <summary>
        /// Property.
        /// Unikalne, auto wypełniane ID akcesorium.
        /// Primary key.
        /// Tworzy kolumnę Id.
        /// </summary>
        [Key]
        public int Id
        {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Nazwa akcesorium.
        /// Pole wymagane.
        /// Długość nie może przekraczać 30 znaków.
        /// Tworzy kolumnę AccessoryName.
        /// </summary>
        [Required]
        [StringLength(30)]
        public string AccessoryName
        {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Cena wypożyczenia akcesorium na jeden dzień.
        /// Tworzy kolumnę OneDayRentalPrice.
        /// Pole wymagane.
        /// </summary>
        [Required]
        public decimal OneDayRentalPrice
        {
            get; set;
        }
        /// <summary>
        /// Wypożyczenia danego akcesorium.
        /// Navigation property for related rows.
        /// </summary>
        public IEnumerable<Rental> Rentals
        {
            get; set;
        }
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public Accessory() {
            this.Rentals = new List<Rental>();
        }
        /// <summary>
        /// Property.
        /// ID rodzaju zwierzęcia, dla którego przeznaczone jest akcesorium.
        /// Tworzy kolumnę PetTypeId.
        /// Zależność od klucza obcego.
        /// </summary>
        public int PetTypeId
        {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Rodzaj zwierzęcia, dla którego przeznaczone jest akcesorium.
        /// Zależność od klucza obcego.
        /// </summary>
        public virtual PetType PetType
        {
            get; set;
        }
        /// <summary>
        /// Property.
        /// ID rozmiaru, w którym jest akcesorium.
        /// Tworzy kolumnę SizeId.
        /// Zależność od klucza obcego.
        /// </summary>
        public int SizeId
        {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Rozmiar akcesorium.
        /// Zależność od klucza obcego.
        /// </summary>
        public virtual Size Size
        {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Zwraca true jeżeli  akcesorium jest wypożyczone.
        /// W przeciwnym razie zwraca false.
        /// </summary>
        public bool isRented =>
            Rentals.Any(a=>a.ReturnDate is null);
    }
}
