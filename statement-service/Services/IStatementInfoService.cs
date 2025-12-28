using Shared.Entities;
using statement_service.DTOs;

namespace statement_service.Services
{
    public interface IStatementInfoService
    {
        Task CreateStatementAsync(StatementDtoRequest statementDtoRequest);

        Task<List<StatementResponseDto>> GetStatementsInfoWithStatusPendingAsync();

        Task UpdateStatementStatusAsync(long statementId, StatementStatus status);

        Task<List<StatementResponseDto>> GetStatementsInfoByStatusAndFacultyAsync(StatementStatus status, string faculty);

        Task<List<StatementResponseDto>> SearchByNameAsync(string name);

        Task<List<StatementResponseDto>> FindStatementInfoByStatementFullNameAsync(string fullName);

        Task<List<StatementResponseDto>> FindStatementInfoByStatementFullNameAndStatusAsync(string fullName, StatementStatus status);
    }
}
