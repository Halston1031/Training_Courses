namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemTable")]
    public partial class ItemTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
