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
        public async Task<IActionResult> AllMilkInfo()
        {
            try
            {
                return Ok(await _milkService.AllMilkInfo());
            }
            catch (Exception e)
            {
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
              return Ok();
           }
           catch(Exception e)
           {
              throw new Exception (e.Message);
           }
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchMilkInfo([FromRoute] string name)
        {
          try
          {
                return Ok(await _milkService.SearchMilkInfo(name));
          }
          catch(Exception e)
          {
                if (e.Message.Contains("No Record Found"))
                   return NotFound();
                throw new Exception(e.Message);
          }
        }
    }
}
