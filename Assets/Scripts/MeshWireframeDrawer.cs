using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshWireframeDrawer : MonoBehaviour
{
    [SerializeField]
    private int triangleNumberChange = 3;
    [SerializeField]
    private KeyCode addTrianglesKey = KeyCode.C;
    [SerializeField]
    private KeyCode redoKey = KeyCode.X;
    [SerializeField]
    private KeyCode undoKey = KeyCode.Z;
    [SerializeField]
    private bool startFromWhole = false;

    [Header("DemoMode")]
    [SerializeField]
    private KeyCode demoKey = KeyCode.Space;
    [SerializeField]
    private float _demoModeDrawCooldown = 0.05f;

    private Mesh _mesh;
    private int[] _originalTriangles;
    private int _currentTrianglesLeft;
    private bool _demoMode = false;
    private bool _demoModeAddingMode = true;
    private float _demoModeLastIterationTime = 0;

    void Start()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _originalTriangles = _mesh.triangles;

        SetUpStartState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(demoKey))
        {
            if (_demoMode) _demoMode = false;
            else _demoMode = true;
        }

        if (_demoMode)
        {
            DemoMode();
            return;
        }

        if (Input.GetKeyDown(addTrianglesKey)) AddTriangleToDraw();
        if (Input.GetKeyDown(redoKey)) SubtractTriangleToDraw();
    }

    private void SetUpStartState()
    {
        if (startFromWhole)
            _currentTrianglesLeft = _mesh.triangles.Length;
        else
        {
            _currentTrianglesLeft = 3;
            _mesh.triangles = new int[] { _mesh.triangles[0], _mesh.triangles[1], _mesh.triangles[2] };
        }
    }

    private void DemoMode()
    {
        if (Time.time - _demoModeLastIterationTime < _demoModeDrawCooldown) return;
        _demoModeLastIterationTime = Time.time;

        if (_demoModeAddingMode)
        {
            if (_currentTrianglesLeft + triangleNumberChange <= _originalTriangles.Length)
                AddTriangleToDraw();
            else _demoModeAddingMode = false;
        }
        if (!_demoModeAddingMode)
        {
            if (_currentTrianglesLeft - triangleNumberChange >= 3)
                SubtractTriangleToDraw();
            else _demoModeAddingMode = true;
        } 
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

    private void AddTriangleToDraw()
    {
        UpdateMesh(triangleNumberChange);
    }

    private void SubtractTriangleToDraw()
    {
        UpdateMesh(-triangleNumberChange);
    }
}
