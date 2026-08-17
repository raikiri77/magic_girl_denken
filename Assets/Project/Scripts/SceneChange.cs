using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //これ必須です

public class Scene: MonoBehaviour {
    

    public void SceneChange()
    {
        SceneManager.LoadScene("stage1");
    }

}
