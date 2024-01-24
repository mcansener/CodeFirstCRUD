using CodeFirstCRUD.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirstCRUD.Models
{
    public class ProductModel : PageModel
    {
        private readonly AppDbContext _context;

        public ProductModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product _product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                // Edit scenario
                _product = await _context.Products.FindAsync(id.Value);
                if (_product == null)
                {
                    return NotFound();
                }
            }
            else
            {
                // Create scenario
                _product = new Product();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_product.Id > 0)
            {
                // Edit scenario
                _context.Attach(_product).State = EntityState.Modified;
            }
            else
            {
                // Create scenario
                _context.Products.Add(_product);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
