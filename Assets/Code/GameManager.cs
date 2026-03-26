
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]public static GameManager Instance;

    [Header("Stage1")] public List<GameObject> stage1Maps; //스테이지 1 맵
    [Header("Stage2")] public List<GameObject> stage2Maps; //스테이지 2 맵
    [Header("Stage3")] public List<GameObject> stage3Maps; //스테이지 3 맵

    enum Stage { stage1,stage2,stage3}; // 스테이지 상황
    Stage currentStage; // 스테이지 상황


    public TextMeshProUGUI ScoreText;
    float score;
    public float clearScore = 100; // 게임 클리어 점수

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

    private void Update()
    {
        score += Time.deltaTime; // 시간만큼 점수
        if(ScoreText != null ) // 오브젝트할당이 되어있을때만 
        {
            ScoreText.text = "Score : " + score.ToString(".00"); // 소수점 2째 까지만 나오게
        }

        if(score >= clearScore)
        {
            PlayerPrefs.SetFloat("Score", score); // 최종 점수 저장
            GameClear();
        }
    }



    public void GameClear()
    {
        SceneManager.LoadScene("SuccessCutScene"); // 게임 클리어 씬으로 이동
    }
    public void GameOver()
    {
        PlayerPrefs.SetFloat("Score", score); // 최종 점수 저장
        SceneManager.LoadScene("FailureCutScene"); // 게임 오버씬으로 이동
    }




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
