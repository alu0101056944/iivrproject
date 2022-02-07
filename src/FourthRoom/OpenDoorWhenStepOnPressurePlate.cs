/// Marcos Barrios
/// II ULL
/// 06_02_2022
///
/// Disable door when pressure plate is stepped on.
///

using UnityEngine;

public class OpenDoorWhenStepOnPressurePlate : MonoBehaviour {

  [SerializeField]
  private GameObject pressurePlate;

  private ContainerOfGameObjects cof;

  void Awake() {
    PressurePlateWithEvent ppwe = pressurePlate.GetComponent<PressurePlateWithEvent>();
    ppwe.PressurePlateActivatedEvent += disableDoor;
    ppwe.PressurePlateDeactivatedEvent += enableDoor;
  }

  void OnDestroy() {
    PressurePlateWithEvent ppwe = pressurePlate.GetComponent<PressurePlateWithEvent>();
    ppwe.PressurePlateActivatedEvent -= disableDoor;
    ppwe.PressurePlateDeactivatedEvent -= enableDoor;
  }

  private void disableDoor() {
    gameObject.SetActive(false);
  }

  private void enableDoor() {
    gameObject.SetActive(true);
  }
}
