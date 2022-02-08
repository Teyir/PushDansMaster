using Microsoft.AspNetCore.Mvc;
using PushDansMaster.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PushDansMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferenceController : ControllerBase
    {
        private readonly IReferenceService service;

        public ReferenceController(IReferenceService srv)
        {
            service = srv;
        }

        // GET: api/References/getall → get all adherents
        [HttpGet("getall/")]
        public IEnumerable<Reference_DTO> GetAllReferences()
        {
            return service.getAll().Select(f => new Reference_DTO()
            {
                ID = f.getID,
                libelle = f.getLibelle,
                reference = f.getReference,
                marque = f.getMarque,
                quantite = f.getQuantite

            });
        }

        // POST: api/References/insert → Insert a new PanierGlobal
        [HttpPost("insert/")]
        public ActionResult<Reference_DTO> Insert(Reference_DTO f)
        {
            Reference f_work = service.insert(new Reference(f.libelle, f.reference, f.marque, f.quantite));
            //Je récupère l'id References
            f.ID = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }


    }
}