using Microsoft.AspNetCore.Mvc;
using NetCore7_test_project.Models;
using NetCore7_test_project.Models.Dto;
using NetCore7_test_project.Data;

namespace NetCore7_test_project.Controllers
{
    [Route("api/villaAPI")]
    [ApiController]
    public class HouseAPIController:ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  ActionResult<IEnumerable<HouseDTO>> getVillas()
        {
            return Ok(VillaStore.house);
        }

        [HttpGet("theID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HouseDTO> getOneVilla(int theID)
        {
            var x = VillaStore.house.FirstOrDefault(house => house.Id == theID);
            if (x != null)
            {
                return Ok(x);
            }

            return NotFound("Data not found");
        }
    }
        

}
