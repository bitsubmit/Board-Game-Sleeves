namespace Board_game_sleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductMatchingBoardgame")]
    public partial class ProductMatchingBoardgame
    {
        public int ProductMatchingBoardgameId { get; set; }

        public int BoardGameId { get; set; }

        public int ProductId { get; set; }

        public virtual BoardGame BoardGame { get; set; }

        public virtual Product Product { get; set; }
    }
}
