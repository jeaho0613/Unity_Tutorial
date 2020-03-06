using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemyBPrefab;
    public GameObject enemyLPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemySPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemCoinPrefab;
    public GameObject itemBoomPrefab;
    public GameObject bulletPlayerAPrefab;
    public GameObject bulletPlayerBPrefab;
    public GameObject bulletEnemyAPrefab;
    public GameObject bulletEnemyBPrefab;
    public GameObject bulletBossAPrefab;
    public GameObject bulletBossBPrefab;
    public GameObject bulletFollowerfab;
    public GameObject explostionPrefab;

    GameObject[] enemyL;
    GameObject[] enemyM;
    GameObject[] enemyS;
    GameObject[] enemyB;

    GameObject[] itemCoin;
    GameObject[] itemPower;
    GameObject[] itemBoom;

    GameObject[] bulletPlayerA;
    GameObject[] bulletPlayerB;
    GameObject[] bulletEnemyA;
    GameObject[] bulletEnemyB;

    GameObject[] bulletBossA;
    GameObject[] bulletBossB;
    GameObject[] bulletFollower;

    GameObject[] targetPool;
    GameObject[] explostion;


    private void Awake()
    {
        enemyB = new GameObject[1];
        enemyL = new GameObject[50];
        enemyM = new GameObject[50];
        enemyS = new GameObject[50];

        itemCoin = new GameObject[30];
        itemPower = new GameObject[30];
        itemBoom = new GameObject[30];

        bulletPlayerA = new GameObject[200];
        bulletPlayerB = new GameObject[200];

        bulletEnemyA = new GameObject[200];
        bulletEnemyB = new GameObject[200];
        bulletFollower = new GameObject[200];
        bulletBossA = new GameObject[200];
        bulletBossB = new GameObject[400];
        explostion = new GameObject[20];


        // 생성부분
        {
            Generate(enemyBPrefab, enemyB);
            Generate(enemyLPrefab, enemyL);
            Generate(enemyMPrefab, enemyM);
            Generate(enemySPrefab, enemyS);
            Generate(itemCoinPrefab, itemCoin);
            Generate(itemPowerPrefab, itemPower);
            Generate(itemBoomPrefab, itemBoom);
            Generate(bulletPlayerAPrefab, bulletPlayerA);
            Generate(bulletPlayerBPrefab, bulletPlayerB);
            Generate(bulletEnemyAPrefab, bulletEnemyA);
            Generate(bulletEnemyBPrefab, bulletEnemyB);
            Generate(bulletBossAPrefab, bulletBossA);
            Generate(bulletBossBPrefab, bulletBossB);
            Generate(bulletFollowerfab, bulletFollower);
            Generate(explostionPrefab, explostion);
        }

    }

    public void Generate(GameObject objPrefab, GameObject[] objPool)
    {
        for (int index = 0; index < objPool.Length; index++)
        {
            objPool[index] = Instantiate(objPrefab);
            objPool[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "EnemyB":
                targetPool = enemyB;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletFollower":
                targetPool = bulletFollower;
                break;
            case "BulletBoosA":
                targetPool = bulletBossA;
                break;
            case "BulletBoosB":
                targetPool = bulletBossB;
                break;
            case "Explosion":
                targetPool = explostion;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "EnemyB":
                targetPool = enemyB;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletFollower":
                targetPool = bulletFollower;
                break;
            case "BulletBoosA":
                targetPool = bulletBossA;
                break;
            case "BulletBoosB":
                targetPool = bulletBossB;
                break;
            case "Explosion":
                targetPool = explostion;
                break;
        }
        return targetPool;
    }
}
