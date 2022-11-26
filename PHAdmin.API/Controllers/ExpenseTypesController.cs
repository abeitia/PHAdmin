
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using PHAdmin.API.Services;
using PHAdmin.API.Models;

namespace PHAdmin.API.Controllers
{
    [Route("api/expensetypes")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;

        public ExpenseTypesController(IPHAdminRepository phAdminRepository, IMapper mapper)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ExpenseTypeDto>>> GetExpenseTypes()
        {
            var expenseTypesEntities = await _phAdminRepository.GetExpenseTypesAsync();
            return Ok(_mapper.Map<IEnumerable<ExpenseTypeDto>>(expenseTypesEntities));
        }
    }
}
