using Microsoft.AspNetCore.Mvc;
using PushDansMaster.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PanierAdherentController : ControllerBase
    {
        private IPanierAdherentService service;

        public PanierAdherentController(IPanierAdherentService srv)
        {
            service = srv;
        }

        // GET: api/PanierAdherent/getall → get all paniers adherents
        [HttpGet("getall/")]
        public IEnumerable<PanierAdherent_DTO> GetAllPanierAdherents()
        {
            return service.getAll().Select(f => new PanierAdherent_DTO()
            {
                ID = f.getID,
                status = f.getStatus,
                semaine = f.getSemaine,
                id_adherent = f.getID_adherent,
                id_panierGlobal = f.getID_panierGlobal,
            });
        }

        // GET: api/PanierAdherent/get/5 → get a panier adherent
        [HttpGet("get/{id}")]
        public ActionResult<PanierAdherent_DTO> GetPanierAdherents(int id)
        {
            var f = service.getByID(id);

            if (f == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new PanierAdherent_DTO()
            {

                ID = f.getID,
                status = f.getStatus,
                semaine = f.getSemaine,
                id_adherent = f.getID_adherent,
                id_panierGlobal = f.getID_panierGlobal,

            };
        }

        // POST: api/PanierAdherent/insert → Insert a new PanierAdherent
        [HttpPost("insert/")]
        public ActionResult<PanierAdherent_DTO> Insert(PanierAdherent_DTO f)
        {
            var f_work = service.insert(new PanierAdherent(f.status, f.semaine, f.id_adherent, f.id_panierGlobal));
            //Je récupère l'id panierAdherent
            f.ID = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }

        // DELETE: api/PanierAdherent/delete/5 → Delete a PanierAdherent
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            service.deleteByID(id);
        }


    }
}