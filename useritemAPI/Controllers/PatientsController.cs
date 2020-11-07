using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthAPI.Data;
using HealthAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace HealthAPI.Controllers
{
    [Route("TestDevWebService/services/user")]
    [ApiController]
    [EnableCors("HealthPolicy")]
    public class PatientsController : ControllerBase
    {
        private readonly HealthContext _context;

        public PatientsController(HealthContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> GetPatients()
        {
            return await _context.users
                .Include(m => m.items)
                .ThenInclude(m => m.propertys)
                .ToListAsync();
        }

        // GET: TestDevWebService/services/user/{username}
        [HttpGet("{username}")]
        public async Task<ActionResult<user>> GetPatient(string username)
        {
            var user = await _context.users
                .Include(m => m.items)
                .FirstOrDefaultAsync(i => i.username == username);


            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
