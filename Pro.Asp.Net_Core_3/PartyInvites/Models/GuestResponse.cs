using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="Please enter your name")]
        public string Name{get;set;}

        [Required(ErrorMessage="Please enter your email address")]
        [EmailAddress]
        public string Email {get;set;}

        [Required(ErrorMessage="Please enter your phone")]
        public string Phone {get;set;}

        [Required(ErrorMessage="Please specify wheter you'll attend")]
        public bool? WillAttend {get;set;}
    }
}