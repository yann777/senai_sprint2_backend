﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }


        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IEnumerable<EstudioDomain> Get()
        {

            return _estudioRepository.ListarEstudio();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {

            _estudioRepository.Cadastrar(novoEstudio);


            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado");
            }

            return Ok(estudioBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {

                return NotFound
                    (
                        new
                        {
                            mensagem = "Estúdio não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                _estudioRepository.Atualizar(id, estudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {

            _estudioRepository.Deletar(id);


            return Ok("Estúdio deletado");
        }
    }
}
