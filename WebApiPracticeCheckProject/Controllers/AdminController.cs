using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiPracticeCheckProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPracticeCheckProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        MenuContext _menuContext;
        public AdminController(MenuContext menuContext)
        {
            _menuContext = menuContext;
        }

        // GET: api/<AdminController>
        [HttpGet]
        [Authorize(Roles="Admin")]
        public IActionResult Get()
        {
            try
            {
                List<MenuItem> menuItems = _menuContext.menuItems.ToList();
                return Ok(menuItems);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPut]
        public async Task<ActionResult<MenuItem>> Put(MenuItem menuItem)
        {
            try
            {
                var menu = _menuContext.menuItems.FirstOrDefault(mv => mv.MenuId == menuItem.MenuId);
                menu.MenuName = menuItem.MenuName;
                await _menuContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Exception..." + e.Message);
            }
            return Ok(menuItem);
        }
    }
}
