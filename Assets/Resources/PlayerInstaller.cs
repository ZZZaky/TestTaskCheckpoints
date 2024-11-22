using UnityEngine;
using Zenject;

/// <summary>
/// Player installer for Zenject
/// </summary>
public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerHandler player;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHandler>().FromInstance(player).AsSingle().NonLazy();
    }
}
