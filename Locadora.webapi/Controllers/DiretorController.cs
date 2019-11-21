using Locadora.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using Locadora.Domain;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System;

namespace Locadora.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class DiretorController: ControllerBase
    {
       private readonly ILocadoraRepository _repo;
        // private readonly IMapper _mapper;


        public DiretorController(ILocadoraRepository repo)
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
                var diretores = await _repo.GetAllDiretorAsync(true);
                var results = (diretores);
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
                var diretor = await _repo.GetAllDiretorAsyncById(Id, true);
                var results = (diretor);
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
                var diretor = await _repo.GetAllDiretorAsyncByName(name, true);
                var results = (diretor);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(Diretor model)
        {

            try
            {
                var diretor = (model);
                _repo.Add(diretor);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/diretor/{model.Id}", (diretor));
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
        public async Task<IActionResult> Put(int Id, Diretor model)
        {

            try
            {

                var diretor = await _repo.GetAllDiretorAsyncById(Id, false);

                if (diretor == null) return NotFound();

                // _mapper.Map(model, diretor);

                _repo.Update(diretor);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/diretor/{model.Id}", (diretor));
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

                var diretor = await _repo.GetAllDiretorAsyncById(Id, false);

                if (diretor == null) return NotFound();

                _repo.Delete(diretor);

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