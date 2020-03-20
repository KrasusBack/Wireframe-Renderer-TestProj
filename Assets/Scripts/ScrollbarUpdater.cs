using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarUpdater : MonoBehaviour
{
    private ScrollRect _scrollrect;

    void Start()
    {
        _scrollrect = GetComponent<ScrollRect>();
        Application.Instance.CommandsHistoryChanged += ScrollBarPositionUpdate;
    }

    private void ScrollBarPositionUpdate()
    {
        _scrollrect.normalizedPosition = new Vector2(0, 0);
    }

}
