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
    
    public override void _Ready()
    {
        waypointQueueWithEndAngle = new Queue<Tuple<Vector2, float>>();
        lastWaypoint = this.Position;
        LastTouchedTile = new Node2D();
    }

    public override void _Process(float delta)
    {
        MoveToWaypoint(delta);
    }

    // Figure out whether we're going straight or curvy and call the corresponding function
    private void MoveToWaypoint(float delta) {
        if (waypointQueueWithEndAngle.Count == 0) return; // No waypoints in queue, so do nothing.

        Vector2 nextWaypoint = waypointQueueWithEndAngle.Peek().Item1;
        float nextWayPointEndAngle = waypointQueueWithEndAngle.Peek().Item2; // This is either 1, 0 or -1 representing right, straight and left respectively
        
        if (AreFloatsCloseEnough(nextWayPointEndAngle, this.GlobalRotationDegrees, 1f))
        {
            GD.Print("Expected Rotation: " + nextWayPointEndAngle);
            GD.Print("Current Rotation: " + this.GlobalRotationDegrees);
            GD.Print("Continuing at current rotation\n\n");
            MoveToWaypointStraight(delta, nextWaypoint);
        } else 
        {
            MoveToWaypointCurve(delta, nextWaypoint, nextWayPointEndAngle);
        }

    }
    
    private void MoveToWaypointStraight(float delta, Vector2 nextWaypoint)
    {
        GD.Print("GOING STRAIGHT!");
        this.Position = Lerp(lastWaypoint, nextWaypoint, delta); 
        if (IsDistanceSmallEnough(this.Position, nextWaypoint, displacementEpsilon)) 
        {
            lastWaypoint = nextWaypoint;
            waypointQueueWithEndAngle.Dequeue();
        }
    }

    private void MoveToWaypointCurve(float delta, Vector2 nextWaypoint, float nextWayPointEndAngle) 
    {
        if (IsDistanceSmallEnough(this.Position, lastWaypoint, displacementEpsilon)) 
        {
            this.GlobalRotationDegrees = (this.GlobalRotationDegrees + nextWayPointEndAngle) / 2;
        }
        
        this.Position = Lerp(lastWaypoint, nextWaypoint, delta); 
        if (IsDistanceSmallEnough(this.Position, nextWaypoint, displacementEpsilon))
        {
            lastWaypoint = nextWaypoint;
            waypointQueueWithEndAngle.Dequeue();
            this.GlobalRotationDegrees = nextWayPointEndAngle;
        }
    }

    public void AddWaypoint(Vector2 newPosition, float nextWaypointEndAngle)
    { 
        GD.Print(("AddWaypoint input angle: " + nextWaypointEndAngle));
        waypointQueueWithEndAngle.Enqueue(new Tuple<Vector2, float>(newPosition, nextWaypointEndAngle)); 
        foreach (var waypoint in waypointQueueWithEndAngle)
        {
            GD.Print(waypoint);    
        }
    }

    private Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float delta)
    {
        Vector2 direction = firstVector.DirectionTo(secondVector);
        Vector2 movement = direction * TrainSpeed * delta;
        return this.Position + movement;
    }

    private bool IsDistanceSmallEnough(Vector2 a, Vector2 b, float epsilon)
    {
        Vector2 displacement = (a - b).Abs();
        return displacement.x < displacementEpsilon && displacement.y < displacementEpsilon;
    }

    private bool AreFloatsCloseEnough(float a, float b, float epsilon)
    {
        //GD.Print("A: " + a + "| B: " + b);
        if (a > b) return a - b < epsilon;
        if (a < b) return b - a < epsilon;
        return true; // If a < b and a > b are both false, then a == b
    }
}
