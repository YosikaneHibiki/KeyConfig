using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class DISetting : LifetimeScope
{
    [SerializeField]
    private KeyConfigPresenter keyConfigPresenter;
    [SerializeField]
    private InputActionAsset actions;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(actions);
        builder.RegisterComponent(keyConfigPresenter)
            .As<IOutPutKeyConfig>();
        builder.Register<DatabaseAccess>(Lifetime.Singleton)
            .As<IKeyConfigRepository>();

        builder.Register<KeyConfigConflictService>(Lifetime.Singleton);
        builder.Register<KeyConfigCancelService>(Lifetime.Singleton);
        builder.Register<KeyConfigSaveService>(Lifetime.Singleton);
        builder.Register<KeyConfigSetupService>(Lifetime.Singleton);
        builder.Register<KeyConfigDefaultService>(Lifetime.Singleton);

        builder.Register<KeyConfigRebindService>(Lifetime.Singleton)
            .As<IKeyConfigRebind>();
        builder.Register<KeyConfigCancelService>(Lifetime.Singleton)
            .As<IKeyConfigCancel>();
        builder.Register<KeyConfigConflictService>(Lifetime.Singleton)
            .As<IKeyConfigConflict>();
        builder.Register<KeyConfigSaveService>(Lifetime.Singleton)
            .As<IKeyConfigSave>();
        builder.Register<KeyConfigDefaultService>(Lifetime.Singleton)
            .As<IKeyConfigDefault>();
        builder.Register<KeyConfigSetupService>(Lifetime.Singleton)
            .As<IKeyConfigSetup>();
    }
}
