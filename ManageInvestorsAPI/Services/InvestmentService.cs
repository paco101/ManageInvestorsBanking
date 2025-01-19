using AutoMapper;
using ManageInvestors.Models;
using ManageInvestors.Repositories;
using Models.DTOs;

namespace ManageInvestors.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IMapper mapper, IInvestmentRepository investmentRepository)
        {
            _mapper = mapper;
            _investmentRepository = investmentRepository;
        }

        public async Task<InvestmentDTO> GetInvestmentAsync(int id, CancellationToken cancellationToken)
        {
            var invest = await _investmentRepository.GetInvestmentAsync(id, cancellationToken);
            return _mapper.Map<InvestmentDTO>(invest);
        }

        public async Task<InvestmentDTO> CreateInvestmentAsync(InvestmentDTO investment, CancellationToken cancellationToken)
        {
            investment.TransactionDateTime = DateTime.UtcNow;

            var mappedInvestment = _mapper.Map<Investment>(investment);

            //To avoind tying to insert relatioship tabls
            mappedInvestment.Fund = null;
            mappedInvestment.Investor = null;

            var invest = await _investmentRepository.CreateInvestmentAsync(mappedInvestment, cancellationToken);
            return _mapper.Map<InvestmentDTO>(invest);
        }

        public async Task<InvestmentDTO> UpdateInvestmentAsync(InvestmentDTO investment, CancellationToken cancellationToken)
        {
            var invest = await _investmentRepository.UpdateInvestmentAsync(_mapper.Map<Investment>(investment), cancellationToken);
            return _mapper.Map<InvestmentDTO>(invest);
        }

        public async Task<bool> DeleteInvestmentAsync(int id, CancellationToken cancellationToken)
        {
            return await _investmentRepository.DeleteInvestmentAsync(id, cancellationToken);
        }
    }
}
