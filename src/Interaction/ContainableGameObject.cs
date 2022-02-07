/// Marcos Barrios
/// II ULL
/// 05_02_2022
///
/// ANy GameObject with this script can be contained on a fill hooker GameObject
///

using UnityEngine;

public class ContainableGameObject : MonoBehaviour {

  [SerializeField]
  private GameObject container;

  public void contain() {
    container.GetComponent<ContainerOfGameObjects>().insertGameObject(gameObject);
  }
}
