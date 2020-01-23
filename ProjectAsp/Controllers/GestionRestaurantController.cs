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
    public class GestionRestaurantController : Controller
    {
        private readonly RestaurantService restService;

        public GestionRestaurantController(RestaurantContext context)
        {
            this.restService = new RestaurantService(context);
        }

        // GET: GestionRestaurant
        public IActionResult Index()
        {
            return View(restService.getAllRest());
        }

        // GET: GestionRestaurant/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = restService.getOneRest(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: GestionRestaurant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GestionRestaurant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("nom,tel,email")] Restaurant restaurant, [Bind("rue, cp, ville")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                restaurant.adresse = adresse;
                restService.createRest(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: GestionRestaurant/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = this.restService.getOneRest(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: GestionRestaurant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("nom,tel,email")] Restaurant restaurant, [Bind("rue, cp, ville")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.restService.updateRest(id, restaurant, adresse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.ID))
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
            return View(restaurant);
        }

        // GET: GestionRestaurant/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = this.restService.getOneRest(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: GestionRestaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            this.restService.deleteRest(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return this.restService.restsExists(id);
        }
    }
}
