using UnityEngine;
using Zenject;

public class GameFieldInstaller : MonoInstaller
{
    [SerializeField] private GameField GameField;

    public override void InstallBindings()
    {
        Container.Bind<GameField>().FromInstance(GameField).AsSingle();
    }
}