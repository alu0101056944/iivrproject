/// Marcos Barrios
/// II ULL
/// 05_02_2022
/// Teleport to the position the player is looking at when a key is pressed.
///
/// Can only teleport if a valid gameobject collides with player's raycast.
///

using UnityEngine;

public class TeleportToRaycastPosition : MonoBehaviour {

  [SerializeField]
  private GameObject gameObjectToTeleport;

  [SerializeField]
  private GameObject teleportPositionEffect;

  [SerializeField]
  private string keyToHoldForTeleportMode = "joystick button 5"; // InputManager defined

  [SerializeField]
  private string keyForTeleportActivate = "joystick button 0"; // botón x en PS3

  [SerializeField]
  private string allowTeleportGameObjectTag = "Floor";

  // Just in case the game object to teleport needs to be higher, to avoid
  // gliching through the soil.
  [SerializeField]
  private float extraYPositionWhenTeleporting = 0f;

  private Vector3 teleportPosition;

  private bool validTeleport = false;

  void Awake() {
    PlayerRaycast.RaycastCollisionEvent += setTeleportPosition;
  }

  void Start() {
    teleportPosition = gameObjectToTeleport.transform.position;
  }

  void OnDestroy() {
    PlayerRaycast.RaycastCollisionEvent -= setTeleportPosition;
  }

  // Only see teleport location effect when pressing the key
  void Update() {
    if (Input.GetKey(keyToHoldForTeleportMode) && validTeleport) {
      teleportPositionEffect.SetActive(true);
      teleportPositionEffect.transform.position = teleportPosition;
      if (Input.GetButtonDown(keyForTeleportActivate)) {
        Vector3 newPosition = teleportPosition;
        newPosition.y += extraYPositionWhenTeleporting;
        gameObjectToTeleport.transform.position = newPosition;
        validTeleport = false;
      }
    } else  {
      teleportPositionEffect.SetActive(false);
    }
  }

  private void setTeleportPosition(RaycastHit raycastHit) {
    if (raycastHit.collider.gameObject.tag == allowTeleportGameObjectTag) {
      teleportPosition = raycastHit.point;
      validTeleport = true;
    } else { // When non valid teleport
      validTeleport = false;
    }
  }

}
