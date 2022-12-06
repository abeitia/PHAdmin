
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PHAdmin.API.Models;
using PHAdmin.API.Services;

namespace PHAdmin.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;
        public PaymentsController(IPHAdminRepository phAdminRepository, IMapper mapper)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPayments()
        {
            var paymentEntities = await _phAdminRepository.GetPaymentsAsync();
            return Ok(_mapper.Map<IEnumerable<PaymentDto>>(paymentEntities));
        }
    }
}
