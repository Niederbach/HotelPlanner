using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using HotelManagementLibrary.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services
{
    public class CustomerService : ICustomerService
    {
        public void CreateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {

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
        public void UpdateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options)
        {

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
