using Godot;
using System;
using System.Collections.Generic;

public class TrainEngine : Carriage
{
    // When a train passes a station, tell the engine that it's expecting a new carriage.
    // When the backmost carriage passes the station, attach the new carriage to the end of it.
    // Set the initial waypoint of the new carriage to be the current waypoint of the former backmost carriage.

    public List<Carriage> attachedCarriages;
    public PackedScene carriageScene;
    public Carriage carriageSpawn;
    public Carriage secondCarriage;

    public void TrainBodyCollision(Area2D area)
    {
        if (area.Name != "CrashChecker") return;
        GD.Print("Body collision");
        gameManager.IsGameOver = true;
        //GetNode<SFX>("../CrashSFX").Play();
    }
    
    public override void _Ready()
    {
        base._Ready();

        // attachedCarriages = new List<Carriage>();
        // carriageScene = GD.Load<PackedScene>("res://scenes/Carriage.tscn");
        // carriageSpawn = carriageScene.Instance<Carriage>();        
        //
        // carriageSpawn.GlobalPosition = this.GlobalPosition + new Vector2(-180, 0);
        // carriageSpawn.InitialWaypoint = this.lastWaypoint;
        // carriageSpawn.TrainSpeed = this.TrainSpeed;
        // GetTree().Root.AddChild(carriageSpawn);
        //
        // secondCarriage = carriageScene.Instance<Carriage>();  
        // secondCarriage.GlobalPosition = carriageSpawn.GlobalPosition + new Vector2(-180, 0);
        // secondCarriage.InitialWaypoint = carriageSpawn.lastWaypoint;
        // secondCarriage.TrainSpeed = carriageSpawn.TrainSpeed;
        // secondCarriage.Texture = GD.Load<Texture>("res://assets/art/Coal Carriage.PNG");
        // GetTree().Root.AddChild(secondCarriage);
    }
    
}
