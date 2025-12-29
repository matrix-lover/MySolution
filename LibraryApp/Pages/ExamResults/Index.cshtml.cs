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
    public class IndexModel : PageModel
    {
        private readonly LibraryApp.Models.LibraryContext _context;

        public IndexModel(LibraryApp.Models.LibraryContext context)
        {
            _context = context;
        }

        public IList<ExamResult> ExamResult { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ExamResult = await _context.ExamResults
                .Include(e => e.Student)
                .Include(e => e.Subject).ToListAsync();
        }
    }
}
