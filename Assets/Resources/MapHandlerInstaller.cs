using UnityEngine;
using Zenject;

/// <summary>
/// Player installer for Zenject
/// </summary>
public class MapHandlerInstaller : MonoInstaller
{
    [SerializeField] private MapHandler mapHandler;

    public override void InstallBindings()
    {
        Container.Bind<MapHandler>().FromInstance(mapHandler).AsSingle().NonLazy();
    }
}
