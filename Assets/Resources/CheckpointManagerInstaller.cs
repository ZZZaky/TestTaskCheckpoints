using UnityEngine;
using Zenject;

public class CheckpointManagerInstaller : MonoInstaller
{
    [SerializeField] private CheckpointManager checkpointManager;

    public override void InstallBindings()
    {
        Container.Bind<CheckpointManager>().FromInstance(checkpointManager).AsSingle().NonLazy();
    }
}