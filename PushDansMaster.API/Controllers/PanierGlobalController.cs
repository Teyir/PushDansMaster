using System;
using PushDansMaster.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PushDansMaster.API;

namespace PushDansMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PanierGlobalController : ControllerBase
    {
        private IPanierGlobalService service;

        public PanierGlobalController(IPanierGlobalService srv)
        {
            service = srv;
        }

        // GET: api/PanierGlobal/getall → get all paniers adherents
        [HttpGet("getall/")]
        public IEnumerable<PanierGlobal_DTO> GetAllPanierGlobal()
        {
            return service.getAll().Select(f => new PanierGlobal_DTO()
            {
                ID = f.getID,
                status = f.getStatus,
                semaine = f.getSemaine,
            });
        }

        // GET: api/PanierGlobal/get/5 → get a panier global
        [HttpGet("get/{id}")]
        public ActionResult<PanierGlobal_DTO> GetPanierGlobal(int id)
        {
            var f = service.getByID(id);

            if (f == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new PanierGlobal_DTO()
            {

                ID = f.getID,
                status = f.getStatus,
                semaine = f.getSemaine,

            };
        }

        // POST: api/PanierGlobal/insert → Insert a new PanierGlobal
        [HttpPost("insert/")]
        public ActionResult<PanierGlobal_DTO> Insert(PanierGlobal_DTO f)
        {
            var f_work = service.insert(new PanierGlobal(f.status, f.semaine));
            //Je récupère l'id panierGlobal
            f.ID = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }


    }
}