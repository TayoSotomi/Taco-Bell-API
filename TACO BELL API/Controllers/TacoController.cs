using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TACO_BELL_API.Models;

namespace TACO_BELL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext(); //SQL Database


        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }

        [HttpGet("Name")]
        public Taco GetByID(string name)
        {
            return dbContext.Tacos.FirstOrDefault(b => b.Name.Contains(name));
        }

        [HttpGet("{Id}")]
        public List<Taco> GetById(int Id)
        {
            return dbContext.Tacos.Where(b => b.Id == Id).ToList();
        }

        [HttpPost]
        public Taco AddTaco(string name, float cost, bool softshell,bool dorito)
        {
            Taco newTaco = new Taco(name, cost, softshell,dorito);

            dbContext.Tacos.Add(newTaco);
            dbContext.SaveChanges();


            return newTaco;

        }

        [HttpDelete]
        public Taco DeleteTaco(int Id)
        {
            Taco b = dbContext.Tacos.FirstOrDefault(b => b.Id == Id);
            dbContext.Remove(b);
            dbContext.SaveChanges();

            return b;
        }

        [HttpPut]
        public Taco UpdateTaco(string oldName, string newName)
        {
            Taco b = dbContext.Tacos.FirstOrDefault(b => b.Name == oldName);
            b.Name = newName;
            dbContext.SaveChanges();
            dbContext.Tacos.Update(b);


            return b;
        }
    }
}
