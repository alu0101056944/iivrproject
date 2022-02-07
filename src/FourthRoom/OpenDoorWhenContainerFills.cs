/// Marcos Barrios
/// II ULL
/// 06_02_2022
///
/// Disable this game object to simulate door opening.
///

using UnityEngine;

public class OpenDoorWhenContainerFills : MonoBehaviour {

  [SerializeField]
  private GameObject container;

  private ContainerOfGameObjects cof;

  void Awake() {
    ContainerOfGameObjects cof = container.GetComponent<ContainerOfGameObjects>();
    cof.ContainerFullEvent += disableDoor;
  }

  void OnDestroy() {
    ContainerOfGameObjects cof = container.GetComponent<ContainerOfGameObjects>();
    cof.ContainerFullEvent -= disableDoor;
  }

  private void disableDoor() {
    gameObject.SetActive(false);
  }
}
