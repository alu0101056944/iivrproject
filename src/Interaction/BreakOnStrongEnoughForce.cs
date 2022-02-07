/// Marcos Barrios
/// II ULL
/// 05_02_2022
/// Break (destroy) this object once enough force has been applied to it's
/// collider.
///

using UnityEngine;

public class BreakOnStrongEnoughForce : MonoBehaviour {

  [SerializeField]
  private float breakForceThreshold = 1f;

  [SerializeField]
  private string tagOfBreakerGameObjects = "Breaker";

  void OnCollisionEnter(Collision collision) {
    if (collision.relativeVelocity.magnitude > breakForceThreshold) {
      if (collision.gameObject.tag == tagOfBreakerGameObjects) {
        Destroy(gameObject);
      }
    }
  }

}
