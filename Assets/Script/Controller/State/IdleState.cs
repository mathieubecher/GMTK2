using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AbstractState
{
    
    public IdleState(Controller controller) : base(controller)
    {
        
    }

    public override void Interact()
    {
        Reset(StateType.Interact);
    }
}
