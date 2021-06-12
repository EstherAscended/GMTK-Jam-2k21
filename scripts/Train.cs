using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Train : Sprite
{
    [Export]
    public float TrainSpeed = 1;

    private Queue<Vector2> waypointQueue;
    public Vector2 lastWaypoint;
    private float displacementEpsilon = 1f;
    public Node2D LastTouchedTile;
    public Node2D SecondLastTouchedTile;
    public List<Resources> HeldGoods;
    
    public override void _Ready()
    {
        waypointQueue = new Queue<Vector2>();
        lastWaypoint = this.Position;
        LastTouchedTile = new Node2D();
        SecondLastTouchedTile = new Node2D();
        HeldGoods = new List<Resources>();
    }

    public override void _Process(float delta)
    {
        MoveToWaypoint(delta);
    }

    // Figure out whether we're going straight or curvy and call the corresponding function
    private void MoveToWaypoint(float delta) 
    {
        if (waypointQueue.Count == 0) return; // No waypoints in queue, so do nothing.
        
        Vector2 nextWaypoint = waypointQueue.Peek();
        Vector2 direction = this.GlobalPosition.DirectionTo(nextWaypoint);
        double angle = Math.Atan2(direction.y, direction.x);
        this.GlobalRotation = (float) angle;

        this.Position = Lerp(lastWaypoint, nextWaypoint, delta); 
        if (IsDistanceSmallEnough(this.Position, nextWaypoint, displacementEpsilon))
        {
            this.Position = nextWaypoint;
            lastWaypoint = nextWaypoint;
            GD.Print("==========");
            foreach (Vector2 waypoint in waypointQueue)
            {
                GD.Print(waypoint);
            }
            GD.Print("==========");
            waypointQueue.Dequeue();
        }
    }

    public void AddWaypoint(Vector2 newPosition)
    { 
        waypointQueue.Enqueue(newPosition);
    }

    private Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float delta)
    {
        Vector2 direction = firstVector.DirectionTo(secondVector);
        Vector2 movement = direction * TrainSpeed * delta;
        return this.Position + movement;
    }

    private bool IsDistanceSmallEnough(Vector2 a, Vector2 b, float epsilon)
    {
        return a.DistanceSquaredTo(b) < epsilon;
    }

    private bool AreFloatsCloseEnough(float a, float b, float epsilon)
    {
        return Math.Abs(b - a) < epsilon;
    }
}
