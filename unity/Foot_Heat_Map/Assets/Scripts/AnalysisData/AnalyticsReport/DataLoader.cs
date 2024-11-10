using System;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
  public DataReader dataReader; // Reference to the DataReader

  private List<float> leftSensorData = new List<float>();
  private List<float> rightSensorData = new List<float>();

  // Load sensor data and normalize it
  public void LoadSensorData()
  {

    List<ushort> rawLeftData = dataReader.GetLeftSensorData();

    List<ushort> rawRightData = dataReader.GetRightSensorData();





    leftSensorData = NormalizeData(rawLeftData);
    rightSensorData = NormalizeData(rawRightData);
    Debug.Log("LoadSensorData completed sucessfully.");

  }

  // Get normalized left sensor data
  public List<float> GetLeftSensorData()
  {
    if (leftSensorData.Count == 0)
      LoadSensorData(); // Ensure data is loaded and normalized
    return leftSensorData;
  }

  // Get normalized right sensor data
  public List<float> GetRightSensorData()
  {
    if (rightSensorData.Count == 0)
      LoadSensorData(); // Ensure data is loaded and normalized
    return rightSensorData;
  }

  // Normalize the data to a range of 0 to 1
  private List<float> NormalizeData(List<ushort> rawData)
  {
    List<float> normalizedData = new List<float>();
    float maxValue = ushort.MaxValue;

    foreach (ushort value in rawData)
    {
      normalizedData.Add(value / maxValue);
    }

    return normalizedData;
  }

  //internal BalanceMatData GetFrameData() => throw new NotImplementedException();
  public BalanceMatData GetFrameData()
  {
    BalanceMatData frameData = new BalanceMatData();

    // Ensure there's enough data in the lists to populate the fields
    if (leftSensorData.Count >= 13 && rightSensorData.Count >= 5)
    {
      // Assign left sensor values
      frameData.leftSensor0 = (ushort)(leftSensorData[0] * ushort.MaxValue);
      frameData.leftSensor1 = (ushort)(leftSensorData[1] * ushort.MaxValue);
      frameData.leftSensor2 = (ushort)(leftSensorData[2] * ushort.MaxValue);
      frameData.leftSensor3 = (ushort)(leftSensorData[3] * ushort.MaxValue);
      frameData.leftSensor4 = (ushort)(leftSensorData[4] * ushort.MaxValue);
      frameData.leftSensor5 = (ushort)(leftSensorData[5] * ushort.MaxValue);
      frameData.leftSensor6 = (ushort)(leftSensorData[6] * ushort.MaxValue);
      frameData.leftSensor7 = (ushort)(leftSensorData[7] * ushort.MaxValue);
      frameData.leftSensor8 = (ushort)(leftSensorData[8] * ushort.MaxValue);
      frameData.leftSensor9 = (ushort)(leftSensorData[9] * ushort.MaxValue);
      frameData.leftSensor10 = (ushort)(leftSensorData[10] * ushort.MaxValue);
      frameData.leftSensor11 = (ushort)(leftSensorData[11] * ushort.MaxValue);
      frameData.leftSensor12 = (ushort)(leftSensorData[12] * ushort.MaxValue);

      // Assign right sensor values
      frameData.rightSensor0 = (ushort)(rightSensorData[0] * ushort.MaxValue);
      frameData.rightSensor1 = (ushort)(rightSensorData[1] * ushort.MaxValue);
      frameData.rightSensor2 = (ushort)(rightSensorData[2] * ushort.MaxValue);
      frameData.rightSensor3 = (ushort)(rightSensorData[3] * ushort.MaxValue);
      frameData.rightSensor4 = (ushort)(rightSensorData[4] * ushort.MaxValue);
    }
    else
    {
      Debug.LogWarning("Not enough sensor data to populate BalanceMatData.");
    }

    // Set a timestamp for the frame if needed
    frameData.TimeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

    Debug.Log("GetFrameData completed successfully.");
    return frameData;
  }
  
}
