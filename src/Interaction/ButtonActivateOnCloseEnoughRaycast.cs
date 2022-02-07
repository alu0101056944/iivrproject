/// Marcos Barrios
/// II ULL
/// 06_02_2022
///
/// Any interactionable that activates when a gameobject is close enough and it
/// is hit by PlayerRaycast raycast.
///

using UnityEngine;

public class ButtonActivateOnCloseEnoughRaycast : MonoBehaviour {

  public delegate void ButtonActivationDelegate();
  public event ButtonActivationDelegate ButtonActivationEvent;

  [SerializeField]
  private GameObject interactor;

  [SerializeField]
  private float distanceToAllowInteraction = 5f;

  [SerializeField]
  private string keyToPressForActivation = "joystick button 0";

  private bool allowInteraction = false;

  private RaycastHit raycastHitFromPlayer;

  void Awake() {
    PlayerRaycast.RaycastCollisionEvent += setAllowInteraction;
  }

  void OnDestroy() {
    PlayerRaycast.RaycastCollisionEvent -= setAllowInteraction;
  }

  void Update() {
    if (allowInteraction) {
      float distanceToInteractor = 
          Vector3.Distance(interactor.transform.position, transform.position);
      if (distanceToInteractor < distanceToAllowInteraction &&
            Input.GetKey(keyToPressForActivation)) {
        if (ButtonActivationEvent != null) {
          ButtonActivationEvent();
        }
      }
    }
  }

  private void setAllowInteraction(RaycastHit raycastHit) {
    if (raycastHit.collider.gameObject.name == gameObject.name) {
      allowInteraction = true;
    } else {
      allowInteraction = false;
    }
  }
}
