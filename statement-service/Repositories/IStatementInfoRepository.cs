using Shared.Entities;
using statement_service.DTOs;

namespace statement_service.Repositories
{
    public interface IStatementInfoRepository
    {
        Task<List<Statement>> FindStatementsInfoWithStatusPendingAsync();
        Task<List<Statement>> FindStatementInfoByFacultyAsync(string faculty);
        Task<List<Statement>> FindStatementInfoByStatusAsync(string status);
        Task<List<Statement>> FindStatementInfoByStatusAndFacultyAsync(string status, string faculty);
        Task DeleteStatementIfReadyAsync(string status, long statementId, string faculty);
        Task<List<Statement>> FindByNameContainingAsync(string name);
        Task<List<Statement>> FindStatementDtoByFullName(string fullName);
        Task<List<Statement>> FindStatementDtoByFullNameAndStatus(string fullName, string status);
        Task<Statement> GetByIdAsync(long id);
        Task<List<Statement>> GetAllAsync();
        Task AddAsync(Statement statement);
        Task UpdateAsync(long id, Statement statement);
        Task DeleteAsync(long id);

    }
}
