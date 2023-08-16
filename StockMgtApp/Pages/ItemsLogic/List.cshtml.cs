using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.ItemsLogic
{
    public class ListModel : PageModel
    {
        private readonly DatabaseContext _context;
        public ListModel(DatabaseContext context)
        {
            _context = context;
        }

        public List<ItemCategory> itemCategory { get; set; }
        public void OnGet()
        {
            var itemCat = _context.ItemCategories.ToList();
            itemCategory = itemCat;
        }
    }
}
