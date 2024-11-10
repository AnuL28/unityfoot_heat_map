using System.Collections.Generic;
using UnityEngine;

public class GaitAnalysisProcessor : MonoBehaviour
{
  public DataLoader dataLoader;
  private ushort minPressure = 0;
  private ushort maxPressure = 1000; // Adjust this based on your observed data range.

  private void Start()
  {
    if (dataLoader == null)
    {
      dataLoader = GetComponent<DataLoader>();
    }
  }

  public (List<float> leftFootNormalized, List<float> rightFootNormalized) ProcessFootData()
  {
    BalanceMatData frameData = dataLoader.GetFrameData();

    // Normalize left foot sensor data
    List<float> leftFootNormalized = NormalizationHelper.NormalizeData(
        frameData.GetLeftSensorData(), minPressure, maxPressure
    );

    // Normalize right foot sensor data
    List<float> rightFootNormalized = NormalizationHelper.NormalizeData(
        frameData.GetRightSensorData(), minPressure, maxPressure
    );

    return (leftFootNormalized, rightFootNormalized);
  }
}
