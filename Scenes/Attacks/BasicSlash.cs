using Godot;
using System;

public partial class BasicSlash : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ChangeDirection(string Direction)
	{
		
	}

	public void PlayAnimation(){
		Visible = true;
		GetParent().GetParent().GetChild<AnimatedSprite2D>(1).Play("SimpleSwingDown");
		//GetChild<AnimatedSprite2D>(2).Play();
		GetChild(0).GetChild<CollisionShape2D>(0).Disabled = false;
	}
	private void _on_animated_sprite_2d_animation_finished()
	{
		GetParent().GetParent().GetChild<AnimatedSprite2D>(1).Stop();
		GetChild<AnimatedSprite2D>(2).Stop();
		GetChild(0).GetChild<CollisionShape2D>(0).Disabled = true;
		Visible = false;
	}

}

