using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutScene : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> cutScenes = new List<GameObject>();
    int scenesNum = 0;

    private void Start()
    {
        scenesNum = 0;
        cutSceneChange();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(scenesNum + 1 < cutScenes.Count) 
            {
                scenesNum += 1;
                cutSceneChange();
            }
        }
    }

    void cutSceneChange()
    {
        for(int i = 0; i < cutScenes.Count;  i++)
        {
            cutScenes[i].SetActive(false);
        }
        cutScenes[scenesNum].SetActive(true);
    }


}
