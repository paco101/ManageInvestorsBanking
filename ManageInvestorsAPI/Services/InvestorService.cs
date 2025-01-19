using AutoMapper;
using ManageInvestors.Models;
using ManageInvestors.Repositories;
using Models.DTOs;

namespace ManageInvestors.Services
{
    public class InvestorService : IInvestorService
    {
        private readonly IInvestorRepository _investorRepository;
        private readonly IMapper _mapper;

        public InvestorService(IMapper mapper,IInvestorRepository investorRepository)
        {
            _mapper = mapper;
            _investorRepository = investorRepository;
        }

        public async Task<List<InvestorDTO>> GetAllInvestorsAsync(CancellationToken cancellationToken)
        {
            // Additional business logic or validations can go here
            var investors = await _investorRepository.GetAllInvestorsAsync(cancellationToken);
            return _mapper.Map<List<InvestorDTO>>(investors);
        }

        public async Task<InvestorDTO> GetInvestorAsync(int id, CancellationToken cancellationToken)
        {
            var investor = await _investorRepository.GetInvestorAsync(id, cancellationToken);
            return _mapper.Map<InvestorDTO>(investor);
        }

        public async Task<List<InvestorDTO>> GetAllInvestorsByAdminAsync(CancellationToken cancellationToken)
        {
            var investors = await _investorRepository.GetAllInvestorsByAdminAsync(cancellationToken);
            return _mapper.Map<List<InvestorDTO>>(investors);
        }
        public async Task<List<InvestorDTO>> GetAllInvestorsAndInvestmentsAsync(CancellationToken cancellationToken)
        {
            var investors = await _investorRepository.GetAllInvestorsAndInvestmentsAsync(cancellationToken);
            return _mapper.Map<List<InvestorDTO>>(investors);
        }
        public async Task<InvestorDTO> GetInvestorAndInvestmentsAsync(int id, CancellationToken cancellationToken)
        {
            var investor = await _investorRepository.GetInvestorAndInvestmentsAsync(id, cancellationToken);
            return _mapper.Map<InvestorDTO>(investor);
        }

        public async Task<List<InvestorDTO>> GetAllInvestorsByFundIdAsync(int fundId, CancellationToken cancellationToken)
        {
            var investors = await _investorRepository.GetAllInvestorsByFundIdAsync(fundId, cancellationToken);
            return _mapper.Map<List<InvestorDTO>>(investors);
        }

        public async Task<List<InvestorDTO>> GetInvestorsAndInvestmentsByFundIdAsync(int fundId, CancellationToken cancellationToken)
        {
            var investors = await _investorRepository.GetInvestorsAndInvestmentsByFundIdAsync(fundId, cancellationToken);
            return _mapper.Map<List<InvestorDTO>>(investors);
        }

        public async Task<Investor> CreateInvestorAsync(Investor investor, CancellationToken cancellationToken)
        {
            return await _investorRepository.CreateInvestorAsync(investor, cancellationToken);
        }

        public async Task<InvestorDTO> UpdateInvestorAsync(InvestorDTO investor, CancellationToken cancellationToken)
        {
            var invest = await _investorRepository.UpdateInvestorAsync(_mapper.Map<Investor>(investor), cancellationToken);
            return _mapper.Map<InvestorDTO>(invest);
        }

        public async Task<bool> DeleteInvestorAsync(int id, CancellationToken cancellationToken)
        {
            return await _investorRepository.DeleteInvestorAsync(id, cancellationToken);
        }
    }
}
