using Board_game_sleeves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board_game_sleeves.ViewModel
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}