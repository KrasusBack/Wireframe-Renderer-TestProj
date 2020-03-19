using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshWireframe : MonoBehaviour
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
        //if (startFromWhole)
        //    _currentTrianglesLeft = _mesh.triangles.Length;
        //else
        //{
            _currentTrianglesLeft = 3;
            _mesh.triangles = new int[] { _mesh.triangles[0], _mesh.triangles[1], _mesh.triangles[2] };
        //}
    }

    private void UpdateMesh(int triangleNumberChange)
    {
        if (triangleNumberChange == 0) return;
        if (triangleNumberChange > 0 && _currentTrianglesLeft + triangleNumberChange > _originalTriangles.Length)
        {
            print("too much triangles to add");
            return;
        }
        if (triangleNumberChange < 0 && _currentTrianglesLeft + triangleNumberChange < 3)
        {
            print("not enough triangles left to subtract");
            return;
        }

        _currentTrianglesLeft += triangleNumberChange;
        int[] subTriangles = new int[_currentTrianglesLeft];
        for (var i = 0; i < _currentTrianglesLeft; ++i) subTriangles[i] = _originalTriangles[i];

        _mesh.triangles = subTriangles;
    }

    public void AddTriangleToDraw()
    {
        UpdateMesh(TriangleNumberChange);
    }

    public void SubtractTriangleToDraw()
    {
        UpdateMesh(-TriangleNumberChange);
    }
}
