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
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter1/Area2D").GlobalPosition);
    }
    
    public void OnStraightEnter1(Area2D trainArea)
    {
        GD.Print("enter 1");    
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter0/Area2D").GlobalPosition);
    }
    
}
