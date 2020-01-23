using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectAsp.Db;
using ProjectAsp.Models;

namespace ProjectAsp.Services
{
    public class JsonService
    {
        private readonly RestaurantService restaurantService;

        public JsonService(RestaurantContext ctx)
        {
            this.restaurantService = new RestaurantService(ctx);
        }

        public void importData(string jsonFilePath)
        {
            //string jsonPath = Path.Combine(jsonFilePath);
            var json = File.ReadAllText(jsonFilePath);
            List<Restaurant> listResto = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            
            foreach(var resto in listResto)
            {
                this.restaurantService.createRest(resto);
            }
        }


        public void exportData(string jsonFilePath)
        {
            //string jsonPath = Path.Combine(jsonFilePath);

            var listResto = this.restaurantService.getAllRest();

            string serialized = JsonConvert.SerializeObject(listResto, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            File.WriteAllText(jsonFilePath, serialized);
        }
    }
}
