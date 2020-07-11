
using UnityEngine;

public class InteractState : AbstractState
{
    public Interactable _interactable;
    
    public InteractState(Controller controller, Interactable interactable) : base(controller)
    {
        multiplier = 0.7f;
        _interactable = interactable;
        _interactable.Wear(_controller);
    }

    public override void Interact()
    {
        _interactable.Release(_controller.wearPoint.GetPoint(_controller.direction));
        Reset(StateType.Iddle);
    }

    public override void Attack()
    {
        _interactable.Release(_controller.wearPoint.GetPoint(_controller.direction));
        Reset(StateType.Iddle);
    }
}
