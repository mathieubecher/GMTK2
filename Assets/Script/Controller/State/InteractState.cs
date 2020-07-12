
using UnityEngine;

public class InteractState : AbstractState
{
    public Interactable _interactable;
    private bool upgradeInput;
    
    public InteractState(Controller controller, Interactable interactable) : base(controller)
    {
        multiplier = 0.7f;
        _interactable = interactable;
        _interactable.Wear(_controller);
        controller.couldCreate = false;
        _controller.animator.SetBool("wear",true);
        _controller.sound.Wear();
    }

    public override void Update()
    {
        if (_interactable.existUpgrade)
        {
            if (Input.GetKey(_controller.upgradeKey) && !upgradeInput)
            {
                upgradeInput = true;
                _interactable.Upgrade();
            }
            else if(!Input.GetKey(_controller.upgradeKey)) upgradeInput = false;
        }

        base.Update();
           
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

    public override void Reset(StateType type)
    {
        _controller.sound.Release();
        base.Reset(type);
    }
}
