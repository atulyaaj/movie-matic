using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BookMyShowEntity
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Provide a Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Write Movie Description Here")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Please Enter more than 3 characters")]
        public string MovieDesc { get; set; }

        public string MovieType { get; set; } 
        public int MoviePrice { get; set; }
        public byte[] ImgPoster { get; set; }
    }
}
