﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contoso.Models;

namespace Contoso.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly Contoso.Models.ContosoContext _context;

        public EditModel(Contoso.Models.ContosoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.FindAsync(id);
            //Student = await _context.Student.FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _context.Student.FindAsync(id);
            //_context.Attach(Student).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!StudentExists(Student.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return RedirectToPage("./Index");
            //}

            //private bool StudentExists(int id)
            //{
            //    return _context.Student.Any(e => e.ID == id);
            //}

            if (await TryUpdateModelAsync<Student>(
           studentToUpdate,
           "student",
           s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
