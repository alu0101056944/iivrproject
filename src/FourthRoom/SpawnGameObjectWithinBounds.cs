/// Marcos Barrios
/// Interfaces Inteligentes
///
/// Spawn objects within a Bounds Object area.
///

using UnityEngine;

public class SpawnGameObjectWithinBounds : MonoBehaviour {

  private GameObject[] gameObjectsToSpawn;
  private GameObject[] instantiatedGameObjects;
  private Bounds spawnArea;

  void Awake() {
    GameOver.GameOverEvent += destroyAll;
  }

  // Start is called before the first frame update
  void Start() {
    spawnArea = gameObject.GetComponent<BoxCollider>().bounds;
    gameObjectsToSpawn = GameObject.FindGameObjectsWithTag("Spawnable");
    instantiatedGameObjects = new GameObject[gameObjectsToSpawn.Length];
  }

  void OnDestroy() {
    GameOver.GameOverEvent -= destroyAll;
  }

  /// Game of keywords needs to respawn objects.
  public void spawnAndDestroy() {
    for (int i = 0; i < gameObjectsToSpawn.Length; i++) {
      if (instantiatedGameObjects[i] != null) {
        Destroy(instantiatedGameObjects[i]);
      }
      float xWithinSpawn = Random.Range(spawnArea.min.x, spawnArea.max.x);
      float zWithinSpawn = Random.Range(spawnArea.min.z, spawnArea.max.z);
      Vector3 randomPosWithinSpawn =
          new Vector3(xWithinSpawn, spawnArea.center.y, zWithinSpawn);
      float randomYRotation = Random.Range(-360, 360);
      gameObjectsToSpawn[i].transform.Rotate(Vector3.up * randomYRotation);
      instantiatedGameObjects[i] = 
          Instantiate(gameObjectsToSpawn[i], randomPosWithinSpawn,
              Quaternion.identity);
    }
  }

  private void destroyAll() {
    for (int i = 0; i < instantiatedGameObjects.Length; i++) {
      Destroy(instantiatedGameObjects[i]);
    }
  }

}
