using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TACO_BELL_API.Models;

namespace TACO_BELL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext(); //SQL Database


        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        [HttpGet("Name")]
        public Drink GetByID(string name)
        {
            return dbContext.Drinks.FirstOrDefault(b => b.Name.Contains(name));
        }

        [HttpGet("{Id}")]
        public List<Drink> GetById(int Id)
        {
            return dbContext.Drinks.Where(b => b.Id == Id).ToList();
        }

        [HttpPost]
        public Drink AddDrink(string name, float cost, bool slushie)
        {
            Drink newDrink = new Drink(name, cost, slushie);

            dbContext.Drinks.Add(newDrink);
            dbContext.SaveChanges();


            return newDrink;

        }

        [HttpDelete]
        public Drink DeleteDrink(int Id)
        {
            Drink b = dbContext.Drinks.FirstOrDefault(b => b.Id == Id);
            dbContext.Remove(b);
            dbContext.SaveChanges();

            return b;
        }

        [HttpPut]
        public Drink UpdateDrink(string oldName, string newName)
        {
            Drink b = dbContext.Drinks.FirstOrDefault(b => b.Name == oldName);
            b.Name = newName;
            dbContext.SaveChanges();
            dbContext.Drinks.Update(b);


            return b;
        }

    }
}
