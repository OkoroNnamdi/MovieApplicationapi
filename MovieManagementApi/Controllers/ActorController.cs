using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.DataAccess.Implementation;
using MovieManagement.Domain.Repository;

namespace MovieManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet()]
        public ActionResult Get()
        {
            return Ok( _unitOfWork.Actor.GetAll());
        }
        [HttpDelete]
        public async Task<IActionResult>delete(int id)
        {
            _unitOfWork.Actor.RemoveById(id);
            await _unitOfWork.saveChangeesAsync();
            return Ok();
        }
    }
}
