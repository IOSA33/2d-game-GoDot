using Godot;
using System;

public partial class NewScript : Node
{
	Label CoinsValueText;
	protected Label HP;
	protected int playerHP = 100;
	int coinsValue = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("_Reade: Welcome to the Game!");
		CoinsValueText = GetNode<Label>("%CoinsValueText");
		HP = GetNode<Label>("%HP");

		CoinsValueText.Text = coinsValue.ToString();
		HP.Text = playerHP.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnButtonPressedCoins()
	{
		coinsValue += 10;
		GD.Print(coinsValue);
		CoinsValueText.Text = coinsValue.ToString();
	}

	public void OnGetDamaged()
    {
        GD.Print("called!");
		SetHP(10);
    }

	public virtual void SetHP(int newHp) {
		GD.Print("base class");
	}

	public void OnPlayButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://node_2d.tscn");

	}
}
