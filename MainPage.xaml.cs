using Maui_SQLite_Demo.Model;
using Maui_SQLite_Demo.Services;

namespace Maui_SQLite_Demo
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _localDbService; // LocalDbService instance for interacting with the SQLite database
        private int _editCustomerId; // Id of the customer being edited

        public MainPage(LocalDbService localDbService) // Inject LocalDbService into the MainPage constructor
        {
            InitializeComponent();
            _localDbService = localDbService; // Initialize the LocalDbService instance
            Task.Run(async () => listView.ItemsSource = await _localDbService.GetCustomersAsync()); // Load customers from the database and set them as the ItemsSource for the ListView
        }
        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if(_editCustomerId == 0)
            {
                // Create a new customer
                await _localDbService.Create(new Customer
                {
                    CustomerName = nameEntryField.Text,
                    Mobile = mobileEntryField.Text,
                    Email = emailEntryField.Text
                });
            }
            else
            {
                // Update an existing customer
                await _localDbService.Update(new Customer
                {
                    Id = _editCustomerId, // Set the Id of the customer being edited
                    CustomerName = nameEntryField.Text,
                    Mobile = mobileEntryField.Text,
                    Email = emailEntryField.Text
                });
                _editCustomerId = 0; // Reset the edit customer Id
            }

            // Enhance the UI by clearing the entry fields after saving
            nameEntryField.Text = string.Empty; // Clear the name entry field
            mobileEntryField.Text = string.Empty; // Clear the mobile entry field
            emailEntryField.Text = string.Empty; // Clear the email entry field

            // Refresh the ListView to display the updated list of customers
            listView.ItemsSource = await _localDbService.GetCustomersAsync();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var customer = (Customer)e.Item; // Retrieve the tapped customer from the event arguments
            var action = await DisplayActionSheet("Actions", "Cancel", null, "Edit", "Delete"); // Display an action sheet with options to edit or delete the customer

            switch(action)
            {
                case "Edit":
                    // Populate the entry fields with the customer details for editing
                    _editCustomerId = customer.Id; // Set the Id of the customer being edited
                    nameEntryField.Text = customer.CustomerName; // Populate the name entry field
                    mobileEntryField.Text = customer.Mobile; // Populate the mobile entry field
                    emailEntryField.Text = customer.Email; // Populate the email entry field
                    break;

                case "Delete":
                    // Delete the selected customer
                    await _localDbService.Delete(customer);
                    // Refresh the ListView to display the updated list of customers
                    listView.ItemsSource = await _localDbService.GetCustomersAsync();
                    break;
            }
        }
    }

}
