using AutoMapper;
using Microsoft.VisualBasic;
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


        public async Task<List<StatementResponseDto>> FindStatementInfoByStatementFullNameAndStatusAsync(string fullName, StatementStatus status)
        {
            var statements = await _statementInfoRepository.FindStatementDtoByFullNameAndStatus(fullName, status);
            if (!statements.Any())
            {
                return new List<StatementResponseDto>();
            }

            return _mapper.Map<List<StatementResponseDto>>(statements);
        }

        public async Task<List<StatementResponseDto>> FindStatementInfoByStatementFullNameAsync(string fullName)
        {
            var statements = await _statementInfoRepository.FindStatementDtoByFullName(fullName);
            if (!statements.Any())
            {
                return new List<StatementResponseDto>();
            }

            return _mapper.Map<List<StatementResponseDto>>(statements);
        }

        public async Task<List<StatementResponseDto>> GetStatementsInfoByStatusAndFacultyAsync(StatementStatus status, string faculty)
        {
            var statements = await _statementInfoRepository.FindStatementInfoByStatusAndFacultyAsync(status, faculty);
            if (!statements.Any())
            {
                return new List<StatementResponseDto>();
            }

            return _mapper.Map<List<StatementResponseDto>>(statements);
        }

        public async Task<List<StatementResponseDto>> GetStatementsInfoWithStatusPendingAsync()
        {
            var statements = await _statementInfoRepository.FindStatementsInfoWithStatusPendingAsync();
            if (!statements.Any())
            {
                return new List<StatementResponseDto>();
            }

            return _mapper.Map<List<StatementResponseDto>>(statements);
        }

        public async Task<List<StatementResponseDto>> SearchByNameAsync(string name)
        {
            var statements = await _statementInfoRepository.FindStatementDtoByFullName(name);
            if (!statements.Any())
            {
                return new List<StatementResponseDto>();
            }

            return _mapper.Map<List<StatementResponseDto>>(statements);
        }
        }

        public async Task UpdateStatementStatusAsync(long statementId, StatementStatus status)
        {
            var statement = await _statementInfoRepository.GetByIdAsync(statementId);
            if (statement == null)
            {
                throw new ResourceNotFoundException("Statemnt not found");
            }
            await _statementInfoRepository.UpdateAsync(statementId, status);
        }
}
