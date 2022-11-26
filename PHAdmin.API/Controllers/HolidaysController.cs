using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PHAdmin.API.Models;
using PHAdmin.API.Services;

namespace PHAdmin.API.Controllers
{
    [Route("api/holidays")]
    [ApiController]
    public class HolidaysController: ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;

        public HolidaysController(IPHAdminRepository phAdminRepository, IMapper mapper)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<HolidayDto>>> GetHolidays()
        {


            var holidayEntities = await _phAdminRepository.GetHolidaysAsync();
            return Ok(_mapper.Map<IEnumerable<HolidayDto>>(holidayEntities));


        }
    }
}
