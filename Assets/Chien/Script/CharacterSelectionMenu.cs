//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class CharacterSelectionMenu : MonoBehaviour
//{
//    public GameObject[] characterPrefabs;   // Mảng chứa các prefab nhân vật
//    public Button[] characterButtons;       // Các nút để chọn nhân vật

//    private GameObject player1Character;
//    private GameObject player2Character;
//    private int player1Selection = -1;
//    private int player2Selection = -1;

//    void Start()
//    {
//        for (int i = 0; i < characterButtons.Length; i++)
//        {
//            int index = i;
//            characterButtons[i].onClick.AddListener(() => OnCharacterSelected(index));
//        }
//    }

//    void OnCharacterSelected(int index)
//    {
//        if (player1Selection == -1)
//        {
//            player1Selection = index;
//            player1Character = Instantiate(characterPrefabs[index]);
//            player1Character.name = "Player1Character"; // Đặt tên để tìm thấy trong Map1
//            DontDestroyOnLoad(player1Character);
//            characterButtons[index].interactable = false;
//        }
//        else if (player2Selection == -1 && index != player1Selection)
//        {
//            player2Selection = index;
//            player2Character = Instantiate(characterPrefabs[index]);
//            player2Character.name = "Player2Character"; // Đặt tên để tìm thấy trong Map1
//            DontDestroyOnLoad(player2Character);
//            characterButtons[index].interactable = false;
//        }

//        if (player1Selection != -1 && player2Selection != -1)
//        {
//            StartGame();
//        }
//    }

//    void StartGame()
//    {
//        SceneManager.LoadScene("Map1"); // Chuyển đến scene Map1
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour
{
    public GameObject[] characterPrefabs;  // Mảng chứa các prefab nhân vật
    public Button[] characterButtons;      // Các nút chọn nhân vật

    private int player1Selection = -1;
    private int player2Selection = -1;

    public Text player1Label;              // Label for Player 1
    public Text player2Label;              // Label for Player 2

    void Start()
    {
        // Initialize the labels to be empty
        player1Label.text = "";
        player2Label.text = "";
        player1Label.rectTransform.localScale = new Vector3(4, 4, 4);
        player2Label.rectTransform.localScale = new Vector3(4, 4, 4);

        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i;
            characterButtons[i].onClick.AddListener(() => OnCharacterSelected(index));
        }
    }

    void OnCharacterSelected(int index)
    {
        if (player1Selection == -1)
        {
            player1Selection = index;
            characterButtons[index].interactable = false;
            DisplayLabel(player1Label, "P1", characterPrefabs[index]);
            Debug.Log("Người chơi 1 đã chọn nhân vật " + index);
        }
        else if (player2Selection == -1 && index != player1Selection)
        {
            player2Selection = index;
            characterButtons[index].interactable = false;
            DisplayLabel(player2Label, "P2", characterPrefabs[index]);
            Debug.Log("Người chơi 2 đã chọn nhân vật " + index);
        }

        if (player1Selection != -1 && player2Selection != -1)
        {
            StartGame();
        }
    }

    void DisplayLabel(Text label, string text, GameObject character)
    {
        label.text = text;
        // Position the label above the selected character
        Vector3 labelPosition = character.transform.position + Vector3.up; // Adjust Y offset as needed
        label.transform.position = Camera.main.WorldToScreenPoint(labelPosition);
    }

    void StartGame()
    {
        // Lưu lựa chọn nhân vật vào PlayerPrefs hoặc một biến tạm thời khác
        PlayerPrefs.SetInt("Player1CharacterIndex", player1Selection);
        PlayerPrefs.SetInt("Player2CharacterIndex", player2Selection);

        // Chuyển sang scene Map1
        SceneManager.LoadScene("Map1");
    }
}
