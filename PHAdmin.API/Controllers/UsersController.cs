
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PHAdmin.API.Models;
using PHAdmin.API.Services;

namespace PHAdmin.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;
        public UsersController(IPHAdminRepository phAdminRepository, IMapper mapper)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var userEntities = await _phAdminRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userEntities));
        }
    }
}
