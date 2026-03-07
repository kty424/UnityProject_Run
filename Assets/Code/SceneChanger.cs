using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{

    public int targetSceneNum;


    public void SceneChange()
    {
        SceneManager.LoadScene(targetSceneNum);
    }

}
