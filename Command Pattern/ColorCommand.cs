using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCommand : Command {

    private Fixture unit;
    private Color color;

    public ColorCommand(Fixture u, Color c)
    {
        unit = u;
        color = c;
    }
    public override void Undo()
    {
    }
}
