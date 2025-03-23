using Godot;
using System;
using TreasureHunters.character;

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
		_animated.Play("attack_1");

		_animated.AnimationFinished += OnAnimationFinished;
	}

	public void Exit()
	{
		GD.Print("saindo do estado Espada");
		_animated.AnimationFinished -= OnAnimationFinished;
	}

	public void Update(double delta)
	{
		if (Input.IsActionJustPressed("ui_left") || Input.IsActionJustPressed("ui_right"))
		{
			_animated.Play(Animations.WithSword.Run);
		}
		if (Input.IsActionJustPressed("ui_accept"))
		{
			_animated.Play(Animations.WithSword.Jump);
		}
		if (Input.IsActionJustPressed(Animations.WithSword.Attack1))
		{
			_animated.Play(Animations.WithSword.Attack1);
		}
		if (Input.IsActionJustPressed(Animations.WithSword.Attack2))
		{
			_animated.Play(Animations.WithSword.Attack2);
		}
		if (Input.IsActionJustPressed(Animations.WithSword.Attack3))
		{
			_animated.Play(Animations.WithSword.Attack3);
		}

		//if (Input.IsActionJustReleased("attack"))
		//{
		//	_character.GetNode<StateMachine>("StateMachine")
		//		.ChangeState(_character.GetNode<Node>("StateMachine/NormalState"));
		//}
	}

	public void OnAnimationFinished()
	{
		if (_animated.Animation == "jump_with_sword")
		{
			_animated.Play("land_with_sword");
		}
		if (_animated.Animation == "land_with_sword")
		{
			_animated.Play("idle_with_sword");
		}
		if (_animated.AnimationEndsIs("attack_1", "attack_2", "attack_3", "air_attack_1", "run_with_sword"))
		{
			_animated.Play("idle_with_sword");
		}
	}
}
