using ManageInvestors.DataLayer;
using ManageInvestors.Models;
using ManageInvestors.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManageInvestors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundController : ControllerBase
    {
        private readonly IFundService _fundService;
        private readonly IInvestorService _investorService;

        public FundController(IFundService fundService, IInvestorService investorService)
        {
            _fundService = fundService;
            _investorService = investorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fund>>> GetFunds(CancellationToken cancellationToken)
        {
            var funds = await _fundService.GetAllFundsAsync(cancellationToken);
            return Ok(funds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fund>> GetFund(int id, CancellationToken cancellationToken)
        {
            var fund = await _fundService.GetFundByIdAsync(id, cancellationToken);
            if (fund == null)
                return NotFound();

            return Ok(fund);
        }

        [HttpGet("{fundId}/investors")]
        public async Task<ActionResult<Investor>> GetAllInvestorsByFund(int fundId, CancellationToken cancellationToken)
        {
            var fund = await _investorService.GetAllInvestorsByFundIdAsync(fundId, cancellationToken);
            if (fund == null)
                return NotFound();

            return Ok(fund);
        }

        [HttpGet("{fundId}/investors-investments")]
        public async Task<ActionResult<Investor>> GetAllInvestorsAndInvestmentsByFund(int fundId, CancellationToken cancellationToken)
        {
            var investors = await _investorService.GetInvestorsAndInvestmentsByFundIdAsync(fundId, cancellationToken);
            if (investors == null)
                return NotFound();

            return Ok(investors);
        }

        [HttpPost]
        public async Task<ActionResult<Fund>> CreateFund([FromBody] Fund newFund, CancellationToken cancellationToken)
        {
            var fund = await _fundService.CreateFundAsync(newFund, cancellationToken);
            return CreatedAtAction(nameof(GetFund), new { id = fund.Id }, fund);
        }

        // 5. Update a Fund
        [HttpPut("{id}")]
        public async Task<ActionResult<Fund>> UpdateFund(
            [FromBody] Fund fund,
            CancellationToken cancellationToken)
        {
            var updatedFund = await _fundService.UpdateFundAsync(fund, cancellationToken);

            if (updatedFund == null)
                return NotFound();

            return Ok(updatedFund);
        }

        // 6. Delete a Fund 
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteFund(int id, CancellationToken cancellationToken)
        {
            var fund = await _fundService.GetFundByIdAsync(id, cancellationToken);
            if (fund == null)
                return NotFound();


            fund.IsDeleted = true;

            var updatedFund = await _fundService.UpdateFundAsync(fund, cancellationToken);

            if (updatedFund == null)
                return NotFound();

            return NoContent();
        }

        // 7. Hard Delete an investor (example: “Nyssa Barr”)
        [HttpDelete("{id}/hard-delete")]
        public async Task<ActionResult<bool>> DeleteInvestor(int id, CancellationToken cancellationToken)
        {
            var fund = await _fundService.GetFundByIdAsync(id, cancellationToken);

            if (fund == null)
                return NotFound(false);

            var result = await _fundService.DeleteFundAsync(fund.Id, cancellationToken);

            return Ok(result);
        }
    }
}
