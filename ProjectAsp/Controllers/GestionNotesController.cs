using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAsp.Db;
using ProjectAsp.Models;
using ProjectAsp.Services;

namespace ProjectAsp
{
    public class GestionNotesController : Controller
    {
        private readonly RestaurantService restService;

        public GestionNotesController(RestaurantContext context)
        {
            this.restService = new RestaurantService(context);
        }

        // GET: GestionNotes
        public IActionResult Index()
        {
            var notes = this.restService.getAllNotes();
            return View(notes);
        }

        // GET: GestionNotes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = this.restService.getOneNote(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: GestionNotes/Create
        public IActionResult Create()
        {
            ViewData["restaurant"] = new SelectList(this.restService.getRestCtx().Restaurants, "ID", "nom");
            return View();
        }

        // POST: GestionNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("restoID,note,dateDerniereVisite,commentaire")] Note note_resto)
        {
            if (ModelState.IsValid)
            {
                this.restService.createNote(note_resto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["restoID"] = new SelectList(this.restService.getRestCtx().Restaurants, "ID", "nom", note_resto.restoID);
            return View(note_resto);
        }

        // GET: GestionNotes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = this.restService.getOneNote(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["restoID"] = new SelectList(this.restService.getRestCtx().Restaurants, "ID", "nom", note.restoID);
            return View(note);
        }

        // POST: GestionNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,restoID,note,dateDerniereVisite,commentaire")] Note note_resto)
        {
            if (id != note_resto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.restService.updateNote(id, note_resto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note_resto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["restoID"] = new SelectList(this.restService.getRestCtx().Restaurants, "ID", "nom", note_resto.restoID);
            return View(note_resto);
        }

        // GET: GestionNotes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = this.restService.getOneNote(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: GestionNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            this.restService.deleteNote(id);
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return this.restService.notesExists(id);
        }
    }
}
