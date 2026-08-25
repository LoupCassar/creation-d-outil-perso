using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dapper dino tuto
[System.Serializable]
public class InputManager 
{
    public static InputManager instance;

    [SerializeField] public Dictionary<KeybindingAction, KeyCode> Control = new Dictionary<KeybindingAction, KeyCode>();

    
    public Dictionary<KeybindingAction, KeyCode> ControlAzertyDictionary()
    {
        Dictionary<KeybindingAction, KeyCode> controlAzerty = new Dictionary<KeybindingAction, KeyCode>()
        {
            { KeybindingAction.Pause, KeyCode.Escape},
            { KeybindingAction.Forward, KeyCode.W},
            { KeybindingAction.Backward, KeyCode.S},
            { KeybindingAction.Right, KeyCode.D},
            { KeybindingAction.Left, KeyCode.A},
            { KeybindingAction.Jump, KeyCode.Space},
            { KeybindingAction.Run, KeyCode.LeftShift},
            { KeybindingAction.Walk, KeyCode.LeftAlt},
            { KeybindingAction.FirstInteraction, KeyCode.Mouse0},
            { KeybindingAction.SecondaryInteraction, KeyCode.F},
            { KeybindingAction.ThirdInteraction, KeyCode.Mouse2},
            { KeybindingAction.FourthInteraction, KeyCode.Mouse3},
            { KeybindingAction.QuickSave, KeyCode.F6},
            { KeybindingAction.QuickLoad, KeyCode.F5},
            { KeybindingAction.Inventaire, KeyCode.Tab},
            { KeybindingAction.Map, KeyCode.M  }
        };
        return controlAzerty;
    }
    public Dictionary<KeybindingAction, KeyCode> ControlQwertyDictionary()
    {
        Dictionary<KeybindingAction, KeyCode> controlQwerty = new Dictionary<KeybindingAction, KeyCode>()
        {
            { KeybindingAction.Pause, KeyCode.Escape},
            { KeybindingAction.Forward, KeyCode.W},
            { KeybindingAction.Backward, KeyCode.S},
            { KeybindingAction.Right, KeyCode.D},
            { KeybindingAction.Left, KeyCode.A},
            { KeybindingAction.Jump, KeyCode.Space},
            { KeybindingAction.Run, KeyCode.LeftShift},
            { KeybindingAction.Walk, KeyCode.LeftAlt},
            { KeybindingAction.FirstInteraction, KeyCode.Mouse0},
            { KeybindingAction.SecondaryInteraction, KeyCode.F},
            { KeybindingAction.ThirdInteraction, KeyCode.Mouse2},
            { KeybindingAction.FourthInteraction, KeyCode.Mouse3},
            { KeybindingAction.QuickSave, KeyCode.F6},
            { KeybindingAction.QuickLoad, KeyCode.F5},
            { KeybindingAction.Inventaire, KeyCode.Tab},
            { KeybindingAction.Map, KeyCode.M  }

        };
        return controlQwerty;
    }

}
