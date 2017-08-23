namespace Board_game_sleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]

        [Required]
        [StringLength(30)]
        public string LastNAme { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field only accepts numbers")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string EMail { get; set; }

        public int BillingAddressId { get; set; }

        public virtual BillingAddress BillingAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
