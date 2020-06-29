using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoApp.API.Data;
using DemoApp.API.Dtos;
using DemoApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUsers _repo;
        private readonly IMapper _mapper;
        public UsersController(DataContext context, IUsers repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var listOfUsers = _mapper.Map<IEnumerable<UserListDto>>(users);

            return Ok(listOfUsers);
        }
    }
}