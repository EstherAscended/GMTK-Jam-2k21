using Godot;
using System;

public class LevelGrid : Node2D
{
    private bool canAddWaypoint = true;
    private Node2D lastTouchedArea;
    private Node2D emptyArea;
    private float waypointDelay = 3f;
    public override void _Ready()
    {
        //This is perhaps a temp solution for dealing with the tile overlap. Could change to check direction
        emptyArea = new Node2D();
        lastTouchedArea = emptyArea;
    }

    public void LeftToRight(Area2D trainArea)
    {
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this && trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Left to Right");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            //GD.Print($"Collider: {trainArea.GetParent<Train>().GlobalPosition.x} - Collided: {GlobalPosition.x}");
            //GD.Print(trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x);
            if (trainArea.GetParent<Train>().GlobalPosition.x < GlobalPosition.x)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("RightToLeft/Area2D").GlobalPosition);
            }
        }
    }
    
    public void RightToLeft(Area2D trainArea)
    {
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this && trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Right to Left");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            //GD.Print($"Collider: {trainArea.GetParent<Train>().GlobalPosition.x} - Collided: {GlobalPosition.x}");
            //GD.Print(trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x);
            if (trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("LeftToRight/Area2D").GlobalPosition);
            }
        }
    }
    
    public void TopToBottom(Area2D trainArea)
    {
        //GD.Print("enter 2");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter3/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Top to Bottom");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y < GlobalPosition.y)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("BottomToTop/Area2D").GlobalPosition);
            }
        }
    }
    public void BottomToTop(Area2D trainArea)
    {
        //GD.Print("enter 3");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter2/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Bottom to Top");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y > GlobalPosition.y)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("TopToBottom/Area2D").GlobalPosition);
            }
        }
    }
    public void LeftToBottom(Area2D trainArea)
    {
        //GD.Print("enter 4");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter5/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Left to Bottom");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.x < GlobalPosition.x)
            {
                ResetWaypointAdding(waypointDelay);
                Vector2 initialPosition = GetNode<Area2D>("LeftToBottom/Area2D").GlobalPosition;
                Vector2 finalPosition = GetNode<Area2D>("BottomToLeft/Area2D").GlobalPosition;
                Train train = trainArea.GetParent<Train>();
                
                Vector2 midpoint = initialPosition + new Vector2(82, 18);
                train.AddWaypoint(midpoint);
                train.AddWaypoint(finalPosition);
            }
        }
    }
    public void BottomToLeft(Area2D trainArea)
    {
        //GD.Print("enter 5");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter4/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Bottom to Left");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().SecondLastTouchedTile = trainArea.GetParent<Train>().LastTouchedTile;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y > GlobalPosition.y)
            {
                ResetWaypointAdding(waypointDelay);
                // Fuck you Russell
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("LeftToBottom/Area2D").GlobalPosition);
            }
        }
    }
    public void LeftToTop(Area2D trainArea)
    {
        //GD.Print("enter 4");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter5/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Left to Top");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().SecondLastTouchedTile = trainArea.GetParent<Train>().LastTouchedTile;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.x < GlobalPosition.x)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("TopToLeft/Area2D").GlobalPosition);
            }
        }
    }
    public void TopToLeft(Area2D trainArea)
    {
        //GD.Print("enter 5");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter4/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Top to Left");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().SecondLastTouchedTile = trainArea.GetParent<Train>().LastTouchedTile;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y < GlobalPosition.y)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("LeftToTop/Area2D").GlobalPosition);
            }
        }
    }
    public void RightToBottom(Area2D trainArea)
    {
        //GD.Print("enter 6");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter7/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Right to Bottom");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().SecondLastTouchedTile = trainArea.GetParent<Train>().LastTouchedTile;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("BottomToRight/Area2D").GlobalPosition);
            }
        }
    }

    public void BottomToRight(Area2D trainArea)
    {
        //GD.Print("enter 7");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter6/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Bottom to Right");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().SecondLastTouchedTile = trainArea.GetParent<Train>().LastTouchedTile;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y > GlobalPosition.y)
            {
                ResetWaypointAdding(waypointDelay);
                Vector2 initialPosition = GetNode<Area2D>("BottomToRight/Area2D").GlobalPosition;
                Vector2 finalPosition = GetNode<Area2D>("RightToBottom/Area2D").GlobalPosition;
                Train train = trainArea.GetParent<Train>();
                
                Vector2 midpoint = initialPosition + new Vector2(18, -82);
                train.AddWaypoint(midpoint);
                train.AddWaypoint(finalPosition);
            }
        }
    }

    public void RightToTop(Area2D trainArea)
    {
        //GD.Print("enter 6");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter7/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this)
        {
            GD.Print("Right to Top");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().SecondLastTouchedTile = trainArea.GetParent<Train>().LastTouchedTile;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.x > GlobalPosition.x)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("TopToRight/Area2D").GlobalPosition);
            }
        }
    }
    public void TopToRight(Area2D trainArea)
    {
        //GD.Print("enter 7");    
        //trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("Enter6/Area2D").GlobalPosition);
        if (trainArea.GetParent().Name == "Train" && lastTouchedArea != this &&
            trainArea.GetParent<Train>().LastTouchedTile != this && trainArea.GetParent<Train>().SecondLastTouchedTile != this) 
        {
            GD.Print("Top to Right");
            lastTouchedArea = this;
            trainArea.GetParent<Train>().SecondLastTouchedTile = trainArea.GetParent<Train>().LastTouchedTile;
            trainArea.GetParent<Train>().LastTouchedTile = this;
            GD.Print(this);
            if (trainArea.GetParent<Train>().GlobalPosition.y < GlobalPosition.y)
            {
                ResetWaypointAdding(waypointDelay);
                trainArea.GetParent<Train>().AddWaypoint(GetNode<Area2D>("RightToTop/Area2D").GlobalPosition);
            }
        }
    }
    
    //This method exists to attempt and prevent the train from turning around whenever it contacts to waypoints
    //at once
    private async void ResetWaypointAdding(float time)
    {
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        lastTouchedArea = emptyArea;
    }
}
