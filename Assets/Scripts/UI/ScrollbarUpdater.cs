using UnityEngine;
using UnityEngine.UI;

public sealed class ScrollbarUpdater : MonoBehaviour
{
    private ScrollRect _scrollrect;

    void Start()
    {
        _scrollrect = GetComponent<ScrollRect>();
        ApplicationCore.Instance.CommandHistoryChanged += ScrollBarPositionUpdate;
    }

    private void ScrollBarPositionUpdate()
    {
        Canvas.ForceUpdateCanvases();
        _scrollrect.verticalNormalizedPosition = 0;
    }

}
