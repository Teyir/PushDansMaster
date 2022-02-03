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
    public class AdherentController : ControllerBase
    {
        private IAdherentService service;

        public AdherentController(IAdherentService srv)
        {
            service = srv;
        }

        // GET: api/Adherents/getall → get all adherents
        [HttpGet("getall/")]
        public IEnumerable<Adherent_DTO> GetAllAdherents()
        {
            return service.getAll().Select(f => new Adherent_DTO()
            {
                idAdherent = f.getIdAdherent,
                societeAdherent = f.getSocieteAdherent,
                emailAdherent = f.getEmailAdherent,
                nomAdherent = f.getNomAdherent,
                prenomAdherent = f.getPrenomAdherent,
                adresseAdherent = f.getAdresseAdherent,
                dateAdhesionAdherent = f.getDateAdhesionAdherent,
                statusAdherent = f.getStatusAdherent
            });
        }

        // GET: api/Adherents/get/5 → get an adherent
        [HttpGet("get/{id}")]
        public ActionResult<Adherent_DTO> GetAdherent(int id)
        {
            var f = service.getByID(id);

            if (f == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new Adherent_DTO()
            {

                idAdherent = f.getIdAdherent,
                societeAdherent = f.getSocieteAdherent,
                emailAdherent = f.getEmailAdherent,
                nomAdherent = f.getNomAdherent,
                prenomAdherent = f.getPrenomAdherent,
                adresseAdherent = f.getAdresseAdherent,
                dateAdhesionAdherent = f.getDateAdhesionAdherent,
                statusAdherent = f.getStatusAdherent

            };
        }

        // POST: api/Adherents/insert → Insert a new adherent
        [HttpPost("insert/")]
        public ActionResult<Adherent_DTO> Insert(Adherent_DTO f)
        {
            var f_work = service.insert(new Adherent(f.societeAdherent, f.emailAdherent, f.nomAdherent, f.prenomAdherent, f.adresseAdherent, DateTime.Now, f.statusAdherent));
            //Je récupère l'id adherent
            f.idAdherent = f_work.getIdAdherent;
            //je renvoie l'objet DTO
            return f;
        }

        // UPDATE: api/Adherent/update/5 → Update an adherent
        [HttpPut("update/{id}")]

        public ActionResult<Adherent_DTO> Update(Adherent_DTO f, int id)

        {
            f.idAdherent = id;

            var f_work = service.update(new Adherent(f.idAdherent, f.societeAdherent, f.emailAdherent, f.nomAdherent, f.prenomAdherent, f.adresseAdherent, f.statusAdherent));

            return f;
        }

        // DELETE: api/Adherent/delete/5 → Delete an adherent
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            service.deleteByID(id);
        }

    }
}