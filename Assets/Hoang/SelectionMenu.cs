using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectionMenu : MonoBehaviour
{
    private int selectedCount = 0;
    private int selectedMapIndex = -1; // Lưu chỉ số của map đã chọn
    public Button[] characterButtons; // Mảng chứa các button nhân vật
    public Button[] mapButtons; // Mảng chứa các button map

    public void StartGame()
    {
        if (selectedCount == 2 && selectedMapIndex != -1)
        {
            // Chuyển đến map đã chọn
            int selectedMap = PlayerPrefs.GetInt("SelectedMap");
            SceneManager.LoadScene(selectedMap);
        }
        else
        {
            Debug.Log("Bạn cần chọn đủ 2 nhân vật và chọn map để bắt đầu trò chơi!");
        }
    }

    public void SelectCharacter(int characterIndex)
    {
        if (selectedCount >= 2)
        {
            return;
        }

        if (selectedCount == 0 || (selectedCount == 1 && PlayerPrefs.GetInt("FirstCharacter") != characterIndex))
        {
            selectedCount++;
            if (selectedCount == 1)
            {
                PlayerPrefs.SetInt("FirstCharacter", characterIndex);
            }
            else if (selectedCount == 2)
            {
                PlayerPrefs.SetInt("SecondCharacter", characterIndex);
            }
        }
    }

    public void SelectMap(int mapIndex)
    {
        // Kiểm tra nếu map đã được chọn rồi
        if (selectedMapIndex == mapIndex)
        {
            return;
        }

        // Lưu map đã chọn mới và bật nhấp nháy
        PlayerPrefs.SetInt("SelectedMap", mapIndex);
        selectedMapIndex = mapIndex; // Cập nhật chỉ số map đã chọn
        Debug.Log("Map " + mapIndex + " đã được chọn!");

    }
}
