using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorld : MonoBehaviour {

    public GameObject Lvl;      //Создаю список всех обьектор// 
    public GameObject Ship;	//***************************//
    public GameObject Saw;	//***************************//
    public GameObject Fire;	//***************************//
    public GameObject Lava;	//***************************//
   
    int NowSpawm;		  //Место появления объекта
    int _PosNowX = 0;		  //Текущее место
    int last = 0;		  //Запись номера последнего объекта
    void Start () { NowSpawm = 1;}//Место появления первого объекта
    void Update () {
        Lvl.transform.localScale = new Vector2(100 + transform.position.x*10, Lvl.transform.localScale.y); //Удленяет уровень(пол и потолок ) делая его немного впереди игрока
        if (transform.position.x > 30)
            _PosNowX = Mathf.FloorToInt(transform.position.x - 30); // Расчет текущего положения 
        if (_PosNowX == NowSpawm)                  //если текущее положение равно положению предпологаемого места появления 
            CreateWorldSpawner();	 	   //Вызываем метод создания случайного объекта с некоторыми усключениями
    }

    void CreateWorldSpawner() {
            switch (Random.Range(0, 7))        //создает случайное число от 0 до количества элементов -1
            {
                case 0: //шипы на полу 
                   Instantiate(Ship, new Vector2(transform.position.x + NowSpawm, -9.85f), Quaternion.Euler(0,0,180));//Установка объекта в нужную позицию
                last = 0;
                break;
                case 1: //шипы на потолке 
                   Instantiate(Ship, new Vector2(transform.position.x + NowSpawm, -7.66f), Quaternion.Euler(0, 0, 0));
                last = 1;
                break;
                case 2: //огонь 
                   Instantiate(Fire, new Vector2(transform.position.x + NowSpawm, -10), Quaternion.Euler(0, 0, 0));
                last = 2;
                break;
                case 3: //лава 
                   Instantiate(Lava, new Vector2(transform.position.x + NowSpawm, -7.79f), Quaternion.Euler(0, 0, 0));
                last = 3;
                break;
                case 4: //пила на полу
                if(last == 1 || last == 5 || last ==6)   //проверка последнего установленного объекта есои он один из списка не разрешаем ставить этот объект (по мнению тестеров в этом случае уровень невозможно пройти
                    return;
                Instantiate(Saw, new Vector2(transform.position.x + NowSpawm, -10), Quaternion.Euler(0, 0, 90));
                last = 4;
                break;
                case 5: //пила на поперек
                    Instantiate(Saw, new Vector2(transform.position.x + NowSpawm, -7), Quaternion.Euler(0, 0, 0));
                last = 5;
                break;
                case 6: //пила по центу
                if (last == 4 || last == 1)
                    return;
                   Instantiate(Saw, new Vector2(transform.position.x + NowSpawm, -6.82f), Quaternion.Euler(0, 0, 90));
                    
                last = 6;
                break;
                      
            }
            NowSpawm += 6;                //Растояние между объктами
            return;
    }
}
