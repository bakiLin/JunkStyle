using MessagePipe;
using System;
using VContainer.Unity;

public class MaterialSetter : IDisposable, IStartable
{
    private MaterialSettingsSO _materialSettings;
    private IDisposable _disposable;

    private MaterialSetter(MaterialSettingsSO materialSettings, 
        ISubscriber<ChangeMaterialMessage> changeMaterialMessage)
    {
        _materialSettings = materialSettings;
        _disposable = changeMaterialMessage.Subscribe(HandleChangeMaterialMessage);
    }

    private void HandleChangeMaterialMessage(ChangeMaterialMessage message)
    {
        var materials = message.Renderer.materials;

        switch (message.Type)
        {
            case MaterialType.Remote:
                materials[2] = message.State 
                    ? _materialSettings.RemoteOn : _materialSettings.RemoteOff;
                break;
            case MaterialType.Wire:
                materials[0] = message.State
                    ? _materialSettings.WireOn : _materialSettings.WireOff;
                break;
            case MaterialType.Screen:
                materials[1] = message.State
                    ? _materialSettings.ScreenOn : _materialSettings.ScreenOff;
                break;
        }

        message.Renderer.materials = materials;
    }

    public void Dispose()
    {
        _disposable?.Dispose();
    }

    public void Start() { }
}
