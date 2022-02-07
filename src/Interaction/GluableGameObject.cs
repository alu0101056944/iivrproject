/// Marcos Barrios
/// II ULL
/// 04_02_2022
/// Has an event that is called by the platform that has the gameobject glued.
///
/// The platform script assumes the gameobject has this script as component and
/// it is subscribed to it. When the glued gameobject calls unglue() the platform
/// receives the event and unglues the gameobject.
///
using UnityEngine;

public class GluableGameObject : MonoBehaviour {
  public delegate void UnglueDelegate();
  public event UnglueDelegate UnglueEvent;

  public void unglue() {
    if (UnglueEvent != null) {
      UnglueEvent();
    }
  }
}
