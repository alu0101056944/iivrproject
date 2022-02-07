///
/// Marcos Barrios
/// 02_02_2022
/// ULL II Ing Inf.
///

using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToOtherScene : MonoBehaviour {

  [SerializeField]
  private string sceneName = "";

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "Player") {
      SceneManager.LoadScene(sceneName); // 0 = first room, 1 = second room, ...
    }
  }
}
