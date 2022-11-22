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
        private readonly IPHAdminRepository _phAdminRepository;

        public ApartmentsController(IPHAdminRepository phAdminRepository, 
            ILogger<ApartmentsController> logger,
            IMailService mailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
        }


        [HttpGet()]
        public async Task< ActionResult<IEnumerable<ApartmentDto>>> GetApartments()
        {
            _mailService.Send("Subject","Message");

            var apartmentEntities = await _phAdminRepository.GetApartmentsAsync();

            var results = new List <ApartmentDto>();
            foreach (var apartmentEntity in apartmentEntities)
            {
                results.Add(new ApartmentDto
                {
                    Id = apartmentEntity.Id,
                    Floor = apartmentEntity.Floor,
                    Letter = apartmentEntity.Letter,
                    Name = apartmentEntity.Name

                });
            }

            return Ok(results);

            //return new JsonResult(
            // new List<object>
            //{
            //    new {id = 1, Name = "7-A"},
            //    new {id = 2, Name = "7-B"}
            //});
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
