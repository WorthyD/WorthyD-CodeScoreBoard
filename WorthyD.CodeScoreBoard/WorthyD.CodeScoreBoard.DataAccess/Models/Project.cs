using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WorthyD.CodeScoreBoard.DataAccess.Models {
    public class Project {

        [Key]
        [Required]
        public int ID { get; set; }
        
        [StringLength(20)]
        [Required]
        public string ProjectDetails { get; set; }

        [StringLength(200)]
        [Required]
        public string ProjectPath { get; set; }



        public virtual ICollection<CodeLog> CodeLogs { get; set; }
    }
}
