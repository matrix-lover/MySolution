using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Pages.ExamResults
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryApp.Models.LibraryContext _context;

        public DetailsModel(LibraryApp.Models.LibraryContext context)
        {
            _context = context;
        }

        public ExamResult ExamResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examresult = await _context.ExamResults.FirstOrDefaultAsync(m => m.Id == id);
            if (examresult == null)
            {
                return NotFound();
            }
            else
            {
                ExamResult = examresult;
            }
            return Page();
        }
    }
}
