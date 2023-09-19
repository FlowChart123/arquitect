using Domain.Dto;
using Domain.Interfaces.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Domain.Interfaces;
using Domain.Services;
using Infra.Repository.Generics;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenericListController : ControllerBase
    {

        private readonly GenericListRepository _repo;

        public GenericListController(GenericListRepository repo)
        {
            _repo = repo;
        }

    }
}

