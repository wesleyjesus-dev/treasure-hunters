using Godot;
using System;

public partial class Crabby : CharacterBody2D
{
	public override void _PhysicsProcess(double delta)
	{
		int collisionCount = GetSlideCollisionCount();
		for (int i = 0; i < collisionCount; i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);
			GD.Print($"Colidiu com: {collision.GetCollider()}");

			if (collision.GetCollider() is Node2D other)
			{
				GD.Print("Nome do nó colidido: " + other.Name);
			}
		}
	}
}
