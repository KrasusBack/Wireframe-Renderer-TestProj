using UnityEngine;

[CreateAssetMenu(fileName = "ApplicationSettings", menuName = "ScriptableObjects/ApplicationSettings", order = 1)]
public class ApplicationSettings : ScriptableObject
{
    [Header("General")]
    [SerializeField]
    private KeyCode redoKey = KeyCode.X;
    [SerializeField]
    private KeyCode undoKey = KeyCode.Z;
    [SerializeField, Range(1, 1000)]
    private int historyCapacity = 100;

    [Header("Changind polygons amount")]
    [SerializeField, Range(1, 100)]
    private int triangleNumberChange = 1;
    [SerializeField]
    private KeyCode addTrianglesKey = KeyCode.C;
    [SerializeField]
    private KeyCode removeTrianglesKey = KeyCode.D;


    public KeyCode RedoKey => redoKey;
    public KeyCode UndoKey => undoKey;
    public int HistoryCapacity => historyCapacity;

    public int TriangleNumberChange => triangleNumberChange;
    public KeyCode AddTrianglesKey => addTrianglesKey;
    public KeyCode RemoveTrianglesKey => removeTrianglesKey;
}
