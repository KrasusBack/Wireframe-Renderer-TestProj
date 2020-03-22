using UnityEngine;

public sealed class MeshWireframe : MonoBehaviour
{
    private Mesh _mesh;
    private int[] _originalTriangles;
    private int _currentTrianglesLeft;
    private float _demoModeLastIterationTime = 0;

    void Start()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _originalTriangles = _mesh.triangles;

        SetUpStartState();
    }

    /// <summary>Returns error message or string.Empty if there is none.</summary>
    public string IncreaseNumberOfTriangles(int trianglesToAdd)
    {
        return UpdateMesh(trianglesToAdd);
    }

    /// <summary>Returns error message or string.Empty if there is none.</summary>
    public string DecreaseNumberOfTriangles(int trianglesToAdd)
    {
        return UpdateMesh(-trianglesToAdd);
    }

    private void SetUpStartState()
    {
        _currentTrianglesLeft = 3;
        _mesh.triangles = new int[] { _mesh.triangles[0], _mesh.triangles[1], _mesh.triangles[2] };
    }

    /// <summary>Returns error message or string.Empty if there is none.</summary>
    private string UpdateMesh(int triangleNumberChange)
    {
        var newTrianglesAmount = _currentTrianglesLeft + triangleNumberChange * 3;
        if (triangleNumberChange > 0 && newTrianglesAmount > _originalTriangles.Length)
        {
            if (triangleNumberChange == 1)
                return Time.frameCount + "Cannot add more triangles - all of them in place already";
            return Time.frameCount + " Not enough space left to add " +  triangleNumberChange + " triangles";
        }
        if (triangleNumberChange < 0 && newTrianglesAmount < 3)
        {
            return Time.frameCount + "Not enough triangles left to subtract. At least 1 should stay";
        }

        _currentTrianglesLeft += triangleNumberChange * 3;
        var subTriangles = new int[_currentTrianglesLeft];
        System.Array.Copy(_originalTriangles, 0, subTriangles, 0, _currentTrianglesLeft);

        _mesh.triangles = subTriangles;
        return string.Empty;
    } 
}
