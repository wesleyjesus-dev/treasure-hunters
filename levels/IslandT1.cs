using Godot;

public partial class IslandT1 : Node2D
{
	[Export] public PackedScene PlayerScene;
	public override void _Ready()
	{
		GD.Print("chamei o ready");
		if (Multiplayer.IsServer())
		{
			// Para todos os peers conectados (inclui o host também)
			foreach (var id in Multiplayer.GetPeers())
			{
				GD.Print("spawnei um player [Server]");
				SpawnPlayer((int)id);
			}
		}
		else
		{
			GD.Print("spawnei um player [NoServer]");
			// Cliente só instancia o próprio jogador
			SpawnPlayer(Multiplayer.GetUniqueId());
		}
	}

	[Rpc(MultiplayerApi.RpcMode.Authority | MultiplayerApi.RpcMode.AnyPeer)]
	public void SpawnPlayer(int id)
	{
		GD.Print($"spawnPlayer {id}");
		var player = PlayerScene.Instantiate() as Character;
		player.Name = $"Player_{id}";
		player.SetMultiplayerAuthority(id);
		//player.GlobalPosition = GetSpawnPosition(id); // opcional
		AddChild(player);
	}

	private Vector2 GetSpawnPosition(int id)
	{
		// Pode ser randomizado, baseado em ponto de spawn, etc.
		return new Vector2(100 + id * 100, 200);
	}
}
