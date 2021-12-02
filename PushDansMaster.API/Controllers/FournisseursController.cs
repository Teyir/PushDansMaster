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
    public class FournisseursController : ControllerBase
    {
        private IFournisseurService service;

        public FournisseursController(IFournisseurService srv)
        {
            service = srv;
        }

        [HttpGet]
        public IEnumerable<Fournisseurs_DTO> GetAllFournisseurs()
        {
            return service.getAll().Select(f => new Fournisseurs_DTO()
            {
                societeFournisseur = f.getSocieteFournisseur,
                civiliteFournisseur = f.getCiviliteFournisseur,
                nomFournisseur = f.getNomFournisseur,
                prenomFournisseur = f.getPrenomFournisseur,
                emailFournisseur = f.getEmailFournisseur,
                adresseFournisseur = f.getAdresseFournisseur
            });
        }

        [HttpPost]
        public Fournisseurs_DTO Insert(Fournisseurs_DTO f)
        {
            var f_work = service.insert(new Fournisseur(f.societeFournisseur, f.civiliteFournisseur, f.nomFournisseur, f.prenomFournisseur, f.emailFournisseur, f.adresseFournisseur));
            //Je récupère l'id fournisseur
            f.idFournisseur = f_work.getID;
            //je renvoie l'objet DTO
            return f;
        }
    }
}