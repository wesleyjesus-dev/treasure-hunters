using Godot;
using System;
using GdUnit4;
using GdUnit4.Api;
using GdUnit4.Core;
using System.Text;
using System.Threading.Tasks;

[TestSuite]
public class CharacterTests
{

	[TestCase]
	public async Task Teste()
	{
		var runner = ISceneRunner.Load("res://levels/island_t_1.tscn");

		runner.SimulateKeyPressed(Key.Space);

		Console.WriteLine("teste");

		await runner.AwaitIdleFrame();

		await runner.AwaitSignal("CharacterJump");
	}

}
