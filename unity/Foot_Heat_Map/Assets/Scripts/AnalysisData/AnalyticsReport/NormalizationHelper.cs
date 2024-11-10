using System.Collections.Generic;
using UnityEngine;

public static class NormalizationHelper
{
  public static List<float> NormalizeData(List<ushort> sensorData, ushort min, ushort max)
  {
    List<float> normalizedData = new List<float>();
    foreach (var value in sensorData)
    {
      float normalizedValue = (float)(value - min) / (max - min);
      normalizedData.Add(Mathf.Clamp(normalizedValue, 0f, 1f)); // Ensure the data stays between 0 and 1
    }
    return normalizedData;
  }
}
