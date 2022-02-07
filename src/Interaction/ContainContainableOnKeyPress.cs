/// Marcos Barrios
/// Interfaces Inteligentes
///
/// Send a GameObject to a container when then player is looking at it and
/// a key is pressed at enough distance.
///
/// GameObject needs to have ContainableGameObject script attached.
///

using UnityEngine;

public class ContainContainableOnKeyPress : MonoBehaviour {

  void Start() {
    GetComponent<ButtonActivateOnCloseEnoughRaycast>()
        .ButtonActivationEvent += sendToContainer;
  }

  void OnDestroy() {
    GetComponent<ButtonActivateOnCloseEnoughRaycast>()
        .ButtonActivationEvent -= sendToContainer;
  }

  private void sendToContainer() {
    gameObject.GetComponent<ContainableGameObject>().contain();
  }

}
