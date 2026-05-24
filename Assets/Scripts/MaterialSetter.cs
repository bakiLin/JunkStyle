using MessagePipe;
using System;
using UnityEngine;
using VContainer.Unity;

public class MaterialSetter : IDisposable, IStartable
{
    private MaterialSettingsSO _materialSettings;
    private IDisposable _disposable;

    private MaterialSetter(MaterialSettingsSO materialSettings, 
        ISubscriber<RemoteMaterialMessage> remoteMaterial, ISubscriber<WireMaterialMessage> wireMaterial,
        ISubscriber<ScreenMaterialMessage> screenMaterial)
    {
        _materialSettings = materialSettings;

        _disposable = DisposableBag.Create(
            remoteMaterial.Subscribe(x => UpdateRemoteMaterial(x.Renderer, x.State)),
            wireMaterial.Subscribe(x => UpdateWireMaterial(x.Renderer, x.State)),
            screenMaterial.Subscribe(x => UpdateScreenMaterial(x.Renderer, x.State))
        );
    }

    private void UpdateWireMaterial(MeshRenderer renderer, bool state)
    {
        var materials = renderer.materials;
        materials[0] = state ? _materialSettings.WireOn : _materialSettings.WireOff;
        renderer.materials = materials;
    }

    private void UpdateRemoteMaterial(MeshRenderer renderer, bool state)
    {
        var materials = renderer.materials;
        materials[2] = state ? _materialSettings.RemoteOn : _materialSettings.RemoteOff;
        renderer.materials = materials;
    }

    private void UpdateScreenMaterial(MeshRenderer renderer, bool state)
    {
        var materials = renderer.materials;
        materials[1] = state ? _materialSettings.ScreenOn : _materialSettings.ScreenOff;
        renderer.materials = materials;
    }

    public void Dispose()
    {
        _disposable?.Dispose();
    }

    public void Start() { }
}
