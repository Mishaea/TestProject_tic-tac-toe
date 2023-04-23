using Zenject;

public class GameControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}