using UnityEngine;
using Zenject;

public class SavableMapDataInstaller : MonoInstaller
{
    [SerializeField] private SavableMapData savableMapData;

    public override void InstallBindings()
    {
        Container.Bind<SavableMapData>().FromInstance(savableMapData).AsSingle().NonLazy();
    }
}
