using UnityEngine;

namespace CarsControl {
  public class CarsControl1 : MonoBehaviour{
    // Метод Start выполниться один раз при старте
    void Start() {
      // direction в переводе направление
      Vector3 direction = new Vector3(0, 0, 10);

      
      // Методом transform.Translate мы указываем какие координаты нужно прибавить к игровому обьекту (на котором висит наш скрипт CarsControl1)
      transform.Translate(direction);
    }

    // Update is called once per frame
    void Update() {
      
      
      
      
    }
  }
}