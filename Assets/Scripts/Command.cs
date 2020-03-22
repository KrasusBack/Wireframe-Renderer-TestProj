using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    /// <summary>Execute command. Returns operation success status.</summary>
    public abstract bool Execute();
    /// <summary>Undo command. Returns operation success status.</summary>
    public abstract bool Undo();

    //Should preferably return the name of the command in the application
    public abstract override string ToString();
}
