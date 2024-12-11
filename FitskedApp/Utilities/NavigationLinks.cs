using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;


namespace FitskedApp.Utilities
{
    public class NavigationLinks
    {
        private readonly NavigationManager navigationManager;
        private readonly IJSRuntime jsRuntime ;

        public NavigationLinks(NavigationManager navigationManager, IJSRuntime jsRuntime)
        {
            this.navigationManager = navigationManager;
            this.jsRuntime = jsRuntime;
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

        public async Task GoToNavigationLink(string? url)
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("open", url, "_blank");
            }
            catch(NavigationException e) 
            {
                    Console.WriteLine(e.Message);
            }
        }
    }
}
