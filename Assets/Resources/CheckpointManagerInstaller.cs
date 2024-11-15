using UnityEngine;
using Zenject;

/// <summary>
/// Checkpoint Manager installer for Zenject
/// </summary>
public class CheckpointManagerInstaller : MonoInstaller
{
    [SerializeField] private CheckpointManager checkpointManager;

    public override void InstallBindings()
    {
        Container.Bind<CheckpointManager>().FromInstance(checkpointManager).AsSingle().NonLazy();
    }
}