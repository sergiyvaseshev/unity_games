using UnityEngine;

namespace CarsControl {
  public class CarsControl4 : MonoBehaviour  {
    // Start is called before the first frame update
    void Start() {
      // Методом Application.targetFrameRate = мы задаем сколько у нас кадров в секунду в игре
      
      //Application.targetFrameRate = 3;

      //Application.targetFrameRate = 60;
    }

    // Метод Update выполняется каждую секунду столько раз, столько кадров успел отрисовать компьютер за секунду
    void Update() {
      
      // Игровое время от 1f секунды до 2f, игра будет работать 1 секунду 
      if(Time.time > 1f && Time.time < 2f) {

        Vector3 direction = new Vector3(0, 0, 10);

        transform.Translate(direction * Time.deltaTime);
      }
    }
  }
}