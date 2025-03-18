using Godot;
using System;

public partial class SwordState : Node
{
	private CharacterBody2D _character;
	private CollisionShape2D _normalCollision;
	private CollisionShape2D _swordCollision;
	private AnimatedSprite2d _animated;

	public override void _Ready()
	{
		_character = GetParent().GetParent<CharacterBody2D>();
		_normalCollision = GetNode<CollisionShape2D>("../../CollisionShape2D");
		_swordCollision  = GetNode<CollisionShape2D>("../../CollisionShape2D_Sword");
		_animated		 = GetNode<AnimatedSprite2d>("../../AnimatedSprite2D");
	}

	public void Enter()
	{
		GD.Print("Entrando no estado Espada");
		_normalCollision.Disabled = true;
		_swordCollision.Disabled = false;
		_animated.Play("idle_with_sword");

		_animated.AnimationFinished += OnAnimationFinished;
	}

	public void Exit()
	{
		GD.Print("saindo do estado Espada");
		_animated.AnimationFinished -= OnAnimationFinished;
	}

	public void Update(double delta)
	{
		if (Input.IsActionJustReleased("idle_attack"))
		{
			_character.GetNode<StateMachine>("StateMachine")
				.ChangeState(_character.GetNode<Node>("StateMachine/NormalState"));
		}
	}

	public void OnAnimationFinished()
	{
		if (_animated.Animation == "attack")
		{
			_animated.Play("sword_idle");
		}
	}
}
