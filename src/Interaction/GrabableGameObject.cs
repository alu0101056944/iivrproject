/// Marcos Barrios
/// Interfaces Inteligentes
///
/// Any GameObject that has this script represents a GO that can be grabbed.
/// It allows other game objects to know when it has been grabbed.
///
using UnityEngine;

public class GrabableGameObject : MonoBehaviour {
  public delegate void GrabbedDelegate();
  public event GrabbedDelegate GrabbedEvent;

  public void grab() {
    if (GrabbedEvent != null) {
      GrabbedEvent();
    }
  }

}
