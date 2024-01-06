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

	public async void PlayAnimation(){
		Visible = true;
		GetChild<AnimatedSprite2D>(2).Play();
		GetChild(1).GetChild<CollisionShape2D>(0).Disabled = false;
	}
	private void _on_animated_sprite_2d_animation_finished()
	{
		GetChild<AnimatedSprite2D>(2).Stop();
		GetChild(1).GetChild<CollisionShape2D>(0).Disabled = true;
		Visible = false;
	}

}

