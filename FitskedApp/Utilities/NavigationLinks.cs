using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace FitskedApp.Utilities
{
    public class NavigationLinks
    {
        private readonly NavigationManager navigationManager;

        public NavigationLinks(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }   

        public void GoToAddPlanPage()
        {
            navigationManager.NavigateTo("/add-plan");
        }

        public void GoToViewPlansPage()
        {
            navigationManager.NavigateTo("/user-plans");
        }

        public void GoToRegistrationPage()
        {
            navigationManager.NavigateTo("Account/Register");
        }

        public void GoToLoginPage()
        {
            navigationManager.NavigateTo("Account/Login");
        }
    }
}
