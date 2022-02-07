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
    public class ReferenceController : ControllerBase
    {
        private IReferenceService service;
        
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


    }
}