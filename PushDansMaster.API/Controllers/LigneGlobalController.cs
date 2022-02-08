﻿using System;
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
    public class LigneGlobalController : ControllerBase
    {
        private ILigneGlobalService service;
        
        public LigneGlobalController(ILigneGlobalService srv)
        {
            service = srv;
        }


        // POST: api/LigneGlobal/insert → Insert a new LigneGlobal
        [HttpPost("insert/")]
        public ActionResult<LigneGlobal_DTO> Insert(LigneGlobal_DTO f)
        {
            var f_work = service.insert(new LignesGlobal(f.id_panier, f.quantite, f.reference, f.id_reference));
            //Je récupère l'id LigneGlobal
            f.ID = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }


    }
}