using Godot;
using System;

public partial class NormalState : Node
{
	private CharacterBody2D _character;
	private CollisionShape2D _normalCollision;
	private CollisionShape2D _swordCollision;

	public override void _Ready()
	{
		_character = GetParent().GetParent<CharacterBody2D>();
		_normalCollision = GetNode<CollisionShape2D>("CollisionShape2DNormal");
	}
}
