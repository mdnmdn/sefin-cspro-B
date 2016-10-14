namespace EFPlayground.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categories")]
    public partial class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [Column("Attivatoooo")]
        public bool? Active { get; set; }


        public override string ToString()
        {
            return $"{CategoryID}. {CategoryName}";
        }
    }
}
