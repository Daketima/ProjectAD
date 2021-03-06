﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Data;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Response;

namespace ProjectADApi.Controllers.V2
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiVersion("1.1")]
    public class StateLocalGovermentController : ControllerBase
    {
        readonly IRepository<State> _stateRepository;
        readonly IRepository<Lga> _localGovernmentRepository;
        private readonly IMapper _mapper;
        bluechub_ProjectADContext _dbContext;
        public StateLocalGovermentController(IRepository<State> stateRepository, IRepository<Lga> localGovernmentRepository, IMapper mapper, bluechub_ProjectADContext DbContext)
        {
            _stateRepository = stateRepository;
            _localGovernmentRepository = localGovernmentRepository;
            _mapper = mapper;
            _dbContext = DbContext;
        }

        // GET: api/States
        [HttpGet(ApiRoute.StateLocalGovernment.ThisState)]
        public async Task<IActionResult> ThisState(int stateId)
        {
            var thisState = _mapper.Map<StateResponse>(await _stateRepository.GetByAsync(x => x.Id.Equals(stateId)).FirstOrDefaultAsync());
            //       var thisState = await _stateRepository.GetByAsync(x => x.Id.Equals(stateId)).FirstOrDefaultAsync();
            //       var des = JsonConvert.SerializeObject(thisState, Formatting.Indented, new JsonSerializerSettings()
            //       {
            //           ReferenceLoopHandling
            //= Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //       });


            return Ok(new { status = HttpStatusCode.Created, message = thisState });
        }

        // GET: api/States/5
        [HttpGet(ApiRoute.StateLocalGovernment.AllState)]
        public async Task<IActionResult> AllState()
        {
            IEnumerable<State> allState = await _stateRepository.GetAllAsync();
            //       var thisState = await _stateRepository.GetAllAsync();
            //       var des = JsonConvert.SerializeObject(thisState, Formatting.Indented, new JsonSerializerSettings()
            //       {
            //           ReferenceLoopHandling
            //= Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //       });

            if (allState.Any())
            {
                List<StateResponse> allStates = _mapper.Map<List<StateResponse>>(allState);
                return Ok(new { status = HttpStatusCode.OK, message = allStates });
            }
            return NoContent();
        }

        //POST: api/States
        [HttpGet(ApiRoute.StateLocalGovernment.AllLocalGovernment)]
        public async Task<IActionResult> AllLocalGoverments(int StateId)
        {
            //var thisState = _mapper.Map<StateResponse>( await _stateRepository.GetByIdAsync(stateId));
            var thisState = await _dbContext.Lga.Select(s => new Lga { Lga1 = s.Lga1, StateId = s.StateId, Id = s.Id }).Where(s => s.StateId == StateId).ToListAsync();
            var des = JsonConvert.SerializeObject(thisState, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling
     = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Ok(new { status = HttpStatusCode.Created, message = JsonConvert.DeserializeObject(des) });
        }

        //// PUT: api/States/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }
    public class StateModel
    {
        public int StateId { get; set; }
    }
}
