/// Marcos Barrios
/// Interfaces Inteligentes

///
/// Raycast from camera view, call event when it colides with something. Meant
/// for knowing what the player is looking at.
///
using UnityEngine;

public class PlayerRaycast : MonoBehaviour {

  public delegate void RaycastCollisionDelegate(RaycastHit raycastHit);
  public static event RaycastCollisionDelegate RaycastCollisionEvent;

  [SerializeField]
  private GameObject[] gameObjectsToIgnore;

  [SerializeField]
  private float raycastDistance = 5f;

  /// Draw raycast from camera direction to know what the player is looking at.
  void FixedUpdate() {
    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
    Debug.DrawRay(transform.position, ray.direction * raycastDistance);
    RaycastHit rayHit; /// to get info of the ray
    if (Physics.Raycast(ray, out rayHit /* it's a reference */)) {
      if(RaycastCollisionEvent != null && !ignoredIsRaycasted(rayHit)) {
        RaycastCollisionEvent(rayHit);
      }
    }
  }

  private bool ignoredIsRaycasted(RaycastHit raycastHit) {
    for (int i = 0; i < gameObjectsToIgnore.Length; i++) {
      Collider temp = gameObjectsToIgnore[i].GetComponent<Collider>();
      if (temp != null && temp == raycastHit.collider) {
        return true;
      }
    }
    return false;
  }

}
