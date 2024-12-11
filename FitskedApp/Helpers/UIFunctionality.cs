using Microsoft.JSInterop;

namespace FitskedApp.Helpers
{
    public class UIFunctionality : IUIFunctionality
    {
        private readonly IJSRuntime jSRuntime;
        public UIFunctionality(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }
        public async Task TriggerBlinkingEffect(string elementId)
        {
            await jSRuntime.InvokeVoidAsync("blinkOnNullInput",elementId);
        }
    }
}
