



public class AttackState : AbstractState
{
    private StateType type;
    public AttackState(Controller controller) : base(controller)
    {
        
    }

    public override void Update()
    {
        
    }

    public override void SetDirection() {}
    public override void Interact() {type = StateType.Interact; }
    public override void Attack() {type = StateType.Interact; }
}
