using Godot;
using System;
using System.Numerics;
using Godot;


public partial class Player : CharacterBody2D
{

	private Godot.Vector2 InputDirection;
	
	private AnimatedSprite2D Animation;

	private string PlayerDirection;

	[Export]
	public int Speed { get; set; } = 100;

	public override void _Ready()
	{	
		Animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		BasicAttack();
	}

	
	public void GetInput()
	{
		InputDirection = Input.GetVector("Left", "Right", "Up", "Down");
		Velocity = InputDirection * Speed;
	}

	public async void BasicAttack()
	{
		GetChild(3).GetChild(0).Call("PlayAnimation");
		GD.Print(GetChild(3).GetChild(0).Name);
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
		PlayAnimation();
	}

	private void FlipAttack(int PlayerDirectionEnum,int distance)
	{

		switch(PlayerDirectionEnum){
			//Uses dpad fighting game number notation
			case 1:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(-distance,distance);
			break;
			case 2:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(0,distance);
			break;
			case 3:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(distance,distance);
			break;
			case 4:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(-distance,0);
			break;
			case 5:
			break;
			case 6:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(distance,0);
			break;
			case 7:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(-distance,-distance);
			break;
			case 8:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(0,-distance);
			break;
			case 9:
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(distance,-distance);
			break;	
		}
	}
	private void PlayAnimation()
	{
		GD.Print(PlayerDirection);
		GD.Print(GetChild(3).GetChild<Node2D>(0).Position);
		var distance = 12;
		int PlayerDirectionEnum = 0;
		if (Input.IsActionPressed("Up"))
		{
			if (Input.IsActionPressed("Left")) {
				PlayerDirection = "WalkUpLeft";
				PlayerDirectionEnum = 7;
				FlipAttack(PlayerDirectionEnum,distance);
				}
			else if (Input.IsActionPressed("Right"))
			{
				PlayerDirection = "WalkUpRight";
				PlayerDirectionEnum = 9;
				FlipAttack(PlayerDirectionEnum,distance);
			}
			else
			{
				PlayerDirection = "WalkUp";
				PlayerDirectionEnum = 8;
				FlipAttack(PlayerDirectionEnum,distance);
			}
		}
		else if (Input.IsActionPressed("Down"))
		{
			if (Input.IsActionPressed("Left")){
				PlayerDirection = "WalkDownLeft";
				PlayerDirectionEnum = 1;
				FlipAttack(PlayerDirectionEnum,distance);
			}
			else if (Input.IsActionPressed("Right"))
			{
				PlayerDirection = "WalkDownRight";
				PlayerDirectionEnum = 3;
				FlipAttack(PlayerDirectionEnum,distance);
			}
			else
			{
				PlayerDirection = "WalkDown";
				PlayerDirectionEnum = 2;
				FlipAttack(PlayerDirectionEnum,distance);
			}
		}
		else if (Input.IsActionPressed("Left"))
		{
			if (Input.IsActionPressed("Up")){
				PlayerDirection = "WalkUpLeft";
				PlayerDirectionEnum = 7;
				FlipAttack(PlayerDirectionEnum,distance);
			}
			else if (Input.IsActionPressed("Down"))
			{
				PlayerDirection = "WalkDownLeft";
				PlayerDirectionEnum = 1;
				FlipAttack(PlayerDirectionEnum,distance);
			}
			else{
				GetChild(3).GetChild<Node2D>(0).Position = new Godot.Vector2(-distance,0);
				PlayerDirection = "WalkLeft";
				PlayerDirectionEnum = 4;
				FlipAttack(PlayerDirectionEnum,distance);
			}
		}
		else if (Input.IsActionPressed("Right"))
		{
			if (Input.IsActionPressed("Up")){
				PlayerDirection = "WalkUpRight";
				PlayerDirectionEnum = 9;
				FlipAttack(PlayerDirectionEnum,distance);
			}
			else if (Input.IsActionPressed("Down")){
				PlayerDirection = "WalkDownRight";
				PlayerDirectionEnum = 3;
				FlipAttack(PlayerDirectionEnum,distance);
			}
			else{
				PlayerDirection = "WalkRight";
				PlayerDirectionEnum = 6;
				FlipAttack(PlayerDirectionEnum,distance);
			}
		}
		
		if (Input.IsActionJustReleased("Up"))
		{
			PlayerDirection = "IdleUp";
			PlayerDirectionEnum = 8;
			FlipAttack(PlayerDirectionEnum,distance);
		}
		else if (Input.IsActionJustReleased("Down"))
		{
			PlayerDirection = "IdleDown";
			PlayerDirectionEnum = 2;
			FlipAttack(PlayerDirectionEnum,distance);
		}
		else if (Input.IsActionJustReleased("Left"))
		{
			PlayerDirection = "IdleLeft";
			PlayerDirectionEnum = 4;
			FlipAttack(PlayerDirectionEnum,distance);
		}
		else if (Input.IsActionJustReleased("Right"))
		{
			PlayerDirection = "IdleRight";
			PlayerDirectionEnum = 6;
			FlipAttack(PlayerDirectionEnum,distance);
		}

		Animation.Play(PlayerDirection);
		
	}
}
