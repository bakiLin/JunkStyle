using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public AudioManager AudioManager;

    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromInstance(AudioManager).AsSingle().NonLazy();
    }
}