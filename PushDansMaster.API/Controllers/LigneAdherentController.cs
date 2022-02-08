using Microsoft.AspNetCore.Mvc;
using PushDansMaster.DTO;

namespace PushDansMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LigneAdherentController : ControllerBase
    {
        private readonly ILigneAdherentService service;

        public LigneAdherentController(ILigneAdherentService srv)
        {
            service = srv;
        }


        // POST: api/LigneAdherent/insert → Insert a new LigneAdherent
        [HttpPost("insert/")]
        public ActionResult<LigneAdherent_DTO> Insert(LigneAdherent_DTO f)
        {
            LignesAdherent f_work = service.insert(new LignesAdherent(f.id_panier, f.id_reference, f.Quantite));
            //Je récupère l'id LigneAdherent
            f.ID = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }


    }
}