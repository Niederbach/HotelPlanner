using HotelManagementLibrary.Data;
using HotelManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementLibrary.Services.ServiceInterfaces
{
    public interface ICustomerService
    {
        void CreateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string firstName, string lastName, string email, string phoneNummer, string address, string city, string country, string postalcode);
        void DeleteCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email);
        List<Customer> GetAllCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
        Customer GetSingleCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email);
        void UpdateCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string newInformation, Customer customer, int selectedInput);
        void RecoverCustomer(DbContextOptionsBuilder<ShabbyChateauDbContext> options, string email);
        List<Customer> GetAllDeletedCustomers(DbContextOptionsBuilder<ShabbyChateauDbContext> options);
    }
}