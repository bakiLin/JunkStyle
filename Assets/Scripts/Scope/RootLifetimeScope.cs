using MessagePipe;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class RootLifetimeScope : LifetimeScope
{
    [SerializeField] private RemoteSettingsSO _remoteSettings;
    [SerializeField] private MaterialSettingsSO _materialSettings;
    [SerializeField] private UISettingsSO _uiSettings;
    [SerializeField] private SoundManager _soundManager;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterMessagePipe(builder);

        builder.Register<MaterialSetter>(Lifetime.Singleton);

        builder.RegisterEntryPoint<MaterialSetter>(Lifetime.Singleton);

        builder.RegisterInstance(_remoteSettings);
        builder.RegisterInstance(_materialSettings);
        builder.RegisterInstance(_uiSettings);
        builder.RegisterInstance<ISoundManager>(_soundManager);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        builder.RegisterMessageBroker<EventMessage>(
            builder.RegisterMessagePipe()
        );
    }
}