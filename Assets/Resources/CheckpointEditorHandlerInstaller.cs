using UnityEngine;
using Zenject;

public class CheckpointEditorHandlerInstaller : MonoInstaller
{
    [SerializeField] private CheckpointEditorHandler checkpointEditorHandler;

    public override void InstallBindings()
    {
        Container.Bind<CheckpointEditorHandler>().FromInstance(checkpointEditorHandler).AsSingle().NonLazy();
    }
}