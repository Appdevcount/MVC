using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.EntityFrameworkBoard.CodeFirst
{

    [Table("StudentInfo",Schema ="CF")]
    public class SudentDataAnnotation
    {
        public SudentDataAnnotation() { }

        [Key]
        public int SID { get; set; }
        //[DatabaseGenerated]
        //public int AutoComputedorIdentityColumn { get; set; }

        [Column("Name", TypeName = "ntext",Order =1)]
        [Required]
        [MaxLength(20),MinLength(2),StringLength(10)]
        public string StudentName { get; set; }

        [NotMapped]
        public int? Age { get; set; }
        [Column(Order =2)]
        [Index("INDEX_REGNUM", IsClustered = true, IsUnique = true)]
        public int StdId { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }
        //ConcurrencyCheck attribute to use existing column for concurrency check and not a separate timestamp column for concurrency.
        //[ConcurrencyCheck]
        //public string ConcCheckName { get; set; }

        [ForeignKey("StdId")]// Explicity name the Foreign key Column
        public virtual StandardDataAnnotation Standard { get; set; }


    }
}