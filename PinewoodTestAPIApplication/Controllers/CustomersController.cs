using PinewoodTestAPIApplication.Data;
using PinewoodTestAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PinewoodTestAPIApplication.Controllers
{
    public class CustomersController : ApiController
    {
        private List<Customer> customers = new List<Customer>();

        PinewoodDbContext pinewoodDbContext = new PinewoodDbContext();

        // GET All: api/customers
        public IHttpActionResult Get()
        {
            try
            {
                List<Customer> CustomersList = new List<Customer>();
                CustomersList = pinewoodDbContext.getAllCustomer().ToList();
                return Ok(CustomersList);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/customers/{id}
        public IHttpActionResult Get(int id)
        {
            try
            {
                Customer CustomerData = new Customer();
                CustomerData = pinewoodDbContext.getCustomer(id);

                return Ok(CustomerData);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Add: api/customers
        public IHttpActionResult Post(Customer customer)
        {
            try
            {
                pinewoodDbContext.addCustomer(customer);

                return Ok("Customer created successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Edit: api/customers/{id}
        public IHttpActionResult Put(int id, Customer customer)
        {
            try
            {
                pinewoodDbContext.editCustomer(customer);

                return Ok("Customer updated successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/customers/{id}
        public IHttpActionResult Delete(int id)
        {
            try
            {
                pinewoodDbContext.removeCustomer(id);

                return Ok("Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}