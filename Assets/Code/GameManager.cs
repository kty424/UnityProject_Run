
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]public static GameManager Instance;

    [Header("Stage1")] public List<GameObject> stage1Maps; //스테이지 1 맵
    [Header("Stage2")] public List<GameObject> stage2Maps; //스테이지 2 맵
    [Header("Stage3")] public List<GameObject> stage3Maps; //스테이지 3 맵

    enum Stage { stage1,stage2,stage3};
    Stage currentStage;

    //맵 하나의 길이를 50이라 상정
    const int mapWith = 50;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentStage = Stage.stage1;
    }

    //점수, 전수에 따라 맵 변환







    public void MapConnect(Vector3 posistion)
    {
        int randomIndex;
        //다음에 맵을 연결할곳의 위치
        posistion += Vector3.right * mapWith * 3;
        switch (currentStage)
        {
            case Stage.stage1:
                randomIndex = Random.Range(0, stage1Maps.Count);
                Instantiate(stage1Maps[randomIndex],posistion,Quaternion.identity);
                break;
            case Stage.stage2:
                randomIndex = Random.Range(0, stage2Maps.Count);
                Instantiate(stage1Maps[randomIndex], posistion, Quaternion.identity);
                break;
            case Stage.stage3:
                randomIndex = Random.Range(0, stage3Maps.Count);
                Instantiate(stage1Maps[randomIndex], posistion, Quaternion.identity);
                break;
        }


    }



}
