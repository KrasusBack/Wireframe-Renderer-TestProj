using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class AddTrianglesCommand : Command
{
    private readonly GameObject _impactedObject;
    private readonly int _creationTime = 0;
    private readonly int _trianglesToAdd = 0;

    public AddTrianglesCommand(GameObject impactedObject)
    {
        _impactedObject = impactedObject;
        _creationTime = Time.frameCount;
        _trianglesToAdd = Application.Settings.TriangleNumberChange;
    }

    public override bool Execute ()
    {
        return _impactedObject.GetComponent<MeshWireframe>().AddTriangleToDraw(_trianglesToAdd);
    }

    public override bool Undo()
    {
        return _impactedObject.GetComponent<MeshWireframe>().SubtractTriangleToDraw(_trianglesToAdd);
    }

    public override string ToString()
    {
        return "Add Triangles:"+_trianglesToAdd+" (" + Convert.ToString(_creationTime, 16) + ")";
    }
}
