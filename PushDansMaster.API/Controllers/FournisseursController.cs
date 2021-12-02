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

        // GET: api/Fournisseurs/getall → get all fournisseurs
        [HttpGet("getall/")]
        public IEnumerable<Fournisseurs_DTO> GetAllFournisseurs()
        {
            return service.getAll().Select(f => new Fournisseurs_DTO()
            {
                idFournisseur = f.getIdFournisseur,
                societeFournisseur = f.getSocieteFournisseur,
                civiliteFournisseur = f.getCiviliteFournisseur,
                nomFournisseur = f.getNomFournisseur,
                prenomFournisseur = f.getPrenomFournisseur,
                emailFournisseur = f.getEmailFournisseur,
                adresseFournisseur = f.getAdresseFournisseur
            });
        }

        // GET: api/Fournisseurs/get/5 → get a fournisseur
        [HttpGet("get/{id}")]
        public ActionResult<Fournisseurs_DTO> GetFournisseurs(int id)
        {
            var f = service.getByID(id);

            if (f == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new Fournisseurs_DTO()
            {

                idFournisseur = f.getIdFournisseur,
                societeFournisseur = f.getSocieteFournisseur,
                civiliteFournisseur = f.getCiviliteFournisseur,
                nomFournisseur = f.getNomFournisseur,
                prenomFournisseur = f.getPrenomFournisseur,
                emailFournisseur = f.getEmailFournisseur,
                adresseFournisseur = f.getAdresseFournisseur

            };
        }

        // POST: api/Fournisseurs/insert → Insert a new fournisseur
        [HttpPost("insert/")]
        public ActionResult<Fournisseurs_DTO> Insert(Fournisseurs_DTO f)
        {
            var f_work = service.insert(new Fournisseur(f.societeFournisseur, f.civiliteFournisseur, f.nomFournisseur, f.prenomFournisseur, f.emailFournisseur, f.adresseFournisseur));
            //Je récupère l'id fournisseur
            f.idFournisseur = f_work.getIdFournisseur;
            //je renvoie l'objet DTO
            return f;
        }

        // UPDATE: api/Fournisseurs/update/5 → Update a fournisseur
        [HttpPut("update/{id}")]
        public ActionResult<Fournisseurs_DTO> Update(Fournisseurs_DTO f, int id)
        {
            f.idFournisseur = id;

            var f_work = service.update(new Fournisseur(f.idFournisseur, f.societeFournisseur, f.civiliteFournisseur, f.nomFournisseur, f.prenomFournisseur, f.emailFournisseur, f.adresseFournisseur));

            return f;
        }

        // DELETE: api/Fournisseurs/delete/5 → Delete a fournisseur
        [HttpDelete("delete/{id}")]
        public void Delete(int id) //todo terminer delete ( utiliser le deleteById() )
        {
            var f = service.getByID(id);

            service.delete(new Fournisseur(f.getIdFournisseur, f.getSocieteFournisseur, f.getCiviliteFournisseur, f.getNomFournisseur, f.getPrenomFournisseur, f.getEmailFournisseur, f.getAdresseFournisseur));            
        }
    }
}