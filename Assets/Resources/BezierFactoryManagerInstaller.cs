using UnityEngine;
using Zenject;

public class BezierFactoryManagerInstaller : MonoInstaller
{
    [SerializeField] private BezierFactory bezierFactory;

    public override void InstallBindings()
    {
        Container.Bind<BezierFactory>().FromInstance(bezierFactory).AsSingle().NonLazy();
    }
}
