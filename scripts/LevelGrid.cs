using Godot;
using System;

public class LevelGrid : Node2D
{
    private float trainSpeed = 1;
    private Train train;
    
    public override void _Ready()
    {
        train = GetNode<Train>("Train");

    }

    public void OnStraightEnter0(Area2D trainArea)
    {
        GD.Print("enter 0");    
        Vector2 newPosition = GetNode<Area2D>("TileHorizontal/Enter0/Area2D").GlobalPosition + new Vector2(128, 0);
        trainArea.GetParent<Train>().AddWaypoint(newPosition);
    }
    
    public void OnStraightEnter1(Area2D trainArea)
    {
        GD.Print("enter 1");    
        Vector2 newPosition = GetNode<Area2D>("TileHorizontal/Enter1/Area2D").GlobalPosition + new Vector2(-128, 0);
        trainArea.GetParent<Train>().AddWaypoint(newPosition);
    }
    
}
