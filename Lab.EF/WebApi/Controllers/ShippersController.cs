using System;
using System.Collections.Generic;
using System.Web.Http;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;

namespace WebApi.Controllers
{
    public class ShippersController : ApiController
    {
        private ShippersLogic shipperLogic = new ShippersLogic();

        // GET: api/Shippers
        public IHttpActionResult Get()
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