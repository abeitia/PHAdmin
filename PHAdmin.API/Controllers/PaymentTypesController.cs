
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PHAdmin.API.Models;
using PHAdmin.API.Services;

namespace PHAdmin.API.Controllers
{
    [Route("api/paymenttypes")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;

        public PaymentTypesController(IPHAdminRepository phAdminRepository, IMapper mapper)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PaymentTypeDto>>> GetPaymentTypes()
        {
            var paymentTypesEntities = await _phAdminRepository.GetPaymentTypesAsync();
            return Ok(_mapper.Map<IEnumerable<PaymentTypeDto>>(paymentTypesEntities));
        }
    }
}
