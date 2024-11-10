using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootHeatMapController : MonoBehaviour
{
  // Link these fields to the appropriate Image objects in the Inspector
  public Image FrontLeft;
  public Image MidFrontLeft;
  public Image MiddleLeft;
  public Image MidHeelLeft;
  public Image HeelLeft;

  public Image FrontRight;
  public Image MidFrontRight;
  public Image MiddleRight;
  public Image MidHeelRight;
  public Image HeelRight;

  // Method to update heat map colors based on normalized sensor data
  public void UpdateHeatMap(List<float> leftFootData, List<float> rightFootData)
  {
    // Apply color to each region for the left foot
    ApplyHeatColor(FrontLeft, leftFootData[0]);
    ApplyHeatColor(MidFrontLeft, leftFootData[1]);
    ApplyHeatColor(MiddleLeft, leftFootData[2]);
    ApplyHeatColor(MidHeelLeft, leftFootData[3]);
    ApplyHeatColor(HeelLeft, leftFootData[4]);

    // Apply color to each region for the right foot
    ApplyHeatColor(FrontRight, rightFootData[0]);
    ApplyHeatColor(MidFrontRight, rightFootData[1]);
    ApplyHeatColor(MiddleRight, rightFootData[2]);
    ApplyHeatColor(MidHeelRight, rightFootData[3]);
    ApplyHeatColor(HeelRight, rightFootData[4]);
  }

  // Helper method to set the color based on intensity
  private void ApplyHeatColor(Image region, float intensity)
  {
    // Convert intensity (0.0 - 1.0) to a color gradient, e.g., from blue to red
    region.color = Color.Lerp(Color.blue, Color.red, intensity);
  }
}
