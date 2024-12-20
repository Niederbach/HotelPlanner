using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services.ServiceInterfaces
{
    public interface ICustomerService
    {
        void CreateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        void DeleteCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email);
        List<Customer> GetAllCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        Customer GetSingleCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email);
        void UpdateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        void RecoverCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email);
        List<Customer> GetAllDeletedCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
    }
}