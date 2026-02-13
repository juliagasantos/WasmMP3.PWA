using Microsoft.JSInterop;

namespace WasmMP3.Client.Services;

public class DeviceService
{
    private readonly IJSRuntime _js;
    public DeviceService(IJSRuntime js) => _js = js;

    public ValueTask<bool> IsOnlineAsync()
        => _js.InvokeAsync<bool>("device.isOnline");

    public ValueTask VibrateAsync(int ms)
        => _js.InvokeVoidAsync("device.vibrate", ms);

    public ValueTask RegisterOnlineListenerAsync(IJSObjectReference dotNetObjRef)
        => _js.InvokeVoidAsync("device.onOnline", dotNetObjRef);

    //metodos do CopyText (clipboard)
    public ValueTask<bool> CopyTextAsync(string txt)
        => _js.InvokeAsync<bool>("clipboard.copyText", txt);
     public ValueTask<string> ReadTextAsync()
        => _js.InvokeAsync<string>("clipboard.readText");

    public ValueTask<int> getLevelAsync()
        => _js.InvokeAsync<int>("battery.getLevel");
}