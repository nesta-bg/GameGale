using System;
using System.ComponentModel.DataAnnotations;

namespace GameGale.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}

/*
[Required]
[StringLength(255)] 
[Range(1,10)]
[Compare("OtherProperty")]
[Phone]
[EmailAddress]
[Url]
[RegularExpression("...")]
*/
