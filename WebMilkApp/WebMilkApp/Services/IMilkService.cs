using WebMilkApp.Models;
using WebMilkApp.ViewModels;

namespace WebMilkApp.Services
{
    public interface IMilkService
    {
        Task <List<Milk>> AllMilkInfo(int offset, int count);
        Task <Milk> OneMilkInfo(Guid id);
        Task AddMilkInfo(List<AddMilkInfoRequestDto> addMilkInfoDto);
        Task<List<Milk>> SearchMilkInfo(string searchCriteria);
    }
}
