using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WorthyD.CodeScoreBoard.DataAccess.Models {
    public class CodeLog {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int FileCount { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }

        [Required]
        public int BlankLines { get; set; }

        [Required]
        public int CommentLines { get; set; }
        [Required]
        public int CodeLines { get; set; }


        [Required]
        public DateTime LogTime { get; set; }


        public virtual Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
    }
}
