/**
 * Marcos Barrios
 * Interfaces Inteligentes
 * 
 * Push the gameobject away when a key is pressed.
 */

using UnityEngine;

public class PushOnKeyPressed : MonoBehaviour {

  /// To be accessed by the platform with the glue, allows ungluing.
  /// This GameObject needs to unglue when pushed.
  private GluableGameObject glueController;

  [SerializeField]
  private string keyToPress = "joystick button 0";

  [SerializeField]
  private float pushStrength = 200f;

  /// Distance the player has to be at to be able to push
  [SerializeField]
  private float pushEnableThreshold = 6f;

  private Transform playerTransform;
  private Rigidbody rigidBody;

  private bool keyPressed = false;
  private bool canBePushed = false;
  private float timeSinceKeyPressed = 0f;
  private float secondsBetweenKeyPress = 1f;
  private bool hasJustPressed = false;

  void Awake() {
    PlayerRaycast.RaycastCollisionEvent += enablePush;
  }

  void Start() {
    playerTransform = GameObject.FindWithTag("Player").transform;
    rigidBody = GetComponent<Rigidbody>();
    glueController = GetComponent<GluableGameObject>();
  }

  // Push away from the player
  void FixedUpdate() {
    float distanceToPlayer =
        Vector3.Distance(playerTransform.position, transform.position);
   if (keyPressed && canBePushed && distanceToPlayer < pushEnableThreshold) {
      glueController.unglue();
      Vector3 pushVector =
          (transform.position - playerTransform.position).normalized;
      rigidBody.AddForce(pushVector * pushStrength);
      keyPressed = false;
    }
  }

  /// Because Inputs don't work well on FixedUpdate()
  void Update() {
    if (hasJustPressed) {
      timeSinceKeyPressed += Time.deltaTime;
      if(timeSinceKeyPressed >= secondsBetweenKeyPress) {
        hasJustPressed = false;
      }
    }
    if (Input.GetKey(keyToPress) && !hasJustPressed) {
      keyPressed = true;
      hasJustPressed = true;
    }
  }

  void OnDestroy() {
    PlayerRaycast.RaycastCollisionEvent -= enablePush;
  }

  private void enablePush(RaycastHit raycastedHit) {
    if (raycastedHit.collider.name == gameObject.name) {
      canBePushed = true;
    } else {
      keyPressed = false;
      canBePushed = false;
    }
  }

}
