using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tourneybracket.Data;
using tourneybracket.Models;

namespace tourneybracket.Controllers
{
    public class TeamsController : Controller
    {
        private readonly BracketContext _context;

        public TeamsController(BracketContext context)
        {
            _context = context;
        }

        // GET: Teams
        [HttpGet("/Brackets/{bracketID}/Teams/")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        // GET: Teams/Details/5
        [HttpGet("/Brackets/{bracketID}/Teams/{id}")]
        public async Task<IActionResult> Details(int? id, int? bracketID)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Where(m => m.BracketID == bracketID)
                .FirstOrDefaultAsync(m => m.id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,TeamName,BracketID")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        [HttpGet("/Brackets/{bracketID}/Teams/Edit/{id}/")]
        public async Task<IActionResult> Edit(int? id, int? bracketID)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (bracketID == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
            .Where(m => m.BracketID == bracketID)
            .FirstOrDefaultAsync(m => m.id == id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/Brackets/{bracketID}/Teams/Edit/{id}/")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int? bracketID, [Bind("id,TeamName,BracketID")] Team team)
        {
            if (id != team.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Brackets", new { id = team.BracketID });
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.id == id);
        }
    }
}
