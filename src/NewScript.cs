using Godot;
using System;

public partial class NewScript : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("_Reade: Welcome to the Game!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void OnPlayButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://node_2d.tscn");
	}
}
