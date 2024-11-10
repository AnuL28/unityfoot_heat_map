using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FootHeatMap : MonoBehaviour
{
  public DataLoader dataLoader;

  void Start()
  {
    // Get normalized sensor data for left and right foot
    List<float> leftFootData = dataLoader.GetLeftSensorData();
    List<float> rightFootData = dataLoader.GetRightSensorData();

    // Generate heat map for each foot
    GenerateHeatMap(leftFootData, "Left");
    GenerateHeatMap(rightFootData, "Right");
  }

  public void GenerateHeatMap(List<float> normalizedData, string foot)
  {
    if (normalizedData.Count != 13)
    {
      Debug.LogError($"{foot} foot data should contain exactly 13 sensor points, but got {normalizedData.Count}");
      return;
    }

    // Divide data into regions (3-2-3-2-3) and apply color/intensity based on values
    ApplyHeatToRegions(normalizedData.GetRange(0, 3), $"{foot}Front");
    ApplyHeatToRegions(normalizedData.GetRange(3, 2), $"{foot}MidFront");
    ApplyHeatToRegions(normalizedData.GetRange(5, 3), $"{foot}Middle");
    ApplyHeatToRegions(normalizedData.GetRange(8, 2), $"{foot}MidHeel");
    ApplyHeatToRegions(normalizedData.GetRange(10, 3), $"{foot}Heel");
  }

  private void ApplyHeatToRegions(List<float> regionSensors, string regionName)
  {
    // Calculate average intensity for the region
    float intensity = regionSensors.Average();
    Debug.Log($"{regionName} - Intensity: {intensity}");
  }

  internal void GenerateHeatMap() => throw new NotImplementedException();
}
