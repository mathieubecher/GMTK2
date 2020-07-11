using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public Collider attackLeft;
    public Collider attackRight;
    public Collider attackTop;
    public Collider attackBottom;

    public void Active(Controller.Direction direction)
    {
        ResetAll();
        switch (direction)
        {
            case Controller.Direction.Top:
                attackTop.gameObject.SetActive(true);
                break;
            case Controller.Direction.Left:
                attackLeft.gameObject.SetActive(true);
                break;
            case Controller.Direction.Bottom:
                attackBottom.gameObject.SetActive(true);
                break;
            case Controller.Direction.Right:
                attackRight.gameObject.SetActive(true);
                break;
        }
    }

    public void ResetAll()
    {
        attackTop.gameObject.SetActive(false);
        attackLeft.gameObject.SetActive(false);
        attackBottom.gameObject.SetActive(false);
        attackRight.gameObject.SetActive(false);
    }
    
}
