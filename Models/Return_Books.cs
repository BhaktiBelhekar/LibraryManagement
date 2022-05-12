using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Return_Books
    {
        [Key]
        public int id { get; set; }
         [Required]
         [ForeignKey("Student_Id")]
        public string Student_Id { get; set; }

        [ForeignKey("BookNo")]
        public int BookNo { get; set; }
        
       
        [Required]
        public string BookName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public DateTime Return_Date { get; set; }
       
        public int Fine { get; set; }
        
    }
}
