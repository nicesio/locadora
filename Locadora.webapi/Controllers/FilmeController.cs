using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Locadora.Domain;
using Locadora.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class FilmeController: ControllerBase
    {
        private readonly ILocadoraRepository _repo;
        // private readonly IMapper _mapper;


        public FilmeController(ILocadoraRepository repo)
        {
            // _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {           

            try
            {
                var filmes = await _repo.GetAllFilmeAsync(true);
                var results = (filmes);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int Id)
        {

            try
            {
                var filme = await _repo.GetAllFilmeAsyncById(Id, true);
                var results = (filme);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpGet("getByName/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string name)
        {

            try
            {
                var filme = await _repo.GetAllFilmeAsyncByName(name, true);
                var results = (filme);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(Filme model)
        {

            try
            {
                var filme = (model);
                _repo.Add(filme);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/filme/{model.Id}", (filme));
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();

        }

        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int Id, Filme model)
        {

            try
            {

                var filme = await _repo.GetAllFilmeAsyncById(Id, false);

                if (filme == null) return NotFound();

                // _mapper.Map(model, filme);

                _repo.Update(filme);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/filme/{model.Id}", (filme));
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();

        }

        [HttpDelete("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int Id)
        {

            try
            {

                var filme = await _repo.GetAllFilmeAsyncById(Id, false);

                if (filme == null) return NotFound();

                _repo.Delete(filme);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();

        }
    }
}