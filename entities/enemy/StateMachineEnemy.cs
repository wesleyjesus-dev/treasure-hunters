using Godot;
public partial class StateMachineEnemy : Node
{
	private Node _currentState;

	public void ChangeState(Node currentState)
	{
		if (currentState == null)
		{
			_currentState.Call("Exit");
		}

		_currentState = currentState;
		_currentState.Call("Enter");
	}

	public void Update(double delta)
	{
		if (_currentState == null)
		{
			_currentState.Call("Update", delta);
		}
	}
}
