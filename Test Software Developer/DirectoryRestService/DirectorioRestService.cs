using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Models.Models;
using RepositoryDesignPattern.Repository;

namespace Test_Software_Developer.DirectoryRestService
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorioRestService : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly Directory<TblPerson> repository;

        public DirectorioRestService(IConfiguration configuration, Directory<TblPerson> repository)
        {
            this.configuration = configuration;
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetPerson")]
        public IActionResult GetPerson()
        {
            try
            {
                IEnumerable<TblPerson> persons = repository.Get();

                return Ok(persons);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        [HttpPost]
        [Route("PostPerson")]
        public IActionResult PostPerson(TblPerson persons)
        {
            try
            {
                repository.Add(persons);
                repository.Save();

                return Ok(persons);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
