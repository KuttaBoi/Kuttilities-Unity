using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotAngleCommand : Command {

    private Fixture unit;
    private float angle;

    public SpotAngleCommand(Fixture u, float a)
    {
        unit = u;
        angle = a;
    }

    public override void Undo()
    {
        //float aux = unit.SpotAngle;
        //unit.SetSpotAngle(angle);
        //angle = aux;
        EventManager.TriggerEvent("UpdateValues");
    }
}
