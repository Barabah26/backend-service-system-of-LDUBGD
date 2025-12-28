using AutoMapper;
using Shared.Entities;
using statement_service.Data;
using statement_service.DTOs;
using statement_service.Exceptions;
using statement_service.Repositories;
using statement_service.Services;

namespace statement_service.Services.Impl
{
    public class StatementInfoService : IStatementInfoService
    {
        private readonly IStatementInfoRepository _statementInfoRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public StatementInfoService(IStatementInfoRepository statementInfoRepository, IMapper mapper, IUserRepository userRepository)
        {
            _statementInfoRepository = statementInfoRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateStatementAsync(StatementDtoRequest dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                throw new ResourceNotFoundException("User not found");

            var statement = _mapper.Map<Statement>(dto);
            statement.User = user;

            await _statementInfoRepository.AddAsync(statement);
        }


        public Task<List<StatementResponseDto>> FindStatementInfoByStatementFullNameAndStatusAsync(string fullName, StatementStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<List<StatementResponseDto>> FindStatementInfoByStatementFullNameAsync(string fullName)
        {
            throw new NotImplementedException();
        }

        public Task<List<StatementResponseDto>> GetStatementsInfoByStatusAndFacultyAsync(StatementStatus status, string faculty)
        {
            throw new NotImplementedException();
        }

        public Task<List<StatementResponseDto>> GetStatementsInfoWithStatusPendingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StatementResponseDto>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatementStatusAsync(long statementId, StatementStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
