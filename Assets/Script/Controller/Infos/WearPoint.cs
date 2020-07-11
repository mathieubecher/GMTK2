using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearPoint : MonoBehaviour
{
    public Transform wearPoint;
    public Transform releaseLeft;
    public Transform releaseRight;
    public Transform releaseTop;
    public Transform releaseBottom;

    public Vector3 GetPoint(Controller.Direction direction)
    {
        switch (direction)
        {
            case Controller.Direction.Top:
                return releaseTop.position;
                break;
            case Controller.Direction.Left:
                return releaseLeft.position;
                break;
            case Controller.Direction.Bottom:
                return releaseBottom.position;
                break;
            case Controller.Direction.Right:
                return releaseRight.position;
                break;
            default :
                return releaseBottom.position;
        }
    }
}
