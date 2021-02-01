using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerCommand : Command {

    private float dimm_amount;
    private float prev_amount;
    private Fixture fixture;

    public DimmerCommand(float dimmPercent, Fixture u)
    {
        //<summary> Generate a DimmerCommand with the dimmer percent and the fixture </summary>
        dimm_amount = Mathf.Clamp(dimmPercent,0,100f);
        fixture = u;
    }

    public override void Undo()
    {
        fixture.GetComponent<Dimmer>().dimmer(prev_amount);
    }
    public override void Do()
    {
        fixture.GetComponent<Dimmer>().dimmer(dimm_amount);
        UndoHistory.instance.commandBuffer.Add(this);
    }
}
