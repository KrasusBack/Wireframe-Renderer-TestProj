using UnityEngine;

public sealed class AddTrianglesCommand : Command
{
    private readonly GameObject _impactedObject;
    /// <summary>Сreation frame.</summary>
    private readonly int _creationTime = 0;
    private readonly int _trianglesToAdd = 0;

    public AddTrianglesCommand(GameObject impactedObject)
    {
        _impactedObject = impactedObject;
        _creationTime = Time.frameCount;
        _trianglesToAdd = Application.Settings.TriangleNumberChange;
    }

    public override bool Execute()
    {
        return _impactedObject.GetComponent<MeshWireframe>().IncreaseNumberOfTriangles(_trianglesToAdd);
    }

    public override bool Undo()
    {
        return _impactedObject.GetComponent<MeshWireframe>().DecreaseNumberOfTriangles(_trianglesToAdd);
    }

    public override string ToString()
    {
        return "Add Triangles:" + _trianglesToAdd + " (" + System.Convert.ToString(_creationTime, 16) + ")";
    }
}
