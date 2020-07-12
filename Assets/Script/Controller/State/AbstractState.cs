using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState
{
    
    public enum StateType
    {
        Iddle,Interact,Attack
    }
    protected Controller _controller;
    protected float multiplier = 1;
    public AbstractState(Controller controller)
    {
        _controller = controller;
        _controller.debugState.text = this.GetType().ToString();
    }

    public virtual void Update()
    {
        _controller.rigidbody.velocity = new Vector3(_controller.velocity.x, 0,_controller.velocity.y) * _controller.speed * multiplier;
        _controller.animator.SetFloat("velocity", _controller.velocity.magnitude);
        if(_controller.velocity.magnitude>0.1f)
            _controller.animator.SetInteger("dir", (_controller.velocity.y <= 0)?0:1);
    }

    public virtual void SetDirection()
    {
        if (Mathf.Abs(_controller.velocity.x) > Mathf.Abs(_controller.velocity.y))
        {
            if (_controller.velocity.x > 0) _controller.direction = Controller.Direction.Right;
            else if (_controller.velocity.x < 0) _controller.direction = Controller.Direction.Left;
        }
        else
        {
            if (_controller.velocity.y > 0) _controller.direction = Controller.Direction.Top;
            else if (_controller.velocity.y < 0) _controller.direction = Controller.Direction.Bottom;
        }
    }
    
    
    public virtual void Interact(){}
    public virtual void Attack(){}

    public virtual void Reset(StateType type)
    {
        switch (type)
        {
            case StateType.Iddle:
                _controller.state = new IdleState(_controller);
                break;
            case StateType.Interact:
                if(_controller.interactTo != null) _controller.state = new InteractState(_controller,_controller.interactTo);
                else _controller.state = new IdleState(_controller);
                break;
            case StateType.Attack:
                _controller.state = new AttackState(_controller);
                break;
            default:
                Debug.Log("Erreur! State non reconnu");
                break;
        }
    }
    
}
