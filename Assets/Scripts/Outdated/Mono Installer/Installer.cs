using Zenject;

public class Installer : MonoInstaller
{
    public TapManager tapManager;

    public PauseManager pauseManager;

    public CursorManager cursorManager;

    public LevelManager levelManager;

    public MaterialManager materialManager;

    public SpawnManager spawnManager;

    public override void InstallBindings()
    {
        Container.Bind<TapManager>().FromInstance(tapManager).AsSingle().NonLazy();

        Container.Bind<PauseManager>().FromInstance(pauseManager).AsSingle().NonLazy();

        Container.Bind<CursorManager>().FromInstance(cursorManager).AsSingle().NonLazy();

        Container.Bind<LevelManager>().FromInstance(levelManager).AsSingle().NonLazy();

        Container.Bind<MaterialManager>().FromInstance(materialManager).AsSingle().NonLazy();

        Container.Bind<SpawnManager>().FromInstance(spawnManager).AsSingle().NonLazy();
    }
}