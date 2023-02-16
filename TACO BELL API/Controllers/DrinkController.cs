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
        public Drink GetByName(string name)
        {
            return dbContext.Drinks.FirstOrDefault(b => b.Name.Contains(name));
        }

        [HttpGet("Slushie")]
        public List<Drink> GetBySlushie(bool Slushie)
        {
            return dbContext.Drinks.Where(b => b.Slushie == Slushie).ToList();
        }

        [HttpGet("{Id}")]
        public List<Drink> GetByDrinkId(int Id)
        {
            return dbContext.Drinks.Where(b => b.Id == Id).ToList();
        }

        [HttpPost]
        public Drink AddDrink(string name, float cost, bool slushie)
        {
            Drink newDrink = new Drink() { Name = name, Cost = cost, Slushie =slushie };

            dbContext.Drinks.Add(newDrink);
            dbContext.SaveChanges();


            return newDrink;

        }

        [HttpDelete("{Id}")]
        public Drink DeleteDrink(int Id)
        {
            Drink b = dbContext.Drinks.FirstOrDefault(b => b.Id == Id);
            dbContext.Drinks.Remove(b);
            dbContext.SaveChanges();

            return b;
        }

        [HttpPut("{Id}")]
        public Drink UpdateDrink(int id,string name)
        {
            Drink b = dbContext.Drinks.FirstOrDefault(b => b.Id == id);
            b.Name = name;
            dbContext.Drinks.Update(b);
            dbContext.SaveChanges();



            return b;
        }

    }
}
