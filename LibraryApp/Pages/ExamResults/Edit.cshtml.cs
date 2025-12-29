using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Pages.ExamResults
{
    public class EditModel : PageModel
    {
        private readonly LibraryApp.Models.LibraryContext _context;

        public EditModel(LibraryApp.Models.LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExamResult ExamResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examresult =  await _context.ExamResults.FirstOrDefaultAsync(m => m.Id == id);
            if (examresult == null)
            {
                return NotFound();
            }
            ExamResult = examresult;
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
           ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExamResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamResultExists(ExamResult.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExamResultExists(int id)
        {
            return _context.ExamResults.Any(e => e.Id == id);
        }
    }
}
