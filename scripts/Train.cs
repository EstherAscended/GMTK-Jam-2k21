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
    
    public override void _Ready()
    {
        waypointQueue = new Queue<Vector2>();
        lastWaypoint = this.Position;
        LastTouchedTile = new Node2D();
    }

    public override void _Process(float delta)
    {
        MoveToWaypoint(delta);
    }

    private void MoveToWaypoint(float delta)
    {
        if (waypointQueue.Count > 0)
        {
            this.Position = weeMove(lastWaypoint, waypointQueue.Peek(), delta); 
            Vector2 displacement = (this.Position - waypointQueue.Peek()).Abs();
            if (displacement.x < displacementEpsilon && displacement.y < displacementEpsilon)
            {
                lastWaypoint = waypointQueue.Dequeue();
            }
        }
    }

    public void AddWaypoint(Vector2 newPosition)
    {
       waypointQueue.Enqueue(newPosition);
       foreach (var waypoint in waypointQueue)
       {
            GD.Print(waypoint);    
       }
    }

    private Vector2 weeMove(Vector2 firstVector, Vector2 secondVector, float delta)
    {
        Vector2 direction = firstVector.DirectionTo(secondVector);
        Vector2 movement = direction * TrainSpeed * delta;
        return this.Position + movement;
    }
}
