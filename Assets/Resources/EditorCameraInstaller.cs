using UnityEngine;
using Zenject;

/// <summary>
/// Editor camera installer for Zenject
/// </summary>
public class EditorCameraInstaller : MonoInstaller
{
    [SerializeField] private EditorHandler editorCamera;

    public override void InstallBindings()
    {
        Container.Bind<EditorHandler>().FromInstance(editorCamera).AsSingle().NonLazy();
    }
}
