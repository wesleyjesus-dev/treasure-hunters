using Godot;
using System;

public partial class CrabbyAnimatedSprite2d : AnimatedSprite2D
{
	private CharacterBody2D Crappy;

	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		Play("idle");
	}
}
