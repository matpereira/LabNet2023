using System;
using System.Collections.Generic;
using System.Web.Http;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Shippers")]
    public class ShippersController : ApiController
    {
        private ShippersLogic shipperLogic = new ShippersLogic();

        // GET: api/Shippers
        [HttpGet]
        [Route("GetAllShippers")]
        public IHttpActionResult GetAllShippers()
        {
           
            try
            {
                List<ShippersDTO> shippers = shipperLogic.GetAll();
                return Ok(shippers);
            }
            catch (Exception ex)    
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Shippers/5
        [HttpGet]
        [Route("GetShipper")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                ShippersDTO shipper = shipperLogic.Find(id);
                if (shipper == null)
                    return NotFound();

                return Ok(shipper);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Shippers
        [HttpPost]
        [Route("AddShippers")]
        public IHttpActionResult Post([FromBody] ShippersDTO shipper)
        {
            try
            {
                shipperLogic.Add(shipper);
                return Created(Request.RequestUri + "/" + shipper.ShipperID, shipper);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Shippers/5
        [HttpPut]
        [Route("UpdateShipper")]
        public IHttpActionResult Put(int id, [FromBody] ShippersDTO shipper)
        {
            try
            {
                shipper.ShipperID = id;
                shipperLogic.Update(shipper);
                return Ok(shipper);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Shippers/5
        [HttpDelete]
        [Route("DeleteShipper")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                shipperLogic.Delete(id);
                return Ok("Shipper eliminado con éxito.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}