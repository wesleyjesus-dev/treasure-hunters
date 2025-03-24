using Godot;
using System;
using System.Net;
using TreasureHunters;

public partial class Main : Control
{
	public override void _Ready()
	{
		GetNode<Button>("./BoxContainer/HBoxContainer/VBoxContainer/ButtonHost").Pressed += HostGame;
		//GetNode<Button>("ButtonJoin").Pressed += JoinGame;
	}

	private void HostGame()
	{
		var scene = GD.Load<PackedScene>("res://levels/island_t_1.tscn");
		GetTree().ChangeSceneToPacked(scene);
	}
}
