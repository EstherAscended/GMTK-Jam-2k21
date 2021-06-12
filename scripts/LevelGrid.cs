using Godot;
using System;

public class LevelGrid : Node2D
{
    private bool canAddWaypoint = true;
    private Node2D lastTouchedArea;
    private Node2D emptyArea;
    public override void _Ready()
    {
        //This is perhaps a temp solution for dealing with the tile overlap. Could change to check direction
        emptyArea = new Node2D();
        lastTouchedArea = emptyArea;
    }

    public void OnStraightEnter0(Area2D trainArea)
    {
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this && trainArea.GetParent<Train>().LastTouchedTile != this)
        {
            //GD.Print("enter 0");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            //GD.Print($"Collider: {trainArea.GetParent<Train>().GlobalPosition.x} - Collided: {GlobalPosition.x}");
            //GD.Print(trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x);
            if (trainArea.GetParent<Train>().GlobalPosition.x < GlobalPosition.x)
            {
                ResetWaypointAdding(4);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter1/Area2D").GlobalPosition);
            }
        }
    }
    
    public void OnStraightEnter1(Area2D trainArea)
    {
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this && trainArea.GetParent<Train>().LastTouchedTile != this)
        {
            //GD.Print("enter 1");   
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            //GD.Print($"Collider: {trainArea.GetParent<Train>().GlobalPosition.x} - Collided: {GlobalPosition.x}");
            //GD.Print(trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x);
            if (trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x)
            {
                ResetWaypointAdding(4);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter0/Area2D").GlobalPosition);
            }
        }
    }
    
    public void OnStraightEnter2(Area2D trainArea)
    {
        //GD.Print("enter 2");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter3/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this)
        {
            GD.Print("enter 2");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y < GlobalPosition.y)
            {
                ResetWaypointAdding(4);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter3/Area2D").GlobalPosition);
            }
        }
    }
    public void OnStraightEnter3(Area2D trainArea)
    {
        //GD.Print("enter 3");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter2/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this)
        {
            GD.Print("enter 3");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y > GlobalPosition.y)
            {
                ResetWaypointAdding(4);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter2/Area2D").GlobalPosition);
            }
        }
    }
    public void OnStraightEnter4(Area2D trainArea)
    {
        //GD.Print("enter 4");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter5/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this)
        {
            GD.Print("enter 4");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.x < GlobalPosition.x)
            {
                ResetWaypointAdding(4);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter5/Area2D").GlobalPosition);
            }
        }
    }
    public void OnStraightEnter5(Area2D trainArea)
    {
        //GD.Print("enter 5");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter4/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this)
        {
            GD.Print("enter 5");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y > GlobalPosition.y)
            {
                ResetWaypointAdding(4);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter4/Area2D").GlobalPosition);
            }
        }
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
    
    //This method exists to attempt and prevent the train from turning around whenever it contacts to waypoints
    //at once
    private async void ResetWaypointAdding(float time)
    {
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        lastTouchedArea = emptyArea;
    }
}
