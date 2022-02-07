/// Marcos Barrios
/// Interfaces Inteligentes
/// Práctica GPS, Brújula y Acelerómetro
/// Attempt to throw a GameObject forward by chance.

using UnityEngine;

public class GameObjectThrower : MonoBehaviour {

  [SerializeField] // allow changes from editor
  private float chanceOfSpawnEachSecond = 0.3f;

  [SerializeField]
  private float forceToApplyOnBallSpawn = 200f;

  [SerializeField]
  private GameObject gameobjectToInstanceSpawn;

  /// Because an empty child object's position is used for the throw direction
  [SerializeField]
  private GameObject throwDirectionGameObject;

  [SerializeField]
  private Vector3 throwDirection = new Vector3(0,-1,0);

  [SerializeField]
  private float secondsBetweenSpawn = 2f;

  private float secondsSinceLastSpawn = 0f;
  private bool hasJustSpawned = false;

  void Start() {
    GetComponent<ButtonActivateOnCloseEnoughRaycast>()
        .ButtonActivationEvent += allowSpawn;
    
  }

  void OnDestroy() {
    GetComponent<ButtonActivateOnCloseEnoughRaycast>()
        .ButtonActivationEvent -= allowSpawn;
  }

  void Update() {
    if (hasJustSpawned) {
      secondsSinceLastSpawn += Time.deltaTime;
      if(secondsSinceLastSpawn >= secondsBetweenSpawn) {
        secondsSinceLastSpawn = 0f;
        hasJustSpawned = false;
      }
    }
  }

  private void allowSpawn() {
    if (!hasJustSpawned) {
      var spawnedBall =
          Instantiate(gameobjectToInstanceSpawn, throwDirectionGameObject.transform.position, Quaternion.identity);
      var rigidBodyOfBall = spawnedBall.GetComponent<Rigidbody>();
      rigidBodyOfBall.AddForce(throwDirection * forceToApplyOnBallSpawn);
      hasJustSpawned = true;
    }
  }
}
