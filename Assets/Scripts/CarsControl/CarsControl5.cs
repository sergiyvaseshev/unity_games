using UnityEngine;

namespace CarsControl {
  public class CarsControl5 : MonoBehaviour  {
    // Start is called before the first frame update
    void Start() {
      
      
      
      
      
    }

    // Метод Update выполняется каждую секунду столько раз, столько кадров успел отрисовать компьютер за секунду
    void Update() {
      
      // Input переводиться как ввод, берем у нашего компьютера ввод стрелок ←, → с клавиатуры он равняется значениям -1 влево | 0 отстутствие нажатия | 1 вправо
      var horizontalInput = Input.GetAxis("Horizontal");
      
      // теперь мы домножаем наше значение ввода на наше значение перемещения
      Vector3 direction = new Vector3(0, 0, horizontalInput * 10);
      
      // когда двигаемся влево у нас каждую секунду значение будет убавляться на значение -10
      // когда стоим на месте у нас каждую секунду значение будет становиться  
      // когда двигаемся вправо у нас каждую секунду значение будет прибавляться на значение 10 
      
      transform.Translate(direction * Time.deltaTime);
    }
  }
}