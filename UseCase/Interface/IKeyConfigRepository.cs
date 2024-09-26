using UnityEngine.InputSystem;

public interface IKeyConfigRepository 
{
    InputBinding Find(ActionName actionName,BindIndex bindIndex);
    void Remove(ActionName actionName, BindIndex bindIndex);
    void ChangeBind(InputBinding binding);
    void Save(string savePath);
    void Load(string savePath);
    void Delate();
    void Update();

}
