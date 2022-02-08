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
    public class LigneAdherentController : ControllerBase
    {
        private ILigneAdherentService service;
        
        public LigneAdherentController(ILigneAdherentService srv)
        {
            service = srv;
        }


        // POST: api/LigneAdherent/insert → Insert a new LigneAdherent
        [HttpPost("insert/")]
        public ActionResult<LigneAdherent_DTO> Insert(LigneAdherent_DTO f)
        {
            var f_work = service.insert(new LignesAdherent(f.id_panier, f.id_reference, f.Quantite));
            //Je récupère l'id LigneAdherent
            f.ID = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }


    }
}