using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AbstractState
{
    
    public IdleState(Controller controller) : base(controller)
    {
        controller.couldCreate = true;
    }

    public override void Interact()
    {
        Reset(StateType.Interact);
    }

    public override void Attack(){
        Reset(StateType.Attack);
    }
}
