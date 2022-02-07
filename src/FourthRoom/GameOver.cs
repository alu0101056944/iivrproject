/// Marcos Barrios
/// II ULL
/// 06_02_2022
///
/// Gameover only when last room's puzzle couldn't be solved in time.
///

using UnityEngine;

public class GameOver : MonoBehaviour {

  public delegate void GameOverDelegate();
  public static event GameOverDelegate GameOverEvent;

  private static GameObject counter;

  [SerializeField]
  private GameObject counter_temp;

  private static float secondsUntilGameOver = 10f;

  [SerializeField]
  private float secondsUntilGameOver_temp = 10f;

  private static float secondsSinceStart = 0f;

  private static bool start = false;

  void Start() {
    counter = counter_temp; // Because static fields dont show up on editor.
    secondsUntilGameOver = secondsUntilGameOver_temp;
  }

  public static void startGameOver() {
    counter.GetComponent<TextMesh>().text = "0";
    secondsSinceStart = 0f; // in case it has already been started, act as reset.
    start = true;
    GameOverEvent();
  }

  public static void stopGameOver() {
    counter.GetComponent<TextMesh>().text = "0";
    secondsSinceStart = 0f;
    start = false;
    GameOverEvent();
  }

  void Update() {
    if (start) {
      secondsSinceStart += Time.deltaTime;
      counter.GetComponent<TextMesh>().text = secondsSinceStart.ToString();
      if (secondsSinceStart >= secondsUntilGameOver) {
        if (GameOverEvent != null) GameOverEvent();
        stopGameOver();
      }
    }
  }

}
