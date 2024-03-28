using SQLite;

namespace Maui_SQLite_Demo.Model
{
    [Table("customer")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement] // Mark the Id property as the primary key and auto-incrementing (starting from 1)

        [Column("id")] // Map the Id property to the "id" column in the database
        public int Id { get; set; } // Unique identifier for the customer (primary key)

        [Column("customer_name")] // Map the CustomerName property to the "customer_name" column in the database
        public string CustomerName { get; set; } // Name of the customer

        [Column("mobile")] // Map the Mobile property to the "mobile" column in the database
        public string Mobile { get; set; } // Email address of the customer

        [Column("email")] // Map the Email property to the "email" column in the database
        public string Email { get; set; } // Mobile number of the customer
    }
}
