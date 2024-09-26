using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigSaveService : IKeyConfigSave
{
    IKeyConfigRepository keyConfigRepository;

    public KeyConfigSaveService(IKeyConfigRepository keyConfigRepository)
    {
        this.keyConfigRepository = keyConfigRepository;
    }

    public void KeyConfigSave(SaveCommand saveCommand)
    {
        if (saveCommand.SavePath != null)
        {
            keyConfigRepository.Save(saveCommand.SavePath.Value);
        }
        if (saveCommand.AutoSavePath != null)
        {
            keyConfigRepository.Save(saveCommand.AutoSavePath.Vaule);
        }
    }


}
