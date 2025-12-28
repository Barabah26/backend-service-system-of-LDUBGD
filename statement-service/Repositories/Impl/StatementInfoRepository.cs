using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using statement_service.Data;

namespace statement_service.Repositories.Impl
{
    public class StatementInfoRepository : IStatementInfoRepository
    {
        private readonly AppDbContext _context;

        public StatementInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Statement statement)
        {
            // Створюємо StatementInfo з дефолтним статусом PENDING
            statement.StatementInfo = new StatementInfo
            {
                StatementStatus = StatementStatus.PENDING,
                IsReady = false
            };

            await _context.Statements.AddAsync(statement);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Statement>> GetAllAsync()
        {
            return await _context.Statements
                .Include(s => s.StatementInfo)
                .ToListAsync();
        }

        public async Task<Statement> GetByIdAsync(long id)
        {
            return await _context.Statements
                .Include(s => s.StatementInfo)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(long id, Statement statement)
        {
            _context.Statements.Update(statement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var statement = await GetByIdAsync(id);
            if (statement != null)
            {
                _context.Statements.Remove(statement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Statement>> FindStatementsInfoWithStatusPendingAsync()
        {
            return await _context.Statements
                .Include(s => s.StatementInfo)
                .Where(s => s.StatementInfo.StatementStatus == StatementStatus.PENDING)
                .ToListAsync();
        }

        public async Task<List<Statement>> FindStatementInfoByStatusAndFacultyAsync(string status, string faculty)
        {
            if (!Enum.TryParse<StatementStatus>(status, out var parsedStatus))
                throw new ArgumentException("Invalid status value");

            return await _context.Statements
                .Include(s => s.StatementInfo)
                .Where(s => s.StatementInfo.StatementStatus == parsedStatus && s.Faculty == faculty)
                .ToListAsync();
        }

        public async Task<List<Statement>> FindByNameContainingAsync(string name)
        {
            return await _context.Statements
                .Include(s => s.StatementInfo)
                .Where(s => s.FullName.Contains(name))
                .ToListAsync();
        }

        public async Task<List<Statement>> FindStatementDtoByFullName(string fullName)
        {
            return await _context.Statements
                .Include(s => s.StatementInfo)
                .Where(s => s.FullName == fullName)
                .ToListAsync();
        }

        public async Task<List<Statement>> FindStatementDtoByFullNameAndStatus(string fullName, string status)
        {
            if (!Enum.TryParse<StatementStatus>(status, out var parsedStatus))
                throw new ArgumentException("Invalid status value");

            return await _context.Statements
                .Include(s => s.StatementInfo)
                .Where(s => s.FullName == fullName && s.StatementInfo.StatementStatus == parsedStatus)
                .ToListAsync();
        }

        public async Task DeleteStatementIfReadyAsync(string status, long statementId, string faculty)
        {
            if (!Enum.TryParse<StatementStatus>(status, out var parsedStatus))
                throw new ArgumentException("Invalid status value");

            var statement = await _context.Statements
                .Include(s => s.StatementInfo)
                .FirstOrDefaultAsync(s =>
                    s.Id == statementId &&
                    s.Faculty == faculty &&
                    s.StatementInfo.StatementStatus == parsedStatus);

            if (statement != null)
            {
                _context.Statements.Remove(statement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Statement>> FindStatementInfoByStatusAsync(string status)
        {
            if (!Enum.TryParse<StatementStatus>(status, out var parsedStatus))
                throw new ArgumentException("Invalid status value");

            return await _context.Statements
                .Include(s => s.StatementInfo)
                .Where(s => s.StatementInfo.StatementStatus == parsedStatus)
                .ToListAsync();
        }

        public async Task<List<Statement>> FindStatementInfoByFacultyAsync(string faculty)
        {
            return await _context.Statements
                .Include(s => s.StatementInfo)
                .Where(s => s.Faculty == faculty)
                .ToListAsync();
        }

    }
}
