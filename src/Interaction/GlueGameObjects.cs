//
// Marcos Barrios
// ULL II
// 04_02_2022
// Stick any GameObject that collides with this GameObject's collider. Uses
// physics forces for the movement, so it needs a GameObject with rigidbody as platform.
//
// Unglue when the glued GameObject indirectly calls UnglueEvent. Can't glue again until
// some specified seconds have passed.
//

using UnityEngine;

public class GlueGameObjects : MonoBehaviour {
  /// Platform where the glue is on.
  [SerializeField]
  private GameObject platform;

  [SerializeField]
  private float secondsBetweenGlues = 2f;

  private float timeSinceLastGlued = 0f;
  private Collider colliderOfGlued = null;
  private float oldMass = 0;
  private bool glued = false;
  private bool hasJustUngluedSomething = false;

  void OnDestroy() {
    if (colliderOfGlued != null) {
      GluableGameObject gluableGO =
          colliderOfGlued.gameObject.GetComponent<GluableGameObject>();
      if (gluableGO != null) {
        gluableGO.UnglueEvent -= unglue;
      }
    }
  }

  void FixedUpdate() {
    if (glued) {
      colliderOfGlued.gameObject.transform.position = transform.position;
      Rigidbody rigidbody_ = colliderOfGlued.gameObject.GetComponent<Rigidbody>();
      rigidbody_.MovePosition(platform.transform.position);
      rigidbody_.velocity = platform.GetComponent<Rigidbody>().velocity;
    }
  }

  void Update() {
    if (hasJustUngluedSomething) {
      timeSinceLastGlued += Time.deltaTime;
      if (timeSinceLastGlued >= secondsBetweenGlues) {
        hasJustUngluedSomething = false;
        glued = false;
      }
    }
  }

  public void OnTriggerEnter(Collider other) {
    if (!glued && !hasJustUngluedSomething) {
      GluableGameObject gluableGO =
          other.gameObject.GetComponent<GluableGameObject>();
      if (gluableGO != null) {
        Rigidbody rigidBody_ = other.gameObject.GetComponent<Rigidbody>();
        oldMass = rigidBody_.mass;
        rigidBody_.mass = 0;
        gluableGO.UnglueEvent += unglue;
        colliderOfGlued = other;
        glued = true;
      }
    }
  }

  public void OnTriggerExit(Collider other) {
    if (glued) {
      Rigidbody rigidBody_ = colliderOfGlued.GetComponent<Rigidbody>();
      rigidBody_.mass = oldMass;
      GluableGameObject gluableGO =
          colliderOfGlued.gameObject.GetComponent<GluableGameObject>();
      gluableGO.UnglueEvent -= unglue;
      hasJustUngluedSomething = true;
    }
  }

  public void unglue() {
    Rigidbody rigidBody_ = colliderOfGlued.gameObject.GetComponent<Rigidbody>();
    rigidBody_.mass = oldMass;
    glued = false;
  }
}
