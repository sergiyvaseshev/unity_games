using UnityEngine;

namespace CarsControl {
  public class CarsControl2 : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
           




        }

    // Метод Update выполняется каждую секунду столько раз, столько кадров успел отрисовать компьютер за секунду 
    void Update() {
      // Столько кадров успел отрисовать компьютер за секунду Столько раз мы переместим наш игровой обьект на координату dir
      Vector3 direction = new Vector3(0, 0, 1f);

      transform.Translate(direction);
    }
  }
}