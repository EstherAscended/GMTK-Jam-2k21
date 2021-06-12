using Godot;
using System;

public class LevelGrid : Node2D
{
    public override void _Ready()
    {

    }

    public void OnStraightEnter0(Area2D trainArea)
    {
        if (trainArea.GetParent().Name == "Train")
        {
            //GD.Print("enter 0");   
            GD.Print($"Collider: {trainArea.GetParent<Train>().lastWaypoint.x > GlobalPosition.x} - Collided: {GlobalPosition}");
            GD.Print(trainArea.GetParent<Train>().lastWaypoint.x > GlobalPosition.x);
            if (trainArea.GetParent<Train>().lastWaypoint.x < GlobalPosition.x)
            {
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter1/Area2D").GlobalPosition);
            }
        }
    }
    
    public void OnStraightEnter1(Area2D trainArea)
    {
        if (trainArea.GetParent().Name == "Train")
        {
            //GD.Print("enter 1");   
            GD.Print($"Collider: {trainArea.GetParent<Train>().lastWaypoint.x > GlobalPosition.x} - Collided: {GlobalPosition}");
            GD.Print(trainArea.GetParent<Train>().lastWaypoint.x > GlobalPosition.x);
            if (trainArea.GetParent<Train>().lastWaypoint.x < GlobalPosition.x)
            {
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter0/Area2D").GlobalPosition);
            }
        }
    }
    
    public void OnStraightEnter2(Area2D trainArea)
    {
        //GD.Print("enter 2");    
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter3/Area2D").GlobalPosition);
    }
    public void OnStraightEnter3(Area2D trainArea)
    {
        //GD.Print("enter 3");    
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter2/Area2D").GlobalPosition);
    }
    public void OnStraightEnter4(Area2D trainArea)
    {
        //GD.Print("enter 4");    
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter5/Area2D").GlobalPosition);
    }
    public void OnStraightEnter5(Area2D trainArea)
    {
        //GD.Print("enter 5");    
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter4/Area2D").GlobalPosition);
    }
    public void OnStraightEnter6(Area2D trainArea)
    {
        //GD.Print("enter 6");    
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter7/Area2D").GlobalPosition);
    }
    public void OnStraightEnter7(Area2D trainArea)
    {
        //GD.Print("enter 7");    
        trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter6/Area2D").GlobalPosition);
    }
}
