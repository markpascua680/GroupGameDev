using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 InputDirection;
	
	private AnimatedSprite2D Animation;

	private string PlayerDirection;

	[Export]
	public int Speed { get; set; } = 100;

	public override void _Ready()
	{	
		Animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	public void GetInput()
	{
		InputDirection = Input.GetVector("Left", "Right", "Up", "Down");
		Velocity = InputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
		PlayAnimation();
	}

	private void PlayAnimation()
	{
		if (Input.IsActionPressed("Up"))
		{
			if (Input.IsActionPressed("Left"))
				PlayerDirection = "WalkUpLeft";
			else if (Input.IsActionPressed("Right"))
				PlayerDirection = "WalkUpRight";
			else
				PlayerDirection = "WalkUp";
		}
		else if (Input.IsActionPressed("Down"))
		{
			if (Input.IsActionPressed("Left"))
				PlayerDirection = "WalkDownLeft";
			else if (Input.IsActionPressed("Right"))
				PlayerDirection = "WalkDownRight";
			else
				PlayerDirection = "WalkDown";
		}
		else if (Input.IsActionPressed("Left"))
		{
			if (Input.IsActionPressed("Up"))
				PlayerDirection = "WalkUpLeft";
			else if (Input.IsActionPressed("Down"))
				PlayerDirection = "WalkDownLeft";
			else
				PlayerDirection = "WalkLeft";
		}
		else if (Input.IsActionPressed("Right"))
		{
			if (Input.IsActionPressed("Up"))
				PlayerDirection = "WalkUpRight";
			else if (Input.IsActionPressed("Down"))
				PlayerDirection = "WalkDownRight";
			else
				PlayerDirection = "WalkRight";
		}
		
		if (Input.IsActionJustReleased("Up"))
		{
			PlayerDirection = "IdleUp";
		}
		else if (Input.IsActionJustReleased("Down"))
		{
			PlayerDirection = "IdleDown";
		}
		else if (Input.IsActionJustReleased("Left"))
		{
			PlayerDirection = "IdleLeft";
		}
		else if (Input.IsActionJustReleased("Right"))
		{
			PlayerDirection = "IdleRight";
		}

		Animation.Play(PlayerDirection);
	}
}
