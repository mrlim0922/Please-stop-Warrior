using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    [SerializeField]
    private GameObject Potion;
    [SerializeField]
    private GameObject SpawnPoint;
    [SerializeField]
    private GameObject[] Boss;
    private GameObject[] Boss2;
    public GameObject warning;
    public GameObject[] stageUI;

    private FadeManager theFade;

    private float stageTime = 0;
    private float NextStageTime = 15;
    private int StageLevel = 0;

    private bool time   = true;
    private bool summon = true;

    private SpawnManager spawnManager;

    private void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Update () {
        if (time)
            stageTime += Time.deltaTime;

        if (stageTime > NextStageTime)
        {
            StartCoroutine(ShowBoss());
            spawnManager.spawnTime = 2.5f;
            NextStageTime += 10;
            time = false;
        }
	}

    public int GetStageLevel()
    {
        return StageLevel;
    }

    public void ChangeStage()
    {
        spawnManager.spawnTime = 7f;

        stageTime = 0;

        StartCoroutine(FadeCoroutine());
        

        time = true;

        spawnManager.minCount = 2;
        spawnManager.maxCount = 5;
        spawnManager.summon = true;
    }
    public void ChangeStage3()
    {
        spawnManager.spawnTime = 7f;

        stageTime = 0;

        StartCoroutine(FadeCoroutine());

        time = true;

        spawnManager.minCount = 5;
        spawnManager.maxCount = 8;
        spawnManager.summon = true;
    }
    
    IEnumerator ShowBoss()
    {
        AudioManager.instance.Play("Warning");
        Instantiate(warning, new Vector3(0, 6, 0), transform.rotation);
        yield return new WaitForSeconds(3f);

        Vector3 pos = transform.position;
        pos.y = 5f;

        Instantiate(Boss[StageLevel], pos, Quaternion.identity);

        spawnManager.summon = false;
    }

    IEnumerator FadeCoroutine()
    {
        StartCoroutine(SpawnItem(10));
        theFade.FadeOut(0.01f);

        yield return new WaitForSeconds(2.0f);

        StageLevel++;
        theFade.FadeIn(0.01f);
        Instantiate(stageUI[StageLevel], new Vector3(0, 6, 0), transform.rotation);
    }

    IEnumerator SpawnItem(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        if (summon)
        {
            Vector3 temp = new Vector3(SpawnPoint.transform.position.x,
                SpawnPoint.transform.position.y - 0.7f, -1);

            Instantiate(Potion, temp, Quaternion.identity);
        }
    }
}
