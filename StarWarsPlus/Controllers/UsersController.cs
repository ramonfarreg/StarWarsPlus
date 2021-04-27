using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsPlus.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponseDTO>> GetAll()
        {
            var items = _userService.GetAll();

            if (items == null) 
                return NotFound();

            return Ok(Mapper.Mapper.Map<IEnumerable<UserResponseDTO>>(items));
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponseDTO> Get(int id)
        {
            var user = _userService.Get(id);

            if (user == null) 
                return NotFound();

            return Mapper.Mapper.Map<UserResponseDTO>(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserUpdateRequestDTO userDTO)
        {
            if (id != userDTO.Id || !ModelState.IsValid)
                return BadRequest(ModelState);

            var user = Mapper.Mapper.Map<User>(userDTO);

            if (_userService.Get(user.Id) == null) 
                return NotFound();

            try
            {
                if (_userService.Update(user))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<UserResponseDTO> Create(UserRequestDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = Mapper.Mapper.Map<User>(userDTO);

            try
            {
                if (_userService.Add(user))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_userService.Get(id) == null) 
                return NotFound();

            try
            {
                _userService.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("/api/connections")]
        public ActionResult<ConnectionsDTO> GetConnections(string homeworld)
        {
            if (homeworld == null) 
                return BadRequest();

            var connections = _userService.GetConnections(homeworld);
            return Ok(Mapper.Mapper.Map<ConnectionsDTO>(connections));

        }

    }
}
