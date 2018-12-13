using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateWay
{
    class CalculateWay
    {

        static void Main(string[] args)
        {
            Point3D startPoint  = new Point3D ( 0, 0, 0 );
            Point3D endPoint = new Point3D(100, 200, 800);

            Bird newBird = new Bird();
            Plane newPlane = new Plane();
            SpaceShip newSpaceShip = new SpaceShip();

            Console.WriteLine(newBird.WhoAmI() + ": " + newBird.FlyTo(startPoint.Coordinates, endPoint.Coordinates) + ", " + newBird.GetFlyTime(startPoint.Coordinates, endPoint.Coordinates) + "km/hour");
            Console.WriteLine(newPlane.WhoAmI() + ": " + newPlane.FlyTo(startPoint.Coordinates, endPoint.Coordinates) + ", " + newPlane.GetFlyTime(startPoint.Coordinates, endPoint.Coordinates) + "km/hour");
            Console.WriteLine(newSpaceShip.WhoAmI() + ": " + newSpaceShip.FlyTo(startPoint.Coordinates, endPoint.Coordinates) + ", " + newSpaceShip.GetFlyTime(startPoint.Coordinates, endPoint.Coordinates) + "km/hour");
            Console.ReadLine();
        }
    }

    public struct Point3D
    {
        public int[] Coordinates { get; }

        public Point3D (int x, int y, int z)
        {
            int[] Coordinates = new int[] { x, y, z };
        }
    }

    class CalcDistance
    {
        public double Distance (int[] startPoint, int[] endPoint)
        {
            double distance = 0;
            for (int i = 0; i < startPoint.Length; i++)
            { distance = distance + (Math.Pow((endPoint[i] - startPoint[i]), 2)); }
            distance = Math.Sqrt(distance);

            return distance;
        }
    }

    interface IFlyable
    {
        double FlyTo(int[] Point, int[] newPoint);

        string WhoAmI();

        double GetFlyTime(int[] Point, int[] newPoint);

    }


    class Bird : IFlyable
    {
        public double FlyTo(int[] startPoint, int[] endPoint)
        {
            CalcDistance calcDist = new CalcDistance();
            return calcDist.Distance(startPoint, endPoint);
        }

        public string WhoAmI()
        {
            return "bird";
        }

        public double GetFlyTime(int[] Point, int[] newPoint)
        {
            Random birdSpeed = new Random();
            return birdSpeed.Next(0, 20);
        }
    }

    class Plane : IFlyable
    {
        public double FlyTo(int[] startPoint, int[] endPoint)
        {
            CalcDistance calcDist = new CalcDistance();
            return calcDist.Distance(startPoint, endPoint);
        }

        public string WhoAmI()
        {
            return "plane";
        }

        public double GetFlyTime(int[] startPoint, int[] endPoint)
        {
            double distance = FlyTo(startPoint, endPoint);
            double speedChange = 10;
            double planeSpeed = 200;

            double distCoef = distance/10;
            for (int i = 0; i < distCoef; i++)
            {
                planeSpeed = planeSpeed + speedChange;
            }

            return planeSpeed;
        }
    }

    class SpaceShip : IFlyable
    {
        public double FlyTo(int[] startPoint, int[] endPoint)
        {
            CalcDistance calcDist = new CalcDistance();
            return calcDist.Distance(startPoint, endPoint);
        }

        public string WhoAmI()
        {
            return "spaceship";
        }

        public double GetFlyTime(int[] Point, int[] newPoint)
        {
            double spaceShipSpeed = 28800000;
            return spaceShipSpeed;
        }
    }
}