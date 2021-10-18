using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Api.Models.Common;
using ECommerce.Core.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DealsController : ControllerBase
    {
        private readonly IGamesManager _usersManager;
        private readonly IMapper _mapper;

        public DealsController(IGamesManager usersManager, IMapper mapper)
        {
            _usersManager = usersManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetGameDeals([FromQuery(Name = "q")] string filterConditions)
        {
            try
            {
                var resultItems = await _usersManager.GetGamesAsync(filterConditions);
                return Ok(_mapper.Map<IEnumerable<GameDealModel>>(resultItems));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResultModel.CreateFailedResultModel(new List<string>() { ex.Message }));
            }
        }
    }
}
