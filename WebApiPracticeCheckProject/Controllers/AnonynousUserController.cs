using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPracticeCheckProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPracticeCheckProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonynousUserController : ControllerBase
    {
        MenuContext _menuContext;
        public AnonynousUserController(MenuContext menuContext)
        {
            _menuContext = menuContext;
        }


        [HttpGet]
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

    }
}
