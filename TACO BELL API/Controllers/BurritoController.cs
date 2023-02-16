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
        public Burrito GetByID(string name)
        {
            return dbContext.Burritos.FirstOrDefault(b => b.Name.Contains(name));
        }

        [HttpGet("{Id}")]
    public List<Burrito> GetById(int Id)
    {
        return dbContext.Burritos.Where(b => b.Id == Id).ToList();
    }

        [HttpPost]
        public Burrito AddBurrito(string name,float cost, bool bean)
        {
            Burrito newBurrito= new Burrito(name,cost,bean);

            dbContext.Burritos.Add(newBurrito);
            dbContext.SaveChanges();


            return newBurrito;

        }

        [HttpDelete]
        public Burrito DeleteBurrito(int Id)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b=>b.Id == Id);
            dbContext.Remove(b);
            dbContext.SaveChanges();

            return b;
        }

        [HttpPut]
        public Burrito UpdateBurrito(string oldName,string newName)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b=> b.Name == oldName);
           b.Name = newName;
            dbContext.SaveChanges();
            dbContext.Burritos.Update(b);
                      

            return b;
        }

    }

}
