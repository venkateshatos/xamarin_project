using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginUser.ViewModels
{
    public class ChangePasswordViewModel : INotifyPropertyChanged
    {
        private string currentPassword;
        private string newPassword;
        private string confirmPassword;
        private readonly SQLiteConnection database;

        public ICommand ChangePasswordCommand { get; }

        public string CurrentPassword
        {
            get { return currentPassword; }
            set
            {
                currentPassword = value;
                OnPropertyChanged();
            }
        }

        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public ChangePasswordViewModel(SQLiteConnection database)
        {
            this.database = database;
            ChangePasswordCommand = new Command(ChangePassword);
        }

        private void ChangePassword()
        {
            // Check if the new password matches the confirmation
            if (NewPassword != ConfirmPassword)
            {
                // Display an error message or handle the validation appropriately
                return;
            }

            // Validate the current password (you may have your own validation logic)
            if (!ValidateCurrentPassword(CurrentPassword))
            {
                // Display an error message or handle the validation appropriately
                return;
            }

            // Change the password using SQLite PRAGMA rekey
            try
            {
                database.Execute("PRAGMA rekey = '" + NewPassword + "';");
                // Password changed successfully
            }
            catch (Exception)
            {
                // Handle the exception appropriately
            }
        }

        private bool ValidateCurrentPassword(string currentPassword)
        {
            // Execute a SELECT query to check if the current password matches the stored password
            var query = "SELECT COUNT(*) FROM UserTable WHERE Password = ?";
            var result = database.ExecuteScalar<int>(query, currentPassword);

            // If the result is greater than 0, it means a match was found
            return result > 0;
        }

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
