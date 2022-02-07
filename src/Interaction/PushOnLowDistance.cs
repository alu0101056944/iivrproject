/**
 * Marcos Barrios
 * Interfaces Inteligentes
 * 
 * Push the gameobject away from the player when closer than the specified
 * distance.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnLowDistance : MonoBehaviour {

  public float pushStrength = 5f;
  public float thresholdDistance = 5;

  private Transform playerTransform;
  private Rigidbody rigidBody;

  void Start() {
    playerTransform = GameObject.FindWithTag("Player").transform;
    rigidBody = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    float distance = Vector3.Distance(playerTransform.position, transform.position);
    if (distance < thresholdDistance) {
      rigidBody.isKinematic = false;
      Vector3 pushVector = transform.position - playerTransform.position;
      Vector3 pushDirection = Vector3.Normalize(pushVector);
      rigidBody.AddForce(pushDirection * pushStrength);
    }
  }
}
