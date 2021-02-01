using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCommand : Command
{
    private Vector3 position = Vector3.zero;
    private GameObject prop;

    public CreateCommand(GameObject p)
    {
        prop = p;
    }

    public override void Undo()
    {
        if (prop == null)
        {
            Debug.LogWarning("No prop associated with command, prop might have been removed before command");
        }
        else
        {
            if (prop.activeSelf)
            {
                Garbage.instance.Recycle(prop);
            }
            else
            {
                Garbage.instance.Restore(prop);
            }
        }
    }
}
