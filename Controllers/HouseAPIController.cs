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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<HouseDTO> addHouse(HouseDTO house)
        {
            if (house.Id!=0 && house.Name!="")
            {
                VillaStore.house.Add(house);
                return Ok("House added successfully");
            }
            return BadRequest("The provided data isnot valid");

        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<HouseDTO> updateHouseHouse(int id,HouseDTO house)
        {
            try
            {
                var foundHouse = VillaStore.house.FirstOrDefault(house => house.Id == id);
                if (foundHouse != null)
                {
                    foundHouse.Id = house.Id;
                    foundHouse.Name = house.Name;
                    return Ok("House updated successfully");

                }
                else
                {
                    return NotFound("House not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            }

        [HttpDelete("theID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HouseDTO> deleteVilla(int theID)
        {
            try {
                var x = VillaStore.house.FirstOrDefault(house => house.Id == theID);
                if (x != null)
                {
                    VillaStore.house.Remove(x);
                    return Ok("Data deleted successfully");
                }

                return NotFound("Data not found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


    }
    }
        


