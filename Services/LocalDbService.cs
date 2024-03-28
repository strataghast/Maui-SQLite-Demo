using Maui_SQLite_Demo.Model;
using SQLite;

namespace Maui_SQLite_Demo.Services
{
    public class LocalDbService
    {
        private const string DB_NAME = "local.db"; // Name of the database file
        private readonly SQLiteAsyncConnection _connection; // Connection to the database

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME)); // Initialize the connection
            _connection.CreateTableAsync<Customer>().Wait(); // Create the "customer" table if it doesn't exist
        }

        // CRUD operations for the "customer" table

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _connection.Table<Customer>().ToListAsync(); // Retrieve all customers from the "customer" table
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _connection.Table<Customer>().Where(c => c.Id == id).FirstOrDefaultAsync(); // Retrieve a customer by Id
        }

        public async Task Create(Customer customer)
        {
            await _connection.InsertAsync(customer); // Insert a new customer into the "customer" table
        }

        public async Task Update(Customer customer)
        {
            await _connection.UpdateAsync(customer); // Update an existing customer in the "customer" table
        }

        public async Task Delete(Customer customer)
        {
            await _connection.DeleteAsync(customer); // Delete a customer from the "customer" table
        }
    }
}
