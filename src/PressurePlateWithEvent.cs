///
/// Marcos Barrios
/// 02_02_2022
/// ULL II Ing Inf.
///

using UnityEngine;

public class PressurePlateWithEvent : MonoBehaviour {
  public delegate void PressurePlateDelegate();
  public event PressurePlateDelegate PressurePlateActivatedEvent;
  public event PressurePlateDelegate PressurePlateDeactivatedEvent;

  private float originalYScale = 0f;

  void Start() {
    originalYScale = transform.localScale.y;
  }

  private void activate() {
    Vector3 newScale = transform.localScale;
    newScale.y = newScale.y / 2;
    transform.localScale = newScale;
  }

  private void deactivate() {
    Vector3 newScale = transform.localScale;
    newScale.y = originalYScale;
    transform.localScale = newScale;
  }

  public void OnCollisionEnter(Collision collision) {
    activate();
    if (PressurePlateActivatedEvent != null) {
      PressurePlateActivatedEvent();
    }
  }

  void OnCollisionExit(Collision collision) {
    deactivate();
    if (PressurePlateActivatedEvent != null) {
      PressurePlateDeactivatedEvent();
    }
  }

}
