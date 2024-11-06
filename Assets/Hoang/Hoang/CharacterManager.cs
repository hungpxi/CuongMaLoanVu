using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject Player1Prefab;
    public GameObject Player2Prefab;
    //public GameObject Player2Prefab;
    //public GameObject Player2Prefab;
    //public GameObject Player2Prefab;

    private Vector3 spawnPosition1 = new Vector3(-5, 0, 0);
    private Vector3 spawnPosition2 = new Vector3(6, 0, 0);

    void Start()
    {
        int firstCharacter = PlayerPrefs.GetInt("FirstCharacter", 1);
        int secondCharacter = PlayerPrefs.GetInt("SecondCharacter", 2);
        InstantiateCharacter(firstCharacter, spawnPosition1, true);
        InstantiateCharacter(secondCharacter, spawnPosition2, false);
    }

    void InstantiateCharacter(int characterIndex, Vector3 spawnPosition, bool isFirstCharacter)
    {
        GameObject characterPrefab = null;

        switch (characterIndex)
        {
            case 1:
                characterPrefab = Player1Prefab;
                break;
            case 2:
                characterPrefab = Player2Prefab;
                break;
            //case 3:
            //    characterPrefab = Player2Prefab;
            //    break;
            //case 4:
            //    characterPrefab = Player2Prefab;
            //    break;
            //case 5:
            //    characterPrefab = Player2Prefab;
            //    break;
        }

        if (characterPrefab != null)
        {
            GameObject character = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

            if (isFirstCharacter)
            {
                character.tag = "Player1";
            }
            else
            {
                character.tag = "Player2";
                Vector3 scale = character.transform.localScale;
                scale.x = -scale.x;
                character.transform.localScale = scale;
            }
        }
    }
}
