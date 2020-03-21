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
    [SerializeField, Range(1, 1000)]
    private int historyCapacity = 100;

    [Header("Changind polygons amount")]
    [SerializeField, Range(1,100)]
    private int triangleNumberChange = 1;
    [SerializeField]
    private KeyCode addTrianglesKey = KeyCode.C;
    
    [Header("DemoMode")]
    [SerializeField]
    private KeyCode demoModeKey = KeyCode.Space;
    [SerializeField, Range(0.001f, 60)]
    private float demoModeDrawCooldown = 0.05f;

    public int TriangleNumberChange => triangleNumberChange;
    public KeyCode AddTrianglesKey => addTrianglesKey;
    public KeyCode RedoKey => redoKey;
    public KeyCode UndoKey => undoKey;
    public KeyCode DemoKey => demoModeKey;
    public float DemoModeDrawCooldown => demoModeDrawCooldown;
    public int HistoryCapacity => historyCapacity;

}
