using Godot;
using System;

public partial class Crabby : CharacterBody2D
{
	private Area2D hitbox;

	private int health = 100;
	private Label _hp;
	private AnimatedSprite2D _anim;
	public override void _Ready()
	{
		hitbox = GetChild<Area2D>(2);
		_hp = GetNode<Label>("HpLabel");
		_anim = GetChild<AnimatedSprite2D>(0);
		
	}
	public override void _PhysicsProcess(double delta)
	{

	}

	public void AttackReceived(int attack)
	{
		_hp.Visible = true;
		health -= attack;
		_hp.Text = health.ToString();
		GD.Print("recebi um attack");

		if(health <= 0)
		{
			_anim.Play("crabby_hit");
		}
		else
		{
			_anim.Play("crabby_dead_hit");
			
		}
		
	}


	public void EnableAndDisableHitBox()
	{
		hitbox.SetDeferred("monitoring", false);

		GetTree().CreateTimer(0.2).Timeout += () => hitbox.SetDeferred("monitoring", true);
	}
}
