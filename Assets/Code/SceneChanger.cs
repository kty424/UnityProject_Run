using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{

    public int targetSceneNum; // 이동하고 싶은 대상의 씬 넘버


    public void SceneChange() // 씬넘버를 이용해 씬 이동
    {
        SceneManager.LoadScene(targetSceneNum);
    }

}
