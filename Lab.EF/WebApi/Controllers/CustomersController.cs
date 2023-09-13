using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Lab.EF.Logic;
using Lab.EF.Logic.DTO;

namespace WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        private CustomersLogic customerLogic = new CustomersLogic();

        // GET: api/Customer
        public IHttpActionResult Get()
        {
            try
            {
                List<CustomersDTO> shippers = customerLogic.GetAll();
                return Ok(shippers);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Customer/zzzz
        public IHttpActionResult Get(string id)
        {
            try
            {
                if (id.Length != 5)
                {
                    return BadRequest("La longitud del ID del cliente debe ser de 5 caracteres.");
                }

                CustomersDTO customer = customerLogic.Find(id);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customers

        //Se debe especificar el CustomerID en el body del request ya que no es autoincrementable
        public IHttpActionResult Post([FromBody] CustomersDTO customer)
        {
            try
            {
                customerLogic.Add(customer);
                return Created(Request.RequestUri + "/" + customer.CustomerID, customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // PUT: api/Customer/5
        public IHttpActionResult Put(string id, [FromBody] CustomersDTO customer)
        {
            try
            {
                customer.CustomerID = id;
                customerLogic.Update(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Customer/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                customerLogic.Delete(id);
                return Ok("Shipper eliminado con éxito.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}