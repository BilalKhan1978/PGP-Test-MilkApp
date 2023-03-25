using Microsoft.AspNetCore.Mvc;
using WebMilkApp.Services;
using WebMilkApp.ViewModels;

namespace WebMilkApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MilkController : Controller
    {
        private readonly IMilkService _milkService;
        public MilkController(IMilkService milkService)
        {
            this._milkService = milkService;
        }

        [HttpGet]
        public async Task<IActionResult> AllMilkInfo(int offset, int count)
        {
            try
            {
                return Ok(await _milkService.AllMilkInfo(offset, count));
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Maximum limit is 50 records"))
                    return NotFound("Maximum limit is 50 records");
                if (e.Message.Contains("No record found"))
                    return NotFound("No record found");
                throw new Exception(e.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> OneMilkInfo([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _milkService.OneMilkInfo(id));
            }
            catch (Exception e)
            {
               if(e.Message.Contains("No Record Found"))
                   return NotFound(e.Message);
               throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMilkInfo([FromBody] List<AddMilkInfoRequestDto> addMilkInfoRequestDto)
        {
           try
           {
              await _milkService.AddMilkInfo(addMilkInfoRequestDto);
              return Ok("Desired infromation has been added");
           }
           catch(Exception e)
           {
              throw new Exception (e.Message);
           }
        }

        [HttpGet("search{query}")]
        public async Task<IActionResult> SearchMilkInfo([FromRoute] string query)
        {
          try
          {
                return Ok(await _milkService.SearchMilkInfo(query));
          }
          catch(Exception e)
          {
                if (e.Message.Contains("No record found"))
                   return NotFound("No record found");
                throw new Exception(e.Message);
          }
        }
    }
}
