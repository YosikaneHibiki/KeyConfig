using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class KeyConfigDisableService
{
    private IKeyConfigRepository keyConfigRepository;

    [Inject]
    public KeyConfigDisableService(IKeyConfigRepository keyConfigRepository)
    {
        this.keyConfigRepository = keyConfigRepository;
    }

    

}