using UnityEngine;
using UnityEngine.UI;

public sealed class ScrollbarUpdater : MonoBehaviour
{
    private ScrollRect _scrollrect;

    void Start()
    {
        _scrollrect = GetComponent<ScrollRect>();
        Application.Instance.CommandHistoryChanged += ScrollBarPositionUpdate;
    }

    private void ScrollBarPositionUpdate()
    {
        _scrollrect.verticalNormalizedPosition = 0;
    }

}
