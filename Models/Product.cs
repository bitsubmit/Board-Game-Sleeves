namespace Board_game_sleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            ProductMatchingBoardgames = new HashSet<ProductMatchingBoardgame>();
        }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ProductDescription { get; set; }

        [StringLength(100)]
        public string ImageURL { get; set; }

        public int CardTypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        [Required]
        [StringLength(30)]
        public string Material { get; set; }

        public virtual CardType CardType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMatchingBoardgame> ProductMatchingBoardgames { get; set; }
    }
}
