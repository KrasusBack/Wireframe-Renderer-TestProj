using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    private protected Object _influencedObj;

    public abstract void Execute();
}
