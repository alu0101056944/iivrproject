///
/// Marcos Barrios
/// II ULL 
/// 04_02_2022
/// Moves platform from initial position towards final position on a loop.
/// Movement is always straight line.
/// Instead of searching children with name, it is required to select the
/// final and initial positions on the editor.
///
/// Platform needs to be at a valid position; between the initial and final
/// position.
///
/// Needs to be on the platform and it needs to have a rigid body.
///

using UnityEngine;

public class MoveRailPlatform : MonoBehaviour {

  [SerializeField]
  private GameObject finalPositionGameObject;
  [SerializeField]
  private GameObject initialPositionGameObject;
  [SerializeField]
  private GameObject platformGameObject;

  /// Because physics rather than direct transform.
  [SerializeField]
  private float forceOfMovement = 10f;

  /// To check when platform needs to change direction
  [SerializeField]
  private float directionAlternationThreshold = 0.1f;

  private Vector3 nextPosition;

  void Start() {
    nextPosition = finalPositionGameObject.transform.position;
  }

  /// Calculate next position then move towards it.
  void FixedUpdate() {
    Vector3 platformPosition = platformGameObject.transform.position;
    Vector3 initialPosition = initialPositionGameObject.transform.position;
    Vector3 finalPosition = finalPositionGameObject.transform.position;
    
    float distanceToNextPosition = Vector3.Distance(platformPosition, nextPosition);
    if (distanceToNextPosition <= directionAlternationThreshold) {
      if (nextPosition == initialPosition) {
        nextPosition = finalPosition;
      } else {
        nextPosition = initialPosition;
      }
    }

    Vector3 direction = (nextPosition - platformPosition).normalized;
    Rigidbody rigidbody_ = platformGameObject.GetComponent<Rigidbody>();
    rigidbody_.velocity = direction * forceOfMovement;
  }

}
