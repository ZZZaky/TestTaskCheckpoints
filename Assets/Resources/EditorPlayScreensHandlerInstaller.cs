using UnityEngine;
using Zenject;

public class EditorPlayScreensHandlerInstaller : MonoInstaller
{
    [SerializeField] private EditorPlayScreensHandler editorPlayScreensHandler;

    public override void InstallBindings()
    {
        Container.Bind<EditorPlayScreensHandler>().FromInstance(editorPlayScreensHandler).AsSingle().NonLazy();
    }
}
