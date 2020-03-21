using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class AddTrianglesCommand : Command
{
    private readonly GameObject _impactedObject;
    private readonly int _creationTime = 0;

    public AddTrianglesCommand(GameObject impactedObject)
    {
        _impactedObject = impactedObject;
        _creationTime = Time.frameCount;
    }

    public override bool Execute ()
    {
        return _impactedObject.GetComponent<MeshWireframe>().AddTriangleToDraw();
    }

    public override bool Undo()
    {
        return _impactedObject.GetComponent<MeshWireframe>().SubtractTriangleToDraw();
    }

    public override string ToString()
    {
        return "Add Triangles (" + Convert.ToString(_creationTime, 16) + ")";
    }
}
