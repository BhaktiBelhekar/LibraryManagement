using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class AddBooks
    {
 
        [Key]
        public int BookNo { get; set; }

          [Required]
        public string BookName { get; set; }
         [Required]
        public string BookCategory { get; set; }
         [Required]
        public string Author { get; set; }
        [Required]
        public string Publication { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }
        public ICollection<Issue_Books> IssueBook { get; set; }
        public ICollection<Return_Books> ReturnBook { get; set; }

    }
}
