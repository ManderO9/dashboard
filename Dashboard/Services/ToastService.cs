using Microsoft.JSInterop;

namespace Dashboard;

public class ToastService
{
    private readonly IJSRuntime mJSRuntime;

    public ToastService(IJSRuntime mJSRuntime) => this.mJSRuntime = mJSRuntime;

    public async Task ShowAsync(string message)
    {
        await mJSRuntime.InvokeVoidAsync("window.toast", new { message = message, theme = "carbon", duration = 4000, position = "top-right", entryAnimation = "slideInUp", exitAnimation = "windLeftOut" });
    }


    public async Task<T> ShowToastForTaskAsync<T>(Task<T> task, string initialMessage, string successMessage = "", string failMessage = "")
    {
        var toast = await mJSRuntime.InvokeAsync<IJSObjectReference>("window.toast",
            new
            {
                message = initialMessage,
                theme = "carbon",
                duration = 0,
                position = "top-right",
                entryAnimation = "slideInUp",
                exitAnimation = "windLeftOut",
                showIcon = true,
                iconType = "loader",
            });

        var result = default(T);

        try
        {

            result = await task;

            await toast.InvokeVoidAsync("update",
                new
                {
                    message = string.IsNullOrEmpty(successMessage) ? $"{initialMessage}" : successMessage,
                    iconType = "success",
                    duration = 4000,
                });

            return result;
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);

            await toast.InvokeVoidAsync("update",
                new
                {
                    message = string.IsNullOrEmpty(failMessage) ? $"{initialMessage}" : failMessage,
                    iconType = "error",
                    duration = 4000,
                    theme = "legoBrick",
                });
        }


        return result!;
    }

}
