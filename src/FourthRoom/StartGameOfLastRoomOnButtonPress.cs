/// Marcos Barrios
/// II ULL
/// 06_02_2022
///
/// Start game of last room; activate gameover and spawn capsules with
/// the objects that need to be contained to open the door.
///

using UnityEngine;

public class StartGameOfLastRoomOnButtonPress : MonoBehaviour {

  [SerializeField]
  private GameObject capsuleSpawner;

  void Start() {
    GetComponent<ButtonActivateOnCloseEnoughRaycast>()
        .ButtonActivationEvent += gameOver;
  }

  void OnDestroy() {
    GetComponent<ButtonActivateOnCloseEnoughRaycast>()
        .ButtonActivationEvent -= gameOver;
  }

  public void gameOver() {
    GameOver.startGameOver();
    capsuleSpawner.GetComponent<SpawnGameObjectWithinBounds>().spawnAndDestroy();
  }
}
