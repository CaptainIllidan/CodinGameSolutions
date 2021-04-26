using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
public class Point{
    public int X {get;set;}
    public int Y {get;set;}
    public Point NextTarget {get;set;}
    public Point NextPoint {get;set;}

    public Point(int x, int y)
    {
        X=x;
        Y=y;
    }

    public bool IsEqual(Point p){
        return X==p.X && Y==p.Y;
    }
}

public class Pod
{
    public int X {get;set;}
    public int Y {get;set;}
    public int VX {get;set;}
    public int VY {get;set;}
    public int Angle {get;set;}
    public int NextCheckPointId {get;set;}
    public bool IsEnemy {get;set;}
    public bool IsBoostAvailable {get;set;}
    public Point TargetPoint {get;set;}

    public Pod (int x, int y, int vx, int vy, int angle, int nextCheckpointId, bool isBoostAvailable, bool isEnemy=false)
    {
        X=x;
        Y=y;
        VX=vx;
        VY=vy;
        Angle=angle;
        NextCheckPointId=nextCheckpointId;
        IsBoostAvailable = isBoostAvailable;
        IsEnemy=isEnemy;
    }

    private int GetAngle(Point p1, Point p2)
    {
        return (int)(Math.Atan2(p1.Y - p2.Y, p1.X - p2.X) / Math.PI * 180);
    }

    private int GetDistance(Point p1, Point p2)
    {
        return (int)Math.Sqrt(Math.Pow(p2.X-p1.X,2)+Math.Pow(p2.Y-p1.Y,2));
    }

    public string GetNextAction()
    {
        var podPoint = new Point(X,Y);
        var angle = GetAngle(podPoint, TargetPoint);
        var absAngle = Math.Abs((angle - Angle) % 180);
        Console.Error.WriteLine("Angle: "+angle);
        var dist = GetDistance(podPoint, TargetPoint);
        var thrust = 100;
        if (absAngle > 90)
            if (dist < 3000)
                thrust -=dist / 100;
             else
                 thrust =0;

        if (dist < 1500)
            thrust -= dist / 50;
        
        var action = dist > 7000 && absAngle < 30 && IsBoostAvailable ? "BOOST" : Math.Max(thrust,0).ToString();
        
        return $"{TargetPoint.X} {TargetPoint.Y} {action}"; 
    }
}

class Player
{
    static private void SetNextTargetPoint(Point point, Point nextPoint)
    {
        var targetX = nextPoint.X;
        if (point.X < nextPoint.X)
            targetX-=400;
        else
            targetX+=400;

        var targetY = nextPoint.Y;
        if (point.Y < nextPoint.Y)
            targetY-=400;
        else
            targetY+=400;
        
        point.NextTarget = new Point(targetX,targetY);
    }

    static private Pod ReadPodData(string[] inputs, bool isBoostAvailable, bool isEnemy = false)
    {
        int x = int.Parse(inputs[0]);
        int y = int.Parse(inputs[1]);
        int vx = int.Parse(inputs[2]); // x position of the next check point
        int vy = int.Parse(inputs[3]); // y position of the next check point
        int angle = int.Parse(inputs[4]); // distance to the next checkpoint
        int nextCheckpointId = int.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
        return new Pod(x,y,vx,vy,angle,nextCheckpointId, isBoostAvailable,isEnemy);
    }

    static void Main(string[] args)
    {
        string[] inputs;
        bool isBoostUsed = false;
        var podsCount = 2;
        var enemyPodsCount = 2;
        var pods = new List<Pod>();
        var enemyPods = new List<Pod>();
        var boostsAvailableForPod = new List<bool>();
        boostsAvailableForPod.Add(true);
        boostsAvailableForPod.Add(true);

        var knowalablePoints = new List<Point>();

        var lapsCount = int.Parse(Console.ReadLine());
        var checkpointsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i< checkpointsCount; i++){
            var checkPointCoordinates = Console.ReadLine().Split(' ');
            var point = new Point(int.Parse(checkPointCoordinates[0]),int.Parse(checkPointCoordinates[1]));
            knowalablePoints.Add(point);
        }

        for (int j = 0; j<knowalablePoints.Count-1; j++)
        {
            SetNextTargetPoint(knowalablePoints[j], knowalablePoints[j+1]);
        }
        SetNextTargetPoint(knowalablePoints[knowalablePoints.Count()-1], knowalablePoints[0]);

        // game loop
        while (true)
        {
            pods.Clear();
            enemyPods.Clear();

            for (int i = 0; i < podsCount; i++)
                pods.Add(ReadPodData(Console.ReadLine().Split(' '), boostsAvailableForPod[i]));

            for (int i = 0; i < enemyPodsCount; i++)
                enemyPods.Add(ReadPodData(Console.ReadLine().Split(' '), false, true));

            for (int j = 0; j < podsCount; j++)
            {
                var podTargetIndex = pods[j].NextCheckPointId == 0 
                    ? knowalablePoints.Count - 1 
                    : pods[j].NextCheckPointId - 1;
                pods[j].TargetPoint = knowalablePoints[podTargetIndex].NextTarget;
            }


            // You have to output the target position
            // followed by the power (0 <= thrust <= 100)
            // i.e.: "x y thrust"

            // if (Math.Abs(nextCheckpointX - x) > 2000){
            //     if (opponentX>nextCheckpointX)
            //         nextCheckpointX+=Math.Min(nextCheckpointDist / 3,400);
            //     else
            //         nextCheckpointX-= Math.Min(nextCheckpointDist / 3, 400);
            // }

            // if (Math.Abs(opponentY-nextCheckpointY) > 2000){
            //     if (opponentY>nextCheckpointY)
            //         nextCheckpointY+=Math.Min(nextCheckpointDist / 3, 400);
            //     else
            //         nextCheckpointY-=Math.Min(nextCheckpointDist / 3, 400);
            // }

            //Console.Error.WriteLine("Knowalable points count: " + knowalablePoints.Count);

            for (int i = 0; i < podsCount; i++){
                var output = pods[i].GetNextAction();
                if (output.Contains("BOOST"))
                    boostsAvailableForPod[i] = false;
                Console.WriteLine(output);
            }

            //Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + action);
        }
    }
}