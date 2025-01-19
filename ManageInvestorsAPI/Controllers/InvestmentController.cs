using ManageInvestors.DataLayer;
using ManageInvestors.Models;
using ManageInvestors.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvestorManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        // Add fund to investor (create new Investment)
        [HttpPost]
        public async Task<ActionResult<Investment>> CreateInvestment([FromBody] Investment newInvestment, CancellationToken cancellationToken)
        {
            var created = await _investmentService.CreateInvestmentAsync(newInvestment, cancellationToken);
            return CreatedAtAction(nameof(GetInvestment), new { id = created.Id }, created);
        }

        // 5. Update a Investment
        [HttpPut("{id}")]
        public async Task<ActionResult<Investment>> UpdateInvestment(
            [FromBody] Investment investment,
            CancellationToken cancellationToken)
        {
            var updatedInvestment = await _investmentService.UpdateInvestmentAsync(investment, cancellationToken);

            if (updatedInvestment == null)
                return NotFound();

            return Ok(updatedInvestment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Investment>> GetInvestment(int id, CancellationToken cancellationToken)
        {
            var investment = await _investmentService.GetInvestmentAsync(id, cancellationToken);
            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        // 6. Soft Delete an investment (example: “Nyssa Barr”)
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> SoftDeleteInvestment(int id, CancellationToken cancellationToken)
        {
            var investor = await _investmentService.GetInvestmentAsync(id, cancellationToken);

            if (investor == null)
                return NotFound(false);

            investor.IsDeleted = true;

            var updatedInvestor = await _investmentService.UpdateInvestmentAsync(investor, cancellationToken);

            if (updatedInvestor == null)
                return NotFound(false);

            return Ok(true);
        }

        // 7. Hard Delete an investment (example: “Nyssa Barr”)
        [HttpDelete("{id}/hard-delete")]
        public async Task<ActionResult<bool>> DeleteInvestment(int id, CancellationToken cancellationToken)
        {
            var investor = await _investmentService.GetInvestmentAsync(id, cancellationToken);

            if (investor == null)
                return NotFound(false);

            var result = await _investmentService.DeleteInvestmentAsync(investor.Id, cancellationToken);

            return Ok(result);
        }
    }
}

