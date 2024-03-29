﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesWebApi_1.DTOs;
using MoviesWebApi_1.Entities;
using MoviesWebApi_1.Filters;
using MoviesWebApi_1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi_1.Controllers
{
    [Route("api/genres")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class GenresController:ControllerBase
    {

       
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger,
            ApplicationDBContext context,IMapper mapper)
        {
           
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] //api/gnres
        public async Task<ActionResult<List<GenreDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Genres.AsQueryable();
            await HttpContext.InsertParameterPaginationInHeader(queryable);
            var genres= await queryable.OrderBy(x=>x.Name).Paginate(paginationDTO).ToListAsync();
            
            return mapper.Map<List<GenreDTO>>(genres);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = context.Genres.OrderBy(x => x.Name).ToListAsync();           

            return mapper.Map<List<GenreDTO>>(genres);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == Id);

            if(genre==null)
            {
                return NotFound();
            }

            return mapper.Map<GenreDTO>(genre);
        
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if(genre==null)
            {
                return NotFound();
            }
            genre = mapper.Map(genreCreationDTO, genre);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Genres.AnyAsync(x => x.Id == id);

            if(!exists)
            {
                return NotFound();
            }
            context.Remove(new Genre() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
