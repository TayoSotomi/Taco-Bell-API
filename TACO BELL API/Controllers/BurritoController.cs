using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TACO_BELL_API.Models;

namespace TACO_BELL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurritoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext(); //SQL Database


        [HttpGet]
        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        [HttpGet("Name")]
        public Burrito GetByName(string name)
        {
            return dbContext.Burritos.FirstOrDefault(b => b.Name.Contains(name));
        }
        [HttpGet("beans")]
        public List<Burrito> GetByBeans(bool beans)
        {
            return dbContext.Burritos.Where(b => b.Bean == beans).ToList();
        }

        [HttpGet("{Id}")]
    public List<Burrito> GetByBurritoId(int Id)
    {
        return dbContext.Burritos.Where(b => b.Id == Id).ToList();
    }

        [HttpPost]
        public Burrito AddBurrito(string name,float cost, bool bean)
        {
            Burrito newBurrito= new Burrito() {Name= name,Cost= cost,Bean =bean };

            dbContext.Burritos.Add(newBurrito);
            dbContext.SaveChanges();


            return newBurrito;

        }

        [HttpDelete("{Id}")]
        public Burrito DeleteBurrito(int Id)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b=>b.Id == Id);
            dbContext.Burritos.Remove(b);
            dbContext.SaveChanges();

            return b;
        }

        [HttpPut("{Id}")]
        public Burrito UpdateBurrito(int id, string name)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b => b.Id == id);
            b.Name = name;
            dbContext.Burritos.Update(b);
            dbContext.SaveChanges();



            return b;
        }

    }

}
