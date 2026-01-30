using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -600.0f;

	private void ChangeSceneDeferred()
	{
		GetTree().ChangeSceneToFile("res://control.tscn");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "ui_up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void _on_area_2d_area_entered(Area2D area){
		GD.Print("Entered: " + area.Name);	
		var playCtrl = GetTree().Root.FindChild("Control", true, false) as PlayerControl;
		if (playCtrl != null)
		{
			playCtrl.setHp(10);
			if (playCtrl.getHp() <= 0)
			{
				CallDeferred(nameof(ChangeSceneDeferred));
			}
		}
	}


	public void OnVoidEntered(Area2D area) {
		GD.Print("Entered: " + area.Name);
		GD.Print("You Lost! Jumped in the void!");
		CallDeferred(nameof(ChangeSceneDeferred));
	}

	public void OnWinningAreaEntered(Area2D area) {
		GD.Print("Entered: " + area.Name);
		GD.Print("You Won the Game and Collected in total: ");
		CallDeferred(nameof(ChangeSceneDeferred));
	}
}
