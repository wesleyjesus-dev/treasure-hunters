using Godot;
using System;

public partial class Character : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	
	private StateMachine _stateMachine;
	private Node _normalState;

    public override void _Ready()
    {
		_stateMachine = GetNode<StateMachine>("StateMachine");
		_normalState = GetNode<Node>("StateMachine/NormalState");

		_stateMachine.ChangeState(_normalState);
    }

    public override void _PhysicsProcess(double delta)
	{
        _stateMachine.Update(delta);

        Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
			EmitSignal(SignalName.CharacterFall);
		}
		else
		{
			EmitSignal(SignalName.CharacterLand);
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			EmitSignal(SignalName.CharacterJump);
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			if (direction.X > 0)
			{
                EmitSignal(SignalName.CharacterMovedToRight);
            }
			else
			{
                EmitSignal(SignalName.CharacterMovedToLeft);
            }

			velocity.X = direction.X * Speed;
			EmitSignal(SignalName.MoveXDirection);
		}
		else
		{
			EmitSignal(SignalName.CharacterIdle);
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

    [Signal]
    public delegate void MoveXDirectionEventHandler();

    [Signal]
    public delegate void MoveYDirectionEventHandler();

    [Signal]
    public delegate void CharacterJumpEventHandler();

    [Signal]
    public delegate void CharacterIdleEventHandler();

    [Signal]
    public delegate void CharacterFallEventHandler();

    [Signal]
    public delegate void CharacterMovedToRightEventHandler();

    [Signal]
    public delegate void CharacterMovedToLeftEventHandler();

    [Signal]
    public delegate void CharacterLandEventHandler();
}
