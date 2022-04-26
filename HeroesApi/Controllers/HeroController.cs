﻿using AutoMapper;
using HeroesApi.Data;
using HeroesApi.Data.Dtos;
using HeroesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController: ControllerBase
    {
        private HeroesContext _context;
        private IMapper _mapper;

        public HeroController(HeroesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<Hero> GetHeroes()
        {
            return _context.Heroes;
        }

        [HttpGet("{id}")]
        public IActionResult GetHeroById(int id)
        {
            Hero hero = _context.Heroes.FirstOrDefault(hero => hero.Id == id);

            if(hero != null)
            {
                HeroDto heroDto = _mapper.Map<HeroDto>(hero);

                return Ok(heroDto);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateHero([FromBody] HeroDto heroDto)
        {
            Hero hero = _mapper.Map<Hero>(heroDto);

            _context.Heroes.Add(hero);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHeroById), new {Id = hero.Id }, hero);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHero(int id, [FromBody] HeroDto heroDto)
        {
            Hero hero = _context.Heroes.FirstOrDefault(hero => hero.Id == id);

            if (hero == null)
            {
                return NotFound();
            }

            _mapper.Map(heroDto, hero);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHero(int id)
        {
            Hero hero = _context.Heroes.FirstOrDefault(hero => hero.Id == id);

            if (hero == null)
            {
                return NotFound();
            }

            _context.Remove(hero);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
