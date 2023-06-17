using UnityEngine;

namespace CarsControl {
  public class CarsControl3 : MonoBehaviour  {
        // Start is called before the first frame update
        public float speed;
        void Start() {
      // Методом Application.targetFrameRate = мы задаем сколько у нас кадров в секунду в игре
      
     // Application.targetFrameRate = 2;

      //Application.targetFrameRate = 60;
    }

    // Метод Update выполняется каждую секунду столько раз, столько кадров успел отрисовать компьютер за секунду
    void Update() {
      // Столько кадров успел отрисовать компьютер за секунду мы переместим наш игровой обьект на координату, но при этом мы уровняем наше перемещение домножив на Time.deltaTime
      // в результате у нас игровой обьект будет перемещаться за секунду на заданые координаты в direction
      Vector3 direction = new Vector3(0, 0, speed);
      // Time.deltaTime время между кадрами (чем больше кадров, тем меньше времени между кадрами)
      transform.Translate(direction * Time.deltaTime);
    }
  }
}