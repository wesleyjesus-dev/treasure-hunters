using Godot;
using System;

public partial class BackgroundParallaxBackground : ParallaxBackground
{
	[Export]
	private ParallaxLayer[] Clouds;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// Called every frame. But your difference is that the delta value is every same
	public override void _PhysicsProcess(double delta)
	{
		MoveCloudOnBackground(delta);
	}

	// TODO: Alterar a velocidade das nuvems conforme a distancia
	/// <summary>
	/// Este codigo e utilizado para movimentar as nuvens no cenario
	/// </summary>
	/// <param name="delta"></param>
	private void MoveCloudOnBackground(double delta)
	{
		foreach (var cloud in Clouds)
		{
			float speed = 10; // Velocidade do efeito
			cloud.MotionOffset += new Vector2(speed * (float)delta, 0);
		}
	}
}
