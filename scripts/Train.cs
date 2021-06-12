using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Train : Sprite
{
    [Export]
    public float TrainSpeed = 1;

    private Queue<Tuple<Vector2, float>> waypointQueueWithEndAngle;
    public Vector2 lastWaypoint;
    private float displacementEpsilon = 1f;
    public Node2D LastTouchedTile;
    public Node2D SecondLastTouchedTile;
    
    public override void _Ready()
    {
        waypointQueueWithEndAngle = new Queue<Tuple<Vector2, float>>();
        lastWaypoint = this.Position;
        LastTouchedTile = new Node2D();
        SecondLastTouchedTile = new Node2D();
    }

    public override void _Process(float delta)
    {
        MoveToWaypoint(delta);
    }

    // Figure out whether we're going straight or curvy and call the corresponding function
    private void MoveToWaypoint(float delta) 
    {
        if (waypointQueueWithEndAngle.Count == 0) return; // No waypoints in queue, so do nothing.
        
        Vector2 nextWaypoint = waypointQueueWithEndAngle.Peek().Item1;
        Vector2 direction = this.GlobalPosition.DirectionTo(nextWaypoint);
        double angle = Math.Atan2(direction.y, direction.x);
        this.GlobalRotation = (float) angle;

        this.Position = Lerp(lastWaypoint, nextWaypoint, delta); 
        if (IsDistanceSmallEnough(this.Position, nextWaypoint, displacementEpsilon))
        {
            this.Position = nextWaypoint;
            lastWaypoint = nextWaypoint;
            waypointQueueWithEndAngle.Dequeue();
        }
    }
    
    // private bool MoveToWaypointStraight(float delta, Vector2 nextWaypoint)
    // {
    //     this.Position = Lerp(lastWaypoint, nextWaypoint, delta); 
    //     if (IsDistanceSmallEnough(this.Position, nextWaypoint, displacementEpsilon))
    //     {
    //         this.Position = nextWaypoint;
    //         lastWaypoint = nextWaypoint;
    //         waypointQueueWithEndAngle.Dequeue();
    //         return true; // We did reach the next waypoint
    //     }
    //     return false; // We didn't reach the next waypoint
    // }
    //
    // private bool MoveToWaypointCurve(float delta, Vector2 nextWaypoint, float nextWayPointEndAngle) 
    // {
    //     this.Position = Lerp(lastWaypoint, nextWaypoint, delta); 
    //     if (IsDistanceSmallEnough(this.Position, nextWaypoint, displacementEpsilon))
    //     {
    //         this.Position = nextWaypoint;
    //         lastWaypoint = nextWaypoint;
    //         waypointQueueWithEndAngle.Dequeue();
    //         this.GlobalRotationDegrees = nextWayPointEndAngle;
    //         return true; // We did reach the next waypoint
    //     }
    //     return false; // We didn't reach the next waypoint
    // }

    public void AddWaypoint(Vector2 newPosition, float nextWaypointEndAngle)
    { 
        waypointQueueWithEndAngle.Enqueue(new Tuple<Vector2, float>(newPosition, nextWaypointEndAngle));
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
