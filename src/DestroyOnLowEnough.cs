/// Marcos Barrios
/// Interfaces Inteligentes
///
/// Destroy any GameObject that is falling to the void.
///
using UnityEngine;

public class DestroyOnLowEnough : MonoBehaviour {
  [SerializeField]
  private GameObject destructor;
  
  public void OnTriggerEnter(Collider collider) {
    Destroy(collider.gameObject);
  }
}
