namespace Board_game_sleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoardGame")]
    public partial class BoardGame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoardGame()
        {
            ProductMatchingBoardgames = new HashSet<ProductMatchingBoardgame>();
        }

        public int BoardGameId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMatchingBoardgame> ProductMatchingBoardgames { get; set; }
    }
}
