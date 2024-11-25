using UnityEngine;
using Zenject;

/// <summary>
/// Player installer for Zenject
/// </summary>
public class PlayerManagerInstaller : MonoInstaller
{
    [SerializeField] private PlayerManager playerManager;

    public override void InstallBindings()
    {
        Container.Bind<PlayerManager>().FromInstance(playerManager).AsSingle().NonLazy();
    }
}