using Microsoft.AspNetCore.Mvc;
using PHAdmin.API.Models;
using PHAdmin.API.Services;

namespace PHAdmin.API.Controllers
{
    [ApiController]
    [Route("api/apartments")]
    public class ApartmentsController: ControllerBase
    {
        private readonly ILogger<ApartmentsController> _logger;
        private readonly IMailService _mailService;

        public ApartmentsController(ILogger<ApartmentsController> logger,
            IMailService mailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }


        [HttpGet()]
        public ActionResult<IEnumerable<ApartmentDto>> GetApartments()
        {
            _mailService.Send("Subject","Message");
            return new JsonResult(
             new List<object>
            {
                new {id = 1, Name = "7-A"},
                new {id = 2, Name = "7-B"}
            });
        }

        [HttpGet("{id}")]
        public ActionResult<ApartmentDto> GetApartment(int id)
        {
            var apartmentToReturn = new { id = 1, Name = "7-A" };

            _logger.LogInformation("Not found");

            if (apartmentToReturn == null)
            {
                return NotFound();
            }

            return Ok(apartmentToReturn);
        }
    }
}
