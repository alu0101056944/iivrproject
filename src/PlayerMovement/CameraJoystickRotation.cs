using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJoystickRotation : MonoBehaviour {
  
  private float mouseX = 0f;
  private float mouseY = 0f;

  void FixedUpdate() {
    mouseX += Input.GetAxis("RightJoystickX") * 5;
    mouseY -= Input.GetAxis("RightJoystickY") * 2.4f;
    // mouseY = Mathf.Clamp(mouseY, -85, 85);
    transform.localRotation = Quaternion.Euler(mouseX, mouseY, 0);
  }
  
}
