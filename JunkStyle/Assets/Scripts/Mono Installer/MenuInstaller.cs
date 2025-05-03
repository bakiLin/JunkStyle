using Zenject;

public class MenuInstaller : MonoInstaller
{
    public CursorManager cursorManager;

    public override void InstallBindings()
    {
        Container.Bind<CursorManager>().FromInstance(cursorManager).AsSingle().NonLazy();
    }
}