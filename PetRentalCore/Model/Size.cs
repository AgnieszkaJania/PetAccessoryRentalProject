﻿using PetRentalCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetRentalCore.Model
{
    /// <summary>
    /// Klasa odpowiadająca za tabelę rozmiary.
    /// Mapowanie kolumn.
    /// </summary>

    public class Size {
        /// <summary>
        /// Property.
        /// Unikalne, auto wypełniane ID rozmiaru akcesorium.
        /// Primary key.
        /// Tworzy kolumnę Id.
        /// </summary>
        [Key]
        public int Id {
            get; set;
        }
        /// <summary>
        /// Property.
        /// Nazwa rozmiaru akcesorium.
        /// Pole wymagane.
        /// </summary>
        [Required]
        public SizeType SizeName {
            get; set;
        }
        /// <summary>
        /// Enum zawierające wszystkie możliwe rozmiary akcesoriów.
        /// </summary>
        public enum SizeType {
            XS,
            S,
            M,
            L,
            XL
        }
        /// <summary>
        /// Akcesoria o danym rozmiarze.
        /// Navigation property for related rows.
        /// </summary>
        public IEnumerable<Accessory> Accessories {
            get; set;
        }
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public Size() {
            this.Accessories = new List<Accessory>();
        }
    }
}
