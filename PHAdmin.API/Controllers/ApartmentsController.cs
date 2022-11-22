using AutoMapper;
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
        private readonly IMapper _mapper;

        public ApartmentsController(IPHAdminRepository phAdminRepository,
            IMapper mapper,
            ILogger<ApartmentsController> logger,
            IMailService mailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet()]
        public async Task< ActionResult<IEnumerable<ApartmentDto>>> GetApartments()
        {
            _mailService.Send("Subject","Message");

            var apartmentEntities = await _phAdminRepository.GetApartmentsAsync();
            return Ok(_mapper.Map<IEnumerable<ApartmentDto>>(apartmentEntities));
            

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentDto>> GetApartment(int id)
        {
            var apartment = await _phAdminRepository.GetApartmentAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
        

            return Ok(_mapper.Map<ApartmentDto>(apartment));
        }
    }
}
