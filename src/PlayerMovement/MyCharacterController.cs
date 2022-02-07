/**
 * Marcos Barrios
 * Interfaces Inteligentes
 *
 * Move the game object using the wsad and/or arrows and rotate on OY axis using
 * the mouse. Movement and rotation speeds can be modified on Unity's interface.
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour {

  public float traslationSpeed = 2f;
  public float rotationSpeed = 20f;

  private Rigidbody rigidbody_;

  void Start() {
    rigidbody_ = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    float traslationDistance = Time.fixedDeltaTime * traslationSpeed;
    Vector3 movementDirection =
        new Vector3(Input.GetAxis("LeftJoystickX"), 0, Input.GetAxis("LeftJoystickY"));
    Vector3 newPosition = rigidbody_.position +
        transform.TransformDirection(movementDirection * traslationDistance);
    
    rigidbody_.MovePosition(newPosition);
  }

}