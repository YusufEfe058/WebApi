using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using MongoDB.Driver;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        private readonly MongoDbContext _mongoDb;

        public DenemeController()
        {
            _mongoDb = new MongoDbContext();
        }

        [HttpPost("ogrenci-ekle")]
        public IActionResult OgrenciEkle([FromBody] Student student)
        {
            _mongoDb.Students.InsertOne(student);
            return Ok("Öğrenci eklendi.");
        }

        [HttpPost("ders-ekle")]
        public IActionResult DersEkle([FromBody] Course course)
        {
            _mongoDb.Courses.InsertOne(course);
            return Ok("Ders Eklendi");
        }

        [HttpGet("tum-ogrenciler")]
        public IActionResult TumOgrecileriGetir()
        {
            var ogrenciler = _mongoDb.Students.Find(_ => true).ToList();
            return Ok(ogrenciler);
        }
    }
}
