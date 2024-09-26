using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class DatabaseAccess : IKeyConfigRepository
{
    private InputActionAsset actions;
    private List<InputBinding> bindings = new();
    private string actionMapName = "DemoActionMap";

    [Inject]
    public DatabaseAccess(InputActionAsset actions)
    {
        this.actions = actions;
    }

    public void Remove(ActionName actionName, BindIndex bindIndex)
    {
        var targetBind = Find(actionName, bindIndex);
        if (targetBind == null) { return; }
        bindings.Remove(targetBind);
    }

    public void ChangeBind(InputBinding inputBinding)
    {
        var action = actions.FindAction(inputBinding.action);
        var bindingIndex = action.bindings.IndexOf(x => x.id.ToString() == inputBinding.id.ToString());
        action.ApplyBindingOverride(bindingIndex, "");
    }

    public InputBinding Find(ActionName actionName, BindIndex bindIndex)
    {
        var targetActions = actions.FindActionMap(actionMapName).actions;
        var targetAction = targetActions
            .Where(action => action.name == actionName.Vaule)
            .FirstOrDefault();

        var targetBind = bindings
            .Where(bind => bind.effectivePath == targetAction.bindings[bindIndex.Vaule].effectivePath)
            .FirstOrDefault();

        if (targetBind.id == targetAction.bindings[bindIndex.Vaule].id)
        {
            var nextBind = bindings
                .Where(bind => bind.id != targetBind.id)
                .Where(bindPath => bindPath.effectivePath == targetBind.effectivePath)
                .FirstOrDefault();
            if (nextBind.effectivePath != null)
            {
                return nextBind;
            }

        }
        return targetBind;

    }

    public void Load(string savePath)
    {
        var path = Path.Combine(Application.persistentDataPath, savePath);
        if (!File.Exists(path)) return;
        var json = File.ReadAllText(path);
        actions.LoadBindingOverridesFromJson(json);
    }

    public void Save(string savePath)
    {
        var json = actions.SaveBindingOverridesAsJson();
        var path = Path.Combine(Application.persistentDataPath, savePath);
        File.WriteAllText(path, json);
    }

    public void Update()
    {
        bindings.Clear();
        var targetActions = actions.FindActionMap(actionMapName).bindings;
        foreach (var action in targetActions)
        {
            bindings.Add(action);
        }
    }

    public void Delate()
    {
        bindings.Clear();
        actions.RemoveAllBindingOverrides();
    }

}
