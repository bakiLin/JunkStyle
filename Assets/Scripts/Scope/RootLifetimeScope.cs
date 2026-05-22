using MessagePipe;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class RootLifetimeScope : LifetimeScope
{
    [SerializeField] private RemoteControllerSettingsSO _remoteControllerSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterMessagePipe(builder);

        builder.RegisterInstance(_remoteControllerSettings);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        builder.RegisterMessageBroker<EventMessage>(
            builder.RegisterMessagePipe()
        );
    }
}