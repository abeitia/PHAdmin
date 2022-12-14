//using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PHAdmin.API.Models;
using PHAdmin.API.Services;

namespace PHAdmin.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;

        public RolesController(IPHAdminRepository phAdminRepository, IMapper mapper)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
          

            var roleEntities = await _phAdminRepository.GetRolesAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(roleEntities));


        }
    }
}
