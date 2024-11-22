using UnityEngine;
using Zenject;

/// <summary>
/// Selected object manager installer for Zenject
/// </summary>
public class SelectedObjectManagerInstaller : MonoInstaller
{
    [SerializeField] private SelectedObjectManager selectedObjectManager;

    public override void InstallBindings()
    {
        Container.Bind<SelectedObjectManager>().FromInstance(selectedObjectManager).AsSingle().NonLazy();
    }
}
