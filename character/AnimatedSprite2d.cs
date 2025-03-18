using Godot;
using System;

public partial class AnimatedSprite2d : AnimatedSprite2D
{
	[Export]
	private CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnCharacterIdle()
	{
		//Play("idle");
	}

	public void OnCharacterFall()
	{
		//Play("fall");
	}

	public void OnCharacterJump()
	{
		//Play("jump");
	}

	public void OnCharacterMoveXDirection()
	{
		//Play("run");
	}

	public void OnCharacterMovedToRight()
	{
		FlipH = false;
	}

	public void OnCharacterMovedToLeft()
	{
		FlipH = true;
	}

	public void OnCharacterLand()
	{
		//Play("land");
	}
}


