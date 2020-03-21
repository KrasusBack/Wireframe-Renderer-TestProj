using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MeshWireframe : MonoBehaviour
{
    private int TriangleNumberChange => Application.Settings.TriangleNumberChange;

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

    private void SetUpStartState()
    {
        _currentTrianglesLeft = 3;
        _mesh.triangles = new int[] { _mesh.triangles[0], _mesh.triangles[1], _mesh.triangles[2] };
    }

    private bool UpdateMesh(int triangleNumberChange)
    {
        if (triangleNumberChange == 0) return false;
        if (triangleNumberChange > 0 && _currentTrianglesLeft + triangleNumberChange > _originalTriangles.Length)
        {
            print("too much triangles to add");
            return false;
        }
        if (triangleNumberChange < 0 && _currentTrianglesLeft + triangleNumberChange < 3)
        {
            print("not enough triangles left to subtract");
            return false;
        }

        _currentTrianglesLeft += triangleNumberChange;
        int[] subTriangles = new int[_currentTrianglesLeft];
        System.Array.Copy(_originalTriangles, 0, subTriangles, 0, _currentTrianglesLeft);
        
        _mesh.triangles = subTriangles;
        return true;
    }

    public bool AddTriangleToDraw()
    {
        return UpdateMesh(TriangleNumberChange);
    }

    public bool SubtractTriangleToDraw()
    {
        return UpdateMesh(-TriangleNumberChange);
    }
}
