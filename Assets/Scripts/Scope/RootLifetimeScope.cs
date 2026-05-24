using MessagePipe;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class RootLifetimeScope : LifetimeScope
{
    [SerializeField] private RemoteSettingsSO _remoteSettings;
    [SerializeField] private MaterialSettingsSO _materialSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterMessagePipe(builder);

        builder.Register<MaterialSetter>(Lifetime.Singleton);

        builder.RegisterEntryPoint<MaterialSetter>(Lifetime.Singleton);

        builder.RegisterInstance(_remoteSettings);
        builder.RegisterInstance(_materialSettings);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        builder.RegisterMessageBroker<EventMessage>(
            builder.RegisterMessagePipe()
        );
    }
}