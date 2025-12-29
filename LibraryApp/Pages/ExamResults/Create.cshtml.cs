using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryApp.Models;

namespace LibraryApp.Pages.ExamResults
{
    public class CreateModel : PageModel
    {
        private readonly LibraryApp.Models.LibraryContext _context;

        public CreateModel(LibraryApp.Models.LibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
        ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ExamResult ExamResult { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExamResults.Add(ExamResult);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
