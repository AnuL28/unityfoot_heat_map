using UnityEngine;

public static class MathUtilities
{
  // Calculates the angle in the XY plane
  public static float CalculateAngleXY(Vector3 pointA, Vector3 pointB, Vector3 pointC)
  {
    Vector3 directionToA = new Vector3(pointA.x - pointB.x, pointA.y - pointB.y, 0).normalized;
    Vector3 directionToC = new Vector3(pointC.x - pointB.x, pointC.y - pointB.y, 0).normalized;
    return Vector3.Angle(directionToA, directionToC);
  }

  // Calculates the angle in the YZ plane
  public static float CalculateAngleYZ(Vector3 pointA, Vector3 pointB, Vector3 pointC)
  {
    Vector3 directionToA = new Vector3(0, pointA.y - pointB.y, pointA.z - pointB.z).normalized;
    Vector3 directionToC = new Vector3(0, pointC.y - pointB.y, pointC.z - pointB.z).normalized;
    return Vector3.Angle(directionToA, directionToC);
  }

  // Calculates the angle in the XZ plane
  public static float CalculateAngleXZ(Vector3 pointA, Vector3 pointB, Vector3 pointC)
  {
    Vector3 directionToA = new Vector3(pointA.x - pointB.x, 0, pointA.z - pointB.z).normalized;
    Vector3 directionToC = new Vector3(pointC.x - pointB.x, 0, pointC.z - pointB.z).normalized;
    return Vector3.Angle(directionToA, directionToC);
  }

  // General method for calculating the angle in 3D space
  public static float CalculateAngle(Vector3 pointA, Vector3 pointB, Vector3 pointC)
  {
    Vector3 directionToA = (pointA - pointB).normalized;
    Vector3 directionToC = (pointC - pointB).normalized;
    return Vector3.Angle(directionToA, directionToC);
  }

  // Calculates the distance between two points in 3D space
  public static float CalculateDistance(Vector3 pointA, Vector3 pointB)
  {
    return Vector3.Distance(pointA, pointB);
  }

  // Calculates the distance between two points in 2D space
  public static float CalculateDistance(Vector2 pointA, Vector2 pointB)
  {
    return Vector2.Distance(pointA, pointB);
  }
}
