/// Marcos Barrios
/// II ULL
/// 06_02_2022
///
/// Disable door when all objects have been found and destroyed after interaction.
///

using UnityEngine;

public class OpenDoorWhenGameObjectsCleared : MonoBehaviour {
  
  [SerializeField]
  private GameObject door;

  [SerializeField]
  private GameObject[] instancesToClear;

  private int instancesFound = 0;

  [SerializeField]
  private GameObject textGameObject;

  void Start() {
    for (var i = 0; i < instancesToClear.Length; i++) {
      DestroyGameObjectOnPress dgoop = instancesToClear[i].GetComponent<DestroyGameObjectOnPress>();
      dgoop.GameObjectDestroyedEvent += increaseCounter;
    }
    textGameObject.GetComponent<TextMesh>().text = "" + instancesToClear.Length;
  }

  void Awake() {
    for (var i = 0; i < instancesToClear.Length; i++) {
      DestroyGameObjectOnPress dgoop = instancesToClear[i].GetComponent<DestroyGameObjectOnPress>();
      dgoop.GameObjectDestroyedEvent -= increaseCounter;
    }
  }

  void Update() {
    if (instancesFound == instancesToClear.Length) {
      Destroy(gameObject);
    }
  }

  private void increaseCounter() {
    instancesFound++;
    textGameObject.GetComponent<TextMesh>().text =
        "" + (instancesToClear.Length - instancesFound);
  }

}
