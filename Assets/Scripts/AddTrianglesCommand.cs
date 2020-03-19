using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTrianglesCommand : Command
{
    private GameObject _impactedObject;

    public AddTrianglesCommand()
    {
        _impactedObject = Application.ChosenObject;
    }

    public override void Execute ()
    {
        _impactedObject.GetComponent<MeshWireframe>().AddTriangleToDraw();
    }

    public override void Undo()
    {
        _impactedObject.GetComponent<MeshWireframe>().SubtractTriangleToDraw();
    }
}
