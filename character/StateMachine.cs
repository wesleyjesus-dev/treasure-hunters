using Godot;
using System;

public partial class StateMachine : Node
{
	private Node _currentState;

	public void ChangeState(Node currentState)
	{
		if (_currentState != null)
		{
			_currentState.Call("Exit");
		}

		_currentState = currentState;
		_currentState.Call("Enter");
	}

	public void Update(float delta)
	{
		if (_currentState != null)
		{
			_currentState.Call("Update", delta);
		}
	}
}
