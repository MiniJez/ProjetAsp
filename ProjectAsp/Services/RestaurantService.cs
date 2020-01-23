using Microsoft.EntityFrameworkCore;
using ProjectAsp.Db;
using ProjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAsp.Services
{
    public class RestaurantService
    {
        private RestaurantContext restaurantContext;

        public RestaurantService(RestaurantContext ctx)
        {
            this.restaurantContext = ctx;
            this.restaurantContext.Database.EnsureCreated();
        }

        public RestaurantContext getRestCtx()
        {
            return this.restaurantContext;
        }

        public List<Restaurant> getAllRest()
        {
            
            var listResto = this.restaurantContext.Restaurants.Include(r => r.adresse).Include(r => r.note).ToList();
            return listResto;
        }

        public List<Note> getAllNotes()
        {
            
            var listNotes = this.restaurantContext.Notes.Include(r => r.restaurant).ToList();
            return listNotes;
        }

        public Restaurant getOneRest(int? id)
        {
            
            var listResto = this.restaurantContext.Restaurants.Include(a => a.adresse).FirstOrDefault(m => m.ID == id);
            return listResto;
        }

        public Note getOneNote(int? id)
        {
            
            var listNotes = this.restaurantContext.Notes.Include(a => a.restaurant).FirstOrDefault(m => m.ID == id);
            return listNotes;
        }

        public void createRest(Restaurant restaurant)
        {
            
            this.restaurantContext.Restaurants.Add(restaurant);
            this.restaurantContext.SaveChanges();
        }

        public void createNote(Note note)
        {
            
            this.restaurantContext.Notes.Add(note);
            this.restaurantContext.SaveChanges();
        }

        public void updateRest(int id, Restaurant restaurant, Adresse adresse)
        {
            
            var resto = this.restaurantContext.Restaurants.Include(a => a.adresse).Where(a => a.ID == id).First();
            resto.nom = restaurant.nom;
            resto.tel = restaurant.tel;
            resto.email = restaurant.email;
            resto.adresse.rue = adresse.rue;
            resto.adresse.ville = adresse.ville;
            resto.adresse.cp = adresse.cp;

            this.restaurantContext.SaveChanges();
        }

        public void updateNote(int id, Note note)
        {
            
            this.restaurantContext.Update(note);
            this.restaurantContext.SaveChanges();
        }

        public void deleteRest(int id)
        {
            
            var restaurant = this.restaurantContext.Restaurants.Find(id);
            this.restaurantContext.Remove(restaurant);
            this.restaurantContext.SaveChanges();
        }

        public void deleteNote(int id)
        {
            
            var note = this.restaurantContext.Notes.Find(id);
            this.restaurantContext.Notes.Remove(note);
            this.restaurantContext.SaveChanges();
        }

        public Boolean restsExists(int id)
        {
            return this.restaurantContext.Restaurants.Any(e => e.ID == id);
        }

        public Boolean notesExists(int id)
        {
            return this.restaurantContext.Notes.Any(e => e.ID == id);
        }
    }
}
