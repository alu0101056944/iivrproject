/// Marcos Barrios
/// Interfaces Inteligentes
///
/// Grab any GrabableGameObject using PlayerRaycast.
///
using UnityEngine;

public class GrabGameObjectOnKeyPress : MonoBehaviour {

  [SerializeField]
  private GameObject grabPosition;

  [SerializeField]
  private string keyToPress = "joystick button 0";

  [SerializeField]  
  private string nameOfLayerOfGrabbedGO = "GrabbedByPlayer";

  /// Distance the player has to be at to be able to push
  [SerializeField]
  private float grabEnableThreshold = 5f;

  // To be able to call the grab event
  private GrabableGameObject grabableController;

  private GameObject grabbedGameObject;
  private int indexOfPreviousLayer = 0; // to avoid colision with player using layers.

  private bool keyPressed = false;
  private bool canBeGrabbed = false;

  void Awake() {
    PlayerRaycast.RaycastCollisionEvent += enableGrab;
  }

  void FixedUpdate() {
    float distanceToPlayer = Vector3.Distance(gameObject.transform.position, transform.position);
    if (grabbedGameObject != null) {
      if (keyPressed && canBeGrabbed && distanceToPlayer < grabEnableThreshold) {
        grabbedGameObject.GetComponent<GrabableGameObject>().grab();
        grabbedGameObject.layer = LayerMask.NameToLayer(nameOfLayerOfGrabbedGO);
        Rigidbody rb_ = grabbedGameObject.GetComponent<Rigidbody>();
        rb_.MovePosition(grabPosition.transform.position);
        rb_.useGravity = false;
        keyPressed = false;
      } else {
        Rigidbody rb_ = grabbedGameObject.GetComponent<Rigidbody>();
        rb_.useGravity = true;
        grabbedGameObject.layer = indexOfPreviousLayer;
      }
    }
  }

  void Update() {
    if (Input.GetKey(keyToPress)) {
      keyPressed = true;
    }
  }

  void OnDestroy() {
    PlayerRaycast.RaycastCollisionEvent -= enableGrab;
  }

  private void enableGrab(RaycastHit raycastedHit) {
    GrabableGameObject ggo =
        raycastedHit.collider.gameObject.GetComponent<GrabableGameObject>();
    if (ggo != null) {
      if (raycastedHit.collider.gameObject != grabbedGameObject) {
        grabbedGameObject = raycastedHit.collider.gameObject;
        indexOfPreviousLayer = grabbedGameObject.layer;
      }
      canBeGrabbed = true;
    } else {
      grabbedGameObject = null;
      keyPressed = false;
      canBeGrabbed = false;
    }
  }

}
