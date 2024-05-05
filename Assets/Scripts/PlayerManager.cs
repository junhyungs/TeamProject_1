using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject[] playerPrefabs;
    
    public static int playerCount = 1;
    public static int playerCountMax = 5;

    public Vector3[] positionOffset;

    private void Start()
    {
        InitPlayer();
    }

    private void OnEnable()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        playerCount = 1;
        playerCountMax = 5;

        DeactivePlayer();

        playerPrefabs[0].transform.position = transform.position + positionOffset[0];
        playerPrefabs[0].gameObject.SetActive(true);
    }

    public void PlayerPlus()
    {
        if(playerCount < playerCountMax)
        {
            playerCount++;

            Vector3 basePosition = playerPrefabs[0].transform.position;

            Vector3 newPosition = basePosition + positionOffset[playerCount - 1];

            playerPrefabs[playerCount - 1].transform.position = newPosition;
            playerPrefabs[playerCount - 1].gameObject.SetActive(true);
        }

        else
        {
            WeaponManager.Instance.PowerUP();
        }
    }

    public void PlayerMinus()
    {
        if(playerCount > 0)
        {
            playerCount--;

            playerPrefabs[playerCount].gameObject.SetActive(false);
        }

        if(playerCount == 0)
        {
            Debug.Log("��������");
        }
    }

    private void DeactivePlayer()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPlus();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerMinus();
        }
    }
}