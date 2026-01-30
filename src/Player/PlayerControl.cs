using Godot;
using System;

public partial class PlayerControl : Control
{
	Label HP;

	int health = 100;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("_Ready: PlayerControll");
		HP = GetNode<Label>("%HP");
		HP.Text = health.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_change_lvl_pressed() {
		setHp(20);
		GD.Print(health);
		if (health <= 0) {
			GetTree().ChangeSceneToFile("res://control.tscn");
			GD.Print("You lost!");
		}
	}

	public void setHp(int newHp) {
		if ( health <= 0 ) {
			GD.Print("No more health");
		} else { 
			health -= newHp;
			HP.Text = health.ToString();
		};
	}

	public int getHp() {
		return health;
	}

	public void _on_body_entered() {
		GD.Print("enee1");
	}

	public void _on_area_2d_area_entered(){
		GD.Print("Entered");
	}
}
