using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class StudentDetails
    {
        // [Key]
        //public int Id { get; set; }


        [System.ComponentModel.DataAnnotations.KeyAttribute()]
        public string Student_Id { get; set; }
        [Required]

        public string StudentName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Address { get; set; }
        public ICollection<Issue_Books> IssueBook { get; set; }
        public ICollection<Return_Books> ReturnBook { get; set; }
    }
}
