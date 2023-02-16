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
        public Taco GetByName(string name)
        {
            return dbContext.Tacos.FirstOrDefault(b => b.Name.Contains(name));
        }

        [HttpGet("{Id}")]
        public List<Taco> GetTacoById(int Id)
        {
            return dbContext.Tacos.Where(b => b.Id == Id).ToList();
        }

        [HttpPost]
        public Taco AddTaco(string name, float cost, bool softshell,bool dorito)
        {
            Taco newTaco = new Taco()
            { Name = name, Cost = cost, SoftShell = softshell,Dorito = dorito };

            dbContext.Tacos.Add(newTaco);

            dbContext.SaveChanges();


            return newTaco;
           
        }

        [HttpDelete("{Id}")]
        public Taco DeleteTaco(int Id)
        {
            Taco b = dbContext.Tacos.FirstOrDefault(b => b.Id == Id);
            dbContext.Tacos.Remove(b);
            dbContext.SaveChanges();

            return b;
        }

        [HttpPut("{Id}")]
        public Taco UpdateTaco(int id, string name)
        {
            Taco b = dbContext.Tacos.FirstOrDefault(b => b.Id == id);
            b.Name = name;
            dbContext.Tacos.Update(b);
            dbContext.SaveChanges();



            return b;
        }

    }
}
