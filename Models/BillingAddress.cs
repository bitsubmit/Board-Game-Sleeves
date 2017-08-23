namespace Board_game_sleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillingAddress")]
    public partial class BillingAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillingAddress()
        {
            Customers = new HashSet<Customer>();
        }

        public int BillingAddressId { get; set; }

        [Required]
        [StringLength(20)]
        public string Contry { get; set; }

        [Required]
        [StringLength(8)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field only accepts numbers")]
        public string Zip { get; set; }


        [Required]
        [StringLength(30)]
        public string Street { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
