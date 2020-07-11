



using UnityEngine;

public class AttackState : AbstractState
{
    private StateType type = StateType.Iddle;
    private float timer = 1;
    public AttackState(Controller controller) : base(controller)
    {
        controller.rigidbody.velocity = Vector3.zero;
        controller.attackPoint.Active(controller.direction);
        controller.couldCreate = false;
    }

    public override void Update()
    {
        timer -= Time.deltaTime * _controller.attackSpeed;
        if (timer < 0)
        {
            _controller.attackPoint.ResetAll();
            Reset(type);
        }
    }

    public override void SetDirection() {}
    
    public override void Interact() {type = StateType.Interact; }
    public override void Attack() {type = StateType.Attack; }
}
