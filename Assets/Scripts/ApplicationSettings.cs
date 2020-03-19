using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ApplicationSettings", menuName = "ScriptableObjects/ApplicationSettings", order = 1)]

public class ApplicationSettings : ScriptableObject
{
    [Header ("General Settings")]
    [SerializeField]
    private KeyCode redoKey = KeyCode.X;
    [SerializeField]
    private KeyCode undoKey = KeyCode.Z;

    [Header("Adding polygons")]
    [SerializeField]
    private int triangleNumberChange = 3;
    [SerializeField]
    private KeyCode addTrianglesKey = KeyCode.C;
    
    [Header("DemoMode")]
    [SerializeField]
    private KeyCode demoKey = KeyCode.Space;
    [SerializeField]
    private float demoModeDrawCooldown = 0.05f;

    public int TriangleNumberChange => triangleNumberChange;
    public KeyCode AddTrianglesKey => addTrianglesKey;
    public KeyCode RedoKey => redoKey;
    public KeyCode UndoKey => undoKey;
    public KeyCode DemoKey => demoKey;
    public float DemoModeDrawCooldown => demoModeDrawCooldown;

}
