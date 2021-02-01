using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : Command {

    private Vector3 startRotation = Vector3.zero;
    private GameObject prop;

    public RotateCommand(Vector3 sRot, GameObject p)
    {
        startRotation = sRot;
        prop = p;
    }

    public override void Undo()
    {
        Vector3 aux = prop.transform.eulerAngles;
        prop.transform.eulerAngles = startRotation;
        startRotation = aux;
    }
}
