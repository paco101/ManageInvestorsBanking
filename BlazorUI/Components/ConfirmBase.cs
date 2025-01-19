using Microsoft.AspNetCore.Components;

namespace BlazorUI.Components
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        public async Task Show()
        {
            ShowConfirmation = true;
            await InvokeAsync(StateHasChanged);
        }

        [Parameter] public string Title { get; set; } = "Confirm";
        [Parameter] public string Message { get; set; } = "Are you sure you want to delete?";

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
        public async Task OnConfirmed(bool confirmed)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(confirmed);
        }
    }
}
