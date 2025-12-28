using Microsoft.AspNetCore.Mvc;
using statement_service.DTOs;
using statement_service.Services;


namespace statement_service.Controllers
{
    [ApiController]
    [Route("api/statements")]
    public class StatementController : ControllerBase
    {
        private readonly IStatementInfoService _statementService;

        public StatementController(IStatementInfoService statementService)
        {
            _statementService = statementService;
        }

        [HttpPost("createStatement")]
        public async Task<IActionResult> CreateStatement([FromBody] StatementDtoRequest statementRequestDto)
        {
            await _statementService.CreateStatementAsync(statementRequestDto);
            return Ok("Statement created successfully");
            
            
        }
    }
}
