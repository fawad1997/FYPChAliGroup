using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding_Vibes.Models.Reservation
{
    public class Reservation
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name ")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only contain aplhabets")]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last Name can only contain aplhabets")]
        public string LastName { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser user { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public String HallName { get; set; }
        [Required]
        public int PhoneNo { get; set; }

        [Required]
        public int NumberofGuests { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Date of Reservation can't be Null")]
        [Display(Name = "Date of Reservation")]
        public DateTime ReservationDate { get; set; }
        [Required]
        public string Title { get; set; }
        public Boolean Status { get; set; }
        public int MenuId { get; set; }

    }
}
