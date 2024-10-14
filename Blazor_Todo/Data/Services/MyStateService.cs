namespace Blazor_Todo.Data.Services
{
    public class MyStateService
    {
        // Fields to store the state
        public string? UserName { get; private set; }
        public bool IsLoggedIn { get; private set; }

        // Event to notify components when state changes (optional)
        public event Action OnChange;

        // Method to set the user name
        public void SetUserName(string userName)
        {
            UserName = userName;
            NotifyStateChanged();
        }

        // Method to set the login status
        public void SetLoginStatus(bool isLoggedIn)
        {
            IsLoggedIn = isLoggedIn;
            NotifyStateChanged();
        }

        // Internal method to trigger state change notification (optional)
        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}
