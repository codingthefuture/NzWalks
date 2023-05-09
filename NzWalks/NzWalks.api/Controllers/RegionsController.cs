using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzWalks.api.Models.Domain;
using NzWalks.api.Models.DTO;
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


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")] //#2
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
           var region = await regionsRepository.GetAsync(id);

            if(region == null)
            {
                return NotFound();
            }

           var regionDto = mapper.Map<Models.DTO.Regions>(region); //the soure is the region and destionation is the models.dto.regions

           return Ok(regionDto); //data response
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest) //gpt note help
         {

            //Convert request(DTO) to domain model
            var region = new Models.Domain.Regions()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population
            };


            //pass details to repository

            region = await regionsRepository.AddAsync(region); //reusing the same var above with new value

            //convert data back to dto for the client

            var regionDTO = new Models.DTO.Regions
            {
                id = region.id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            //passing the whole action back to the client
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.id }, regionDTO); // refer to #2 for action name only
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //get regions from database
            var deletedRegion = await regionsRepository.DeleteAync(id);

            //if not found send notFound
            if(deletedRegion == null)
            {
                return NotFound();
            }

            //convert response back to DTO
            var regionDTO = new Models.DTO.Regions
            {
                Code = deletedRegion.Code,
                Area = deletedRegion.Area,
                Lat = deletedRegion.Lat,
                Long = deletedRegion.Long,
                Name = deletedRegion.Name,
                Population = deletedRegion.Population
            };

            //return a ok response with data back to client
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest) //gpt - help FromBody and FromRoute
        {
            //convert DTO to domain model
            var region = new Models.Domain.Regions()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population
            };

            //update region using repository
            region = await regionsRepository.UpdateAsync(id, region);
            

            //if null then notFound
            if(region == null)
            {
                return NotFound();
            }

            //Convert domain back to DTO


            var regionDTO = new Models.DTO.Regions
            {
                id = region.id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            //return OK Response
            return Ok(regionDTO);
        }
             
    }
}
