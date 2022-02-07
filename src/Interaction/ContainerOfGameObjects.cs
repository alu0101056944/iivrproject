/// Marcos Barrios
/// II ULL
/// 05_02_2022
///
/// Fill game object hooker and keep count of the gameobjects it contains.
///

using UnityEngine;

public class ContainerOfGameObjects : MonoBehaviour {
  
  public delegate void ContainerFullDelegate();
  public event ContainerFullDelegate ContainerFullEvent;

  [SerializeField]
  private Transform positionOfInsertion;

  [SerializeField]
  private int maxAmountOfContainedGameObjects = 5;

  private int amountOfContainedGameObjects = 0;

  void Awake() {
    GameOver.GameOverEvent += reset;
  }

  void OnDestroy() {
    GameOver.GameOverEvent -= reset;
  }

  private void reset() {
    amountOfContainedGameObjects = 0;
  }

  void Update() {
    if (amountOfContainedGameObjects >= maxAmountOfContainedGameObjects){
      if (ContainerFullEvent != null) ContainerFullEvent();
    }
  }
  public void insertGameObject(GameObject gameObject) {
    if (amountOfContainedGameObjects < maxAmountOfContainedGameObjects) {
      gameObject.transform.position = positionOfInsertion.position;
      amountOfContainedGameObjects++;
    }
  }

}
