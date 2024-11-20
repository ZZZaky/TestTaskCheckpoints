using UnityEngine;
using Zenject;

/// <summary>
/// Checkpoint Manager installer for Zenject
/// </summary>
public class SelectedCheckpointManagerInstaller : MonoInstaller
{
    [SerializeField] private SelectedCheckpointManager selectedCheckpointManager;

    public override void InstallBindings()
    {
        Container.Bind<SelectedCheckpointManager>().FromInstance(selectedCheckpointManager).AsSingle().NonLazy();
    }
}