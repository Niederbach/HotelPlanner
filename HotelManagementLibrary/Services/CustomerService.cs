using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services
{
    public class CustomerService : ICustomerService
    {
        public void CreateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string firstName, string lastName, string email, string phoneNummer, string address, string city, string country, string postalcode)
        {
            using (var context  = new ShabbyChateauDbContext(options.Options))
            {
                var customer = new Customer()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city,
                    Country = country,
                    Phone = phoneNummer,
                    PostalCode = postalcode,
                    Email = email,
                    IsActive = true,
                };
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
        public Customer GetSingleCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                return context.Customers.First(x => x.Email == email);
            }
        }
        public List<Customer> GetAllCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                return context.Customers.Where(x => x.IsActive).ToList();
            }
        }
        public void UpdateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string newInforamtion, Customer customer, int selectedInput)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                var customerUpdate = context.Customers.First(x => x.CustomerId == customer.CustomerId);
                if (selectedInput == 1)
                {
                    customerUpdate.FirstName = newInforamtion;
                }
                else if (selectedInput == 2)
                {
                    customerUpdate.LastName = newInforamtion;
                }
                else if (selectedInput == 3)
                {
                    customerUpdate.Email = newInforamtion;
                }
                else if (selectedInput == 4)
                {
                    customerUpdate.Phone = newInforamtion;
                }
                else if (selectedInput == 5)
                {
                    customerUpdate.Address = newInforamtion;
                }
                else if (selectedInput == 6)
                {
                    customerUpdate.City = newInforamtion;
                }
                else if (selectedInput == 7)
                {
                    customerUpdate.Country = newInforamtion;
                }
                else if (selectedInput == 8)
                {
                    customerUpdate.PostalCode = newInforamtion;
                }
                context.SaveChanges();
            }
        }
        public void DeleteCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                var customer = context.Customers.First(x => x.Email == email);
                customer.IsActive = false;
                context.SaveChanges();
            } 
        }
        public void RecoverCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                var customer = context.Customers.First(x => x.Email == email);
                customer.IsActive = true;
                context.SaveChanges();
            }
        }
        public List<Customer> GetAllDeletedCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {
            using (var context = new ShabbyChateauDbContext(options.Options))
            {
                return context.Customers.Where(x => x.IsActive == false).ToList();
            }
        }

        
    }
}
