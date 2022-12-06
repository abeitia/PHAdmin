
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PHAdmin.API.Models;
using PHAdmin.API.Services;

namespace PHAdmin.API.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;

        public ExpensesController(IPHAdminRepository phAdminRepository, IMapper mapper)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
        {
            var expenseEntities = await _phAdminRepository.GetExpensesAsync();
            return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(expenseEntities));
        }
    }
}
