using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PartnerGroupAPI.DAL;
using PartnerGroupAPI.Models;


namespace PartnerGroupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : Controller
    {
        private MarcaDAL marcaDAL = new MarcaDAL();

        [HttpGet()] //GET: Todas Marcas
        public JsonResult MarcaList()
        {
            List<Marcas> marcas = marcaDAL.GetAll();
            return Json(new { Result = "OK", Records = marcas });
        }

        [HttpGet("GetmarcaByID/{id}")] // Get por id de Marca
        public JsonResult GetmarcaByID(Guid id)
        {
            Marcas marca = marcaDAL.GetByID(id);
            if (marca != null)
            {
                return Json(new { Result = "OK", Records = marca });
            }
            else
            {
                return Json(new { Result = 404 });
            }
        }

        [HttpPost] // Post Marca - Insert        
        public JsonResult Insert(Marcas marca)
        {
            if (marcaDAL.ExistsMarca(marca.Nome))
            {
                ModelState.AddModelError("Nome", $"Esta marca '{marca.Nome}' já existe.");
            }
                       
            if (ModelState.IsValid)
            {
                marca.MarcaID = Guid.NewGuid();
                marcaDAL.Insert(marca);
                return Json("Marca cadastrada com sucesso.");
            }
            else
            {
                List<string> errors = (from x in ModelState.Values
                                       from error in x.Errors
                                       select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, errors));
            }
        }

        [HttpPut] // Put Marca - Edit/Update
        public JsonResult Edit(Marcas marca)
        {
            if (ModelState.IsValid)
            {
                marcaDAL.Update(marca);
                return Json("Marca alterada com sucesso.");
            }
            else
            {
                List<string> errors = (from x in ModelState.Values
                                       from error in x.Errors
                                       select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, errors));
            }
        }

        [HttpDelete("{id}")] // Post Marca - Delete
        public JsonResult Delete(Guid id)
        {
            marcaDAL.Delete(id);
            return Json(marcaDAL.GetAll());
        }

        [HttpGet("GetPatrimoniosByMarca/{id}")] // Get Marca + Patrimonios        
        public JsonResult GetPatrimoniosByMarca(Guid id)
        {
            List<Patrimonios> list = marcaDAL.GetPatrimonioByMarca(id);

            if (list.Count > 0)
            {
                return Json(new { Result = "OK", Records = list });
            }
            else
            {
                return Json(new { Result = 404 });
            }

        }

    }
}