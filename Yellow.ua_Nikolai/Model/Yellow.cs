namespace Yellow.ua_Nikolai.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yellow")]
    public partial class Yellow
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(400)]
        public string Info { get; set; }

        [Required]
        [StringLength(200)]
        public string Image { get; set; }
    }
}
