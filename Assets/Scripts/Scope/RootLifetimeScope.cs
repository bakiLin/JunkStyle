using MessagePipe;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class RootLifetimeScope : LifetimeScope
{
    [SerializeField] private RemoteSettingsSO _remoteSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterMessagePipe(builder);

        builder.RegisterInstance(_remoteSettings);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        builder.RegisterMessageBroker<EventMessage>(
            builder.RegisterMessagePipe()
        );
    }
}