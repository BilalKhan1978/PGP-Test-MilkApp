using Microsoft.AspNetCore.Mvc;
using WebMilkApp.Services;
using WebMilkApp.ViewModels;

namespace WebMilkApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilkController : Controller
    {
        // Inject the following services
        private readonly IMilkService _milkService;
        private readonly ILogger<MilkController> _logger;
        public MilkController(IMilkService milkService, ILogger<MilkController> logger)
        {
            this._milkService = milkService;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<IActionResult> AllMilkInfo(int offset, int count)
        {
            _logger.LogInformation("Inside the AllMilkInfo");
            try
            {
                if (count < 1 || count > 50) throw new Exception("Count only accept from 1 to 50");
                return Ok(await _milkService.AllMilkInfo(offset, count));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                if (e.Message.Contains("Count only accept from 1 to 50"))
                    return BadRequest("Count only accept from 1 to 50");
                if (e.Message.Contains("No record found"))
                    return NotFound("No record found");
                throw new Exception(e.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> OneMilkInfo([FromRoute] Guid id)
        {
            _logger.LogInformation("Inside the OneMilkInfo");
            try
            {
                return Ok(await _milkService.OneMilkInfo(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                if (e.Message.Contains("No Record Found"))
                   return NotFound(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMilkInfo([FromBody] List<AddMilkInfoRequestDto> addMilkInfoRequestDto)
        {
           try
           {
                _logger.LogInformation("Inside the AddMilkInfo");
                await _milkService.AddMilkInfo(addMilkInfoRequestDto);
                return Ok("Desired infromation has been added");
           }
           catch(Exception e)
           {
                _logger.LogError(e.Message);
                throw new Exception (e.Message);
           }
        }

        [HttpGet("search{query}")]
        public async Task<IActionResult> SearchMilkInfo([FromRoute] string query)
        {
          try
          {
                _logger.LogInformation("Inside the SearchMilkInfo");
                return Ok(await _milkService.SearchMilkInfo(query));
          }
          catch(Exception e)
          {
                _logger.LogError(e.Message);
                if (e.Message.Contains("No record found"))
                   return NotFound("No record found");
                throw new Exception(e.Message);
          }
        }
    }
}
