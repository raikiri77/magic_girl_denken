using UnityEngine;
using System.Collections.Generic;

public class LifeManager : MonoBehaviour{
    [SerializeField]private GameObject[] lifeArray = new GameObject[3];       //gameオブジェクトの紐付け
    private int lifepoint = 3;         //ライフポイントを3にする

    void Update(){
        if (Input.GetMouseButtonDown(0) && lifepoint<3){
            lifepoint++;
            lifeArray[lifepoint-1].SetActive(true);
        }

        else if (Input.GetMouseButtonDown(1) && lifepoint>0){
            lifeArray[lifepoint-1].SetActive(false);
            lifepoint--;
        }
    }
    
}
