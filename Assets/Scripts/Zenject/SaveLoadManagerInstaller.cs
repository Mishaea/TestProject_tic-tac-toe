using Zenject;

public class SaveLoadManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SaveLoadManager>().FromNewComponentOnNewGameObject().AsSingle();
    }
}