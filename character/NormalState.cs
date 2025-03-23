using Godot;
using System;

public partial class NormalState : Node
{
	private CharacterBody2D _character;
	private CollisionShape2D _normalCollision;
	private CollisionShape2D _swordCollision;
	private AnimatedSprite2d _animatedSprite2d;

	public override void _Ready()
	{
		_character = GetParent().GetParent<CharacterBody2D>();
		_normalCollision  = GetNode<CollisionShape2D>("../../CollisionShape2D");
		_swordCollision   = GetNode<CollisionShape2D>("../../CollisionShape2D_Sword");
		_animatedSprite2d = GetNode<AnimatedSprite2d>("../../AnimatedSprite2D");
	}

	public void Enter()
	{
		GD.Print("Entrei no normal normal");
		_swordCollision.Disabled = true;
		_normalCollision.Disabled = false;
		_animatedSprite2d.Play("idle");
	}

	public void Exit()
	{
		GD.Print("Sai do normal normal");
	}

	public void Update(float delta)
	{
		if (Input.IsActionJustPressed("attack_1"))
		{
			_character.GetNode<StateMachine>("StateMachine")
				.ChangeState(_character.GetNode<Node>("StateMachine/SwordState"));
		}
	}
}
