using System;
using Godot;

public partial class Player : NewScript
{
	public override void SetHP(int newHp)
	{
		if (playerHP > 0)
		{
			playerHP -= newHp;
			HP.Text = playerHP.ToString();
		} else
		{
			HP.Text = playerHP.ToString(); 
		}
	}

	public int GetHP()
	{
		return playerHP;
	}
}
