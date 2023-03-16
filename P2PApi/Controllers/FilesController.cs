using Microsoft.AspNetCore.Mvc;
using P2PApi.Repositories;
using P2PApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2PApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private FilesRepository _repository;

        public FilesController(FilesRepository filesRepository)
        {
            _repository = filesRepository;
        }

        // GET: api/<FilesController>

        [HttpGet]
        public List<string> GetAllFileNames()
        {
            return _repository.GetAllFileNames().ToList();
        }

        // GET api/<FilesController>/filename
        [HttpGet("{filename}")]
        public List<FileEndPoint> GetAllPeers(string filename)
        {
            return _repository.GetAllFileEndPoints(filename).ToList();
        }

        // POST api/<FilesController>
        [HttpPost]
        public void Post(string filename, [FromBody] FileEndPoint newFileEndpoint)
        {
            _repository.AddEndpoint(filename, newFileEndpoint);
        }

        // DELETE api/<FilesController>/5
        [HttpDelete("{filename}")]
        public void Delete(string filename)
        {
            _repository.Delete(filename);
        }
    }
}