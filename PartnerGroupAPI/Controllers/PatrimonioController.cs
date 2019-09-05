using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartnerGroupAPI.DAL;
using PartnerGroupAPI.Models;

namespace PartnerGroupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimonioController : Controller
    {
        private PatrimonioDAL patrimonioDAL = new PatrimonioDAL();
       
        [HttpGet] //GET: Todos Patrimonios
        public JsonResult PatrimonioList()
        {
            List<Patrimonios> patrimonios = patrimonioDAL.GetAll();
            return Json(new { Result = "OK", Records = patrimonios });
        }

        [HttpGet("{id}")] // Get por id de patrimonio
        public JsonResult GetPatrimonioByID(Guid id)
        {
            Patrimonios patrimonio = patrimonioDAL.GetByID(id);
            if (patrimonio != null)
            {
                return Json(new { Result = "OK", Records = patrimonio});
            }
            else
            {
                return Json(new { Result = 404 });
            }
        }               

        [HttpPost] // Post Patrimonio - Insert
        public JsonResult Insert(Patrimonios patrimonio)
        {
            patrimonio.PatrimonioID = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                patrimonioDAL.Insert(patrimonio);
                return Json("Patrimonio cadastrado com sucesso.");
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

        [HttpPut] // Put Patrimonio - Edit/Update
        public JsonResult Edit(Patrimonios patrimonio)
        {
            if (ModelState.IsValid)
            {
                patrimonioDAL.Update(patrimonio);
                return Json("Patrimonio alterado com sucesso.");
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

        [HttpDelete("{id}")] // Post Patrimonio - Delete
        public JsonResult Delete(Guid id)
        {
            patrimonioDAL.Delete(id);
            return Json(patrimonioDAL.GetAll());
        }
             
    }
}