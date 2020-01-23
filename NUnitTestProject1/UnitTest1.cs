using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProjectAsp.Db;
using ProjectAsp.Services;

namespace NUnitTestProject1
{
    public class Tests : DbContext
    {
        private RestaurantContext restCtx;
        private RestaurantService restService;
        private JsonService jsonService;

        [SetUp]
        public void Setup()
        {
            var dbOption = new DbContextOptionsBuilder<RestaurantContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProjetAsp;Trusted_Connection=True;")
            .Options;

            restCtx = new RestaurantContext(dbOption);
            restService = new RestaurantService(restCtx);
            jsonService = new JsonService(restCtx);
        }

    [Test]
        public void Test1()
        {
            restCtx.Database.EnsureDeleted();
            restCtx.Database.EnsureCreated();

            Assert.AreEqual(0, restService.getAllRest().Count);
            jsonService.importData(@"..\..\..\Ressources\resto.json");

            var listrest = restService.getAllRest();
            Assert.AreEqual(6, listrest.Count);
            Assert.AreEqual(6, restService.getAllNotes().Count);
            foreach (var rest in listrest)
            {
                Assert.IsNotNull(rest.adresse);
            }
        }

    [Test]
        public void Test2()
        {
            jsonService.exportData(@"..\..\..\Ressources\resto2.json");
        }
    }
}