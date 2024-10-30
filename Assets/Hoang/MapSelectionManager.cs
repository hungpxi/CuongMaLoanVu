using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour

{
    public GameObject Map1Prefab;
    public GameObject Map2Prefab;
    public GameObject Map3Prefab;
    public GameObject Map4Prefab;
    // Start is called before the first frame update
    void Start()
    {
        string selectedMap = PlayerPrefs.GetString("SelectedMap", "DefaultMap");

        // Load bản đồ tương ứng với selectedMap
        LoadMap(selectedMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectMap(string mapName)
    {
        // Lưu tên map đã chọn, có thể dùng PlayerPrefs hoặc biến tạm thời
        PlayerPrefs.SetString("SelectedMap", mapName);

        // Chuyển sang Scene chơi game
        SceneManager.LoadScene("Hoang Scene");
    }
    void LoadMap(string mapName)
    {
        // Thực hiện các thao tác cần thiết để tải map theo tên mapName
        switch (mapName)
        {
            case "Map1":
                Instantiate(Map1Prefab, Vector3.zero, Quaternion.identity);
                break;
            case "Map2":
                Instantiate(Map2Prefab, Vector3.zero, Quaternion.identity);
                break;
            case "Map3":
                Instantiate(Map3Prefab, Vector3.zero, Quaternion.identity);
                break;
            case "Map4":
                Instantiate(Map4Prefab, Vector3.zero, Quaternion.identity);
                break;
            default:
                Debug.LogError("Map không tồn tại: " + mapName);
                break;
        }
    }
}
