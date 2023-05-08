using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalks.api.Models.Domain;
using NzWalks.api.Repositories;

namespace NzWalks.api.Controllers
{
    [ApiController] //decorate our controler with this to let the app know this is the api conroller
   // [Route("Regions")] ////the name where it maps to the regioncontroller
    [Route("[controller]")] ////the name regions will be shown
    public class RegionsController : Controller
    {
        private readonly IRegionsRepository regionsRepository;
        private readonly IMapper mapper;

        //injected IRegionsRepository that refers to the sqlIRegionsRepository
        public RegionsController(IRegionsRepository regionsRepository, IMapper mapper) //use the mapper for replacing #1, ctrl . to create assign propery mapper
        {
            this.regionsRepository = regionsRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions() 
        {
            var regions = await regionsRepository.GetAllAsync();

            //static list, replaced by data in db
            /*var regions = new List<Regions>() 
            {
                new Regions
                {
                    id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "Wlg",
                    Area = 227755,
                    Lat = -1.8822,
                    Long = 299.88,
                    Population = 50000

                },

                new Regions {
                    id = Guid.NewGuid(),
                    Name = "Sunrise",
                    Code = "snr",
                    Area = 227755,
                    Lat = -1.8822,
                    Long = 299.88,
                    Population = 50000
                }
            }; */


            //replaced this with automaper - #1
            //retun DTO regions not the above domain model, converting it over to DTO
            /*var regionsDTO = new List<Models.DTO.Regions>();

            regions.ToList().ForEach(region =>
            {
                var regionDTO = new Models.DTO.Regions()
                {
                    id = region.id,
                    Code = region.Code,
                    Name = region.Name,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Population = region.Population
                };
                regionsDTO.Add(regionDTO); //help
            }); */

            var regionsDTO = mapper.Map<List<Models.DTO.Regions>>(regions); //return the list of domain regions
            
            return Ok(regionsDTO); //ok is a 200 response
        }
    }
}
