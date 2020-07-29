﻿using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectADApi.Controllers.V2.Contract;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerTag("New and improved version of the Artisan endpoints. This version give more detail about an artisan. You can see the order(s) an artisan has had. The project he/she has handled over time and lot more.")]
    public class ArtisanController : ControllerBase
    {
        readonly IRepository<Artisan> _artisanRepository;      
        private readonly IMapper _mapper;

        public ArtisanController(IRepository<Artisan> oniswOwoRepository, IMapper mapper)
        {
            _artisanRepository = oniswOwoRepository;
            _mapper = mapper;
        }

        // GET: api/OniseOwo        
        [HttpGet(ApiRoute.Artisan.GetAll)]
        public async Task<IActionResult> AwonOniseOwo()
        {
            IEnumerable<Artisan> AllArtisans = await _artisanRepository.GetAllAsync();

            if (AllArtisans.Any())
            {
                List<ArtisanResponse> sll = _mapper.Map<List<ArtisanResponse>>(AllArtisans);
                

                //var des = JsonConvert.DeserializeObject(ser);
                return Ok(new { status = HttpStatusCode.OK, message = sll });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, Message = "No records found" });
        }

        // GET: api/OniseOwo/5       
        [HttpGet(ApiRoute.Artisan.Get)]
        public async Task<IActionResult> ThisArtisan(int id)
        {
            if (id == 0)
                return BadRequest(new { status = HttpStatusCode.BadRequest, Message = "Artisan ID was not supplied" });
           
            var thisArtsan = await _artisanRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (thisArtsan == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "We could not find the artisan you requested" });

            ArtisanResponse _thisArtisan = _mapper.Map<ArtisanResponse>(thisArtsan);

            return Ok(new { status = HttpStatusCode.OK, Message = _thisArtisan });
        }

        // POST: api/OniseOwo
        [HttpPost(ApiRoute.Artisan.Create)]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] ArtisanRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = ModelState });
            }

            Artisan newArtisan = _mapper.Map<Artisan>(model);
           
            Artisan kooniseOwoTuntun = await _artisanRepository.CreateAsync(newArtisan);
            return CreatedAtAction(nameof(ThisArtisan), new { id = newArtisan.Id }, new { status = HttpStatusCode.Created, message = kooniseOwoTuntun });
        }

        //PUT: api/OniseOwo/5
        [HttpPut(ApiRoute.Artisan.Update)]
        public async Task<IActionResult> Put(int id, [FromBody] ArtisanRequest model)
        {
            Artisan thisArtisan = await _artisanRepository.GetByAsync(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (thisArtisan == null)
                return NotFound(new { status = HttpStatusCode.NotFound, message = "This Artisan was not found" });

            thisArtisan.FirstName = model.FirstName;
            thisArtisan.LastName = model.LastName;
            thisArtisan.PhoneNumber = model.PhoneNumber;
            thisArtisan.IdcardNo = model.IdcardNo;
            thisArtisan.PicturePath = model.PicturePath;
            thisArtisan.Address = model.Address;
            thisArtisan.State = model.State;
            thisArtisan.ArtisanCategoryId = model.ArtisanCategoryId;
            thisArtisan.AreaLocationId = model.AreaLocationId;
            thisArtisan.AboutMe = model.AboutMe;

            await _artisanRepository.UpdateAsync(thisArtisan);

            ArtisanResponse artisanUpdateResponse  = _mapper.Map<ArtisanResponse>(thisArtisan);
            return Ok(new { status = HttpStatusCode.OK, message = artisanUpdateResponse });
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete(ApiRoute.Artisan.Delete)]
        //public void Delete(int id)
        //{
        //}
    }
}
