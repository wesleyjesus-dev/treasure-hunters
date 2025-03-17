using Godot;
using System;

public partial class Character : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

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

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
			EmitSignal(SignalName.CharacterFall);
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
}
