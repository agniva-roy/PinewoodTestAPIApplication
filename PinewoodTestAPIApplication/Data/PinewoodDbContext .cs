using PinewoodTestAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PinewoodTestAPIApplication.Data
{
    public class PinewoodDbContext : DbContext
    {
        public PinewoodDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public void addCustomer(Customer customer)
        {
            using (var context = new PinewoodDbContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void removeCustomer(int id)
        {
            using (var context = new PinewoodDbContext())
            {
                var Customer = context.Customers.FirstOrDefault(c => c.Id == id);
                if (Customer != null)
                {
                    context.Customers.Remove(Customer);
                    context.SaveChanges();
                }  
            }
        }

        public List<Customer> getAllCustomer()
        {
            using (var context = new PinewoodDbContext())
            {
                var customer = context.Customers.ToList();
                return customer;
            }
        }

        public Customer getCustomer(int id)
        {
            Customer CustomerData = new Customer();
            using (var context = new PinewoodDbContext())
            {
                
                var Customer = context.Customers.FirstOrDefault(c => c.Id == id);
                if (Customer != null)
                    CustomerData = Customer;
            }
            
                return CustomerData;
        }

        public void editCustomer(Customer customer)
        {
            using (var context = new PinewoodDbContext())
            {
                var existingCustomer = context.Customers.FirstOrDefault(c => c.Id == customer.Id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Email = customer.Email;
                    context.SaveChanges();
                } 
            }
        }
    }
}