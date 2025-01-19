using ManageInvestors.DataLayer;
using ManageInvestors.Models;
using ManageInvestors.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;

namespace ManageInvestors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestorController : ControllerBase
    {
        private readonly IInvestorService _investorService;

        public InvestorController(IInvestorService investorService)
        {
            _investorService = investorService;
        }

        // 1. Retrieve all investors with the fund(s) they are invested in
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investor>>> GetAllInvestorsAsync(
            CancellationToken cancellationToken)
        {
            var investors = await _investorService.GetAllInvestorsAsync(cancellationToken);

            return Ok(investors);
        }

        // 2. Retrieve a single investor with the fund(s) they are invested in
        [HttpGet("{id}")]
        public async Task<ActionResult<Investor>> GetInvestor(int id, CancellationToken cancellationToken)
        {
            var investor = await _investorService.GetInvestorAsync(id, cancellationToken);

            if (investor == null)
                return NotFound();

            return Ok(investor);
        }

        // 2. Retrieve a single investor with the fund(s) they are invested in
        [HttpGet("{id}/investments")]
        public async Task<ActionResult<InvestorDTO>> GetInvestorAndInvestmentsAsync(int id, CancellationToken cancellationToken)
        {
            var investor = await _investorService.GetInvestorAndInvestmentsAsync(id, cancellationToken);

            if (investor == null)
                return NotFound();

            return Ok(investor);
        }


        [HttpGet("investments")]
        public async Task<ActionResult<IEnumerable<InvestorDTO>>> GetAllInvestorsAndInvestmentsAsync(
            CancellationToken cancellationToken)
        {
            var investors = await _investorService.GetAllInvestorsAndInvestmentsAsync(cancellationToken);

            return Ok(investors);
        }


        // 4. Create a new investor "Tom Smith"
        [HttpPost]
        public async Task<ActionResult<Investor>> CreateInvestor(
            [FromBody] Investor newInvestor,
            CancellationToken cancellationToken)
        {
            var createdInvestor = await _investorService.CreateInvestorAsync(newInvestor, cancellationToken);

            return CreatedAtAction(nameof(GetInvestor), new { id = newInvestor.Id }, newInvestor);
        }

        // 5. Update a investor "Tom Smith"
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInvestor(
            [FromBody] InvestorDTO investor,
            CancellationToken cancellationToken)
        {
            var updatedInvestor = await _investorService.UpdateInvestorAsync(investor, cancellationToken);

            if (updatedInvestor == null)
                return NotFound();

            return NoContent();
        }

        // 6. Soft Delete an investor (example: “Nyssa Barr”)
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> SoftDeleteInvestor(int id, CancellationToken cancellationToken)
        {
            var investor = await _investorService.GetInvestorAsync(id, cancellationToken);

            if (investor == null)
                return NotFound(false);

            investor.IsDeleted = true;

            var updatedInvestor = await _investorService.UpdateInvestorAsync(investor, cancellationToken);

            if (updatedInvestor == null)
                return NotFound(false);

            return Ok(true);
        }

        // 7. Hard Delete an investor (example: “Nyssa Barr”)
        [HttpDelete("{id}/hard-delete")]
        public async Task<ActionResult<bool>> DeleteInvestor(int id, CancellationToken cancellationToken)
        {
            var investor = await _investorService.GetInvestorAsync(id, cancellationToken);

            if (investor == null)
                return NotFound(false);

            var result = await _investorService.DeleteInvestorAsync(investor.Id, cancellationToken);

            return Ok(result);
        }
    }
}
