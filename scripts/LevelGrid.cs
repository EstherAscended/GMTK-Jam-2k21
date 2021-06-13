using Godot;
using System;

public class LevelGrid : Node2D
{
    private bool canAddWaypoint = true;
    private Node2D emptyArea;
    private float waypointDelay = 3f;
    private GameManager gameManager;
    
    private double smoothness = 8;  // How many waypoints created when going around a corner
    private int distAroundCorner = 104; // Half a tile length +4 
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetChild(0).GetNode<GameManager>("GameManager");
        //This is perhaps a temp solution for dealing with the tile overlap. Could change to check direction
        emptyArea = new Node2D();
    }

    public void LeftToRight(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
       // if (!trainArea.GetParent().Name.Contains("Carriage")) return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.x > train.waypointQueue.Peek().x) return;

        GD.Print("Left to Right");

        if (train.GlobalPosition.x < GlobalPosition.x)
        {
            ResetWaypointAdding(waypointDelay);
            train.AddWaypoint(GetNode<Area2D>("RightToLeft/Area2D").GlobalPosition);
        }
        
    }
    
    public void RightToLeft(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.x < train.waypointQueue.Peek().x) return;

        GD.Print("Right to Left");

        if (train.GlobalPosition.x > GlobalPosition.x)
        {
            ResetWaypointAdding(waypointDelay);
            train.AddWaypoint(GetNode<Area2D>("LeftToRight/Area2D").GlobalPosition);
        }
    }
    
    public void TopToBottom(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.y > train.waypointQueue.Peek().y) return;

        GD.Print("Top to Bottom");

        if (train.GlobalPosition.y < GlobalPosition.y)
        {
            ResetWaypointAdding(waypointDelay);
            train.AddWaypoint(GetNode<Area2D>("BottomToTop/Area2D").GlobalPosition);
        }
    }
    public void BottomToTop(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.y < train.waypointQueue.Peek().y) return;

        GD.Print("Bottom to Top");

        if (train.GlobalPosition.y > GlobalPosition.y)
        {
            ResetWaypointAdding(waypointDelay);
            train.AddWaypoint(GetNode<Area2D>("TopToBottom/Area2D").GlobalPosition);
        }
    }
    public void LeftToBottom(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.x > train.waypointQueue.Peek().x) return;

        GD.Print("Left to Bottom");

        if (train.GlobalPosition.x < GlobalPosition.x)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("LeftToBottom/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("BottomToLeft/Area2D").GlobalPosition;
                
            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition - new Vector2(distAroundCorner * (float) (Math.Sin(angle)), 
                    -distAroundCorner * (float) (1 + Math.Cos(angle))));
            }
            train.AddWaypoint(finalPosition);
        }
    }
    
    public void BottomToLeft(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.y < train.waypointQueue.Peek().y) return;

        GD.Print("Bottom to Left");
        
        if (train.GlobalPosition.y > GlobalPosition.y)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("BottomToLeft/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("LeftToBottom/Area2D").GlobalPosition;
                
            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition - new Vector2(distAroundCorner * (float) (1 + Math.Cos(angle)), 
                    -distAroundCorner * (float) Math.Sin(angle)));
            }
            train.AddWaypoint(finalPosition);
        }
    }
    public void LeftToTop(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.x > train.waypointQueue.Peek().x) return;

        GD.Print("Left to Top");

        if (train.GlobalPosition.x < GlobalPosition.x)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("LeftToTop/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("TopToLeft/Area2D").GlobalPosition;
                
            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition - new Vector2(distAroundCorner * (float) (Math.Sin(angle)), 
                    distAroundCorner * (float) (1 + Math.Cos(angle))));
            }
            train.AddWaypoint(finalPosition);
        }
    }
    public void TopToLeft(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.y > train.waypointQueue.Peek().y) return;

        GD.Print("Top to Left");

        if (train.GlobalPosition.y < GlobalPosition.y)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("TopToLeft/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("LeftToTop/Area2D").GlobalPosition;
                
            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition - new Vector2(distAroundCorner * (float) (1 + Math.Cos(angle)), 
                    distAroundCorner * (float) Math.Sin(angle)));
            }
            train.AddWaypoint(finalPosition);
        }
    }
    public void RightToBottom(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.x < train.waypointQueue.Peek().x) return;

        GD.Print("Right to Bottom");

        if (train.GlobalPosition.x > GlobalPosition.x)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("RightToBottom/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("BottomToRight/Area2D").GlobalPosition;
                
            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition + new Vector2(distAroundCorner * (float) (Math.Sin(angle)), 
                    distAroundCorner * (float) (1 + Math.Cos(angle))));
            }
            train.AddWaypoint(finalPosition);
        }
    }

    public void BottomToRight(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.y < train.waypointQueue.Peek().y) return;

        GD.Print("Bottom to Right");

        if (train.GlobalPosition.y > GlobalPosition.y)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("BottomToRight/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("RightToBottom/Area2D").GlobalPosition;

            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition + new Vector2(distAroundCorner * (float) (1 + Math.Cos(angle)), 
                    distAroundCorner * (float) Math.Sin(angle)));
            }
            train.AddWaypoint(finalPosition);
        }
    }

    public void RightToTop(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.x < train.waypointQueue.Peek().x) return;

        GD.Print("Right to Top");

        if (train.GlobalPosition.x > GlobalPosition.x)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("RightToTop/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("TopToRight/Area2D").GlobalPosition;
                
            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition + new Vector2(distAroundCorner * (float) (Math.Sin(angle)), 
                    -distAroundCorner * (float) (1 + Math.Cos(angle))));
            }
            train.AddWaypoint(finalPosition);
        }
    }
    public void TopToRight(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        Carriage train = trainArea.GetParent<Carriage>();
        if (train.waypointQueue.Count > 0 && train.lastWaypoint.y > train.waypointQueue.Peek().y) return;

        GD.Print("Top to Right");

        if (train.GlobalPosition.y < GlobalPosition.y)
        {
            ResetWaypointAdding(waypointDelay);
            Vector2 initialPosition = GetNode<Area2D>("TopToRight/Area2D").GlobalPosition;
            Vector2 finalPosition = GetNode<Area2D>("RightToTop/Area2D").GlobalPosition;
                
            for (int i = 1; i < smoothness; i++)
            {
                double angle = Math.PI + i * Math.PI / 2 / smoothness;
                train.AddWaypoint(initialPosition + new Vector2(distAroundCorner * (float) (1 + Math.Cos(angle)), 
                    -distAroundCorner * (float) Math.Sin(angle)));
            }
            train.AddWaypoint(finalPosition);
        }
    }

    public void OnCrash(Area2D trainArea)
    {
        //We prevent this from calling multiple simultaneous Game Overs in the GameManager scripts
        if (trainArea.Name == "WaypointCollider")
        {
            GD.Print("crash");
            GD.Print(this.Name);
            gameManager.IsGameOver = true;
        }
    }
    
    //This method exists to attempt and prevent the train from turning around whenever it contacts to waypoints
    //at once
    private async void ResetWaypointAdding(float time)
    {
        await ToSignal(GetTree().CreateTimer(time), "timeout");
    }
}
