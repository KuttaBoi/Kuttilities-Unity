using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCommand : Command {

    GameObject prop;
    bool Restore = true;
    public DestroyCommand(GameObject g)
    {
        prop = g;
    }

    public override void Undo()
    {
        if (Restore)
        {
            Garbage.instance.Restore(prop);
            Restore = false;
        }
        else
        {
            Garbage.instance.Recycle(prop);
            Restore = true;
        }
    }

}
