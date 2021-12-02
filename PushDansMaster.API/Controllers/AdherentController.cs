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
                idAdherent = f.getIDAdherent,
                societeAdherent = f.getSocieteAdherent,
                emailAdherent = f.getEmailAdherent,
                nomAdherent = f.getNomAdherent,
                prenomAdherent = f.getPrenomAdherent,
                adresseAdherent = f.getAdresseAdherent,
                dateAdhesionAdherent = f.getDateAdhesionAdherent,
                statusAdherent = f.getStatusAdherent
            });
        }

    }
}