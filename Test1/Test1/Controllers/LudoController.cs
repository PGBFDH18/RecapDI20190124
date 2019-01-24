using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LudoGameEngine;
using Test1.Models;

namespace Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LudoController : ControllerBase
    {
        private static GamesContainer _games;

        public LudoController()
        {
            if (_games == null)
            {
                _games = new GamesContainer();
            }
        }

        // GET: api/Ludo
        [HttpGet]
        public List<LudoGame> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Ludo/5
        [HttpGet("{guid}", Name = "Get")]
        public LudoGameApi Get(string guid)
        {
            return new LudoGameApi() {StateOfGame= _games.GetGame(guid).GetGameState().ToString() };
        }

        // POST: api/Ludo
        [HttpPost("{guid}")]
        public void Post(string guid)
        {
            _games.GetGame(guid).AddPlayer(Guid.NewGuid().ToString(), PlayerColor.Green);
            _games.GetGame(guid).AddPlayer(Guid.NewGuid().ToString(), PlayerColor.Red);
        }

        // PUT: api/Ludo/5
        [HttpPut("{guid}")]
        public ActionResult Put(string guid)
        {
            try
            {
                // game started, HTTP status code: 200
                return Ok(_games.GetGame(guid).StartGame());
            }
            catch
            {
                // Not possible to start game, HTTP status code: 400
                return BadRequest(); 
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
