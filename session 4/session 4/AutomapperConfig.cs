using AutoMapper;
using session_4.Models.DTO;

namespace session_4
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            
        }
    }
}
