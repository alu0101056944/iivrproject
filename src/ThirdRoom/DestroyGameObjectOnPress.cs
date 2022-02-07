/// Marcos Barrios
/// II ULL
/// 06_02_2022
///
/// Destroy a GameObject when raycast player and low enough distance and key
/// press.
///

using UnityEngine;

public class DestroyGameObjectOnPress : MonoBehaviour {

  public delegate void GameObjectDestroyedDelegate();
  public event GameObjectDestroyedDelegate GameObjectDestroyedEvent;

  void Start() {
    ButtonActivateOnCloseEnoughRaycast baoce = GetComponent<ButtonActivateOnCloseEnoughRaycast>();
    baoce.ButtonActivationEvent += destroy;
  }

  void Awake() {
    ButtonActivateOnCloseEnoughRaycast baoce = GetComponent<ButtonActivateOnCloseEnoughRaycast>();
    baoce.ButtonActivationEvent -= destroy;
  }

  private void destroy() {
    if (GameObjectDestroyedEvent != null) {
      GameObjectDestroyedEvent();
    }
    Destroy(gameObject);
  }
  
}
