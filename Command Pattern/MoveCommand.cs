using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{

    private Vector3 startPosition = Vector3.zero;
    private Transform prop;

    public MoveCommand(Vector3 m, Transform p)
    {
        startPosition = m;
        prop = p;
    }

    public override void Undo()
    {
        Vector3 auxPos = prop.position;
        prop.position = startPosition;
        startPosition = auxPos;
    }

}
