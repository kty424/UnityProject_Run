using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{
    // cutscenes리스트에 컷씬을 넣으면 클식시 자동으로 다음 컷씬으로 넘어가는 코드

    public List<GameObject> cutScenes = new List<GameObject>(); // 화면에 띄울 컷씬들
    int scenesNum = 0; // 컷씬을 넘기기 위한 컷씬 번호

    public int targetSceneNum; // 컷씬이 끝나고 넘어 갈 씬의 넘버


    private void Start()
    {
        scenesNum = 0;
        cutSceneChange();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) // 마우스 클릭을 입력받을시 SceneNum 증가 및 컷씬 변경
        {
            if(scenesNum + 1 < cutScenes.Count) 
            {
                scenesNum += 1;
                cutSceneChange();

            }
            else  { SceneManager.LoadScene(targetSceneNum); }// 씬넘버를 이용해 씬 이동
        }
    }
    /// <summary>
    /// cutScenes 리스트의 scenesNum 번째의 씬을 표시
    /// <para>
    /// 씬 전체를 끄고 대상의 씬 하나를 키는 방식으로 동작
    /// </para>
    /// </summary>
    void cutSceneChange()
    {
        for(int i = 0; i < cutScenes.Count;  i++)
        {
            cutScenes[i].SetActive(false);// 전체 컷씬 비활성화
        }
        cutScenes[scenesNum].SetActive(true);//sceneNum번째 컷씬을 활성화
    }

  
}
