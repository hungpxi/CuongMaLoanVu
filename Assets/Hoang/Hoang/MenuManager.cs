using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject imageMenu;
    public GameObject selectCharacterPanel;
    public GameObject selectMapPanel;
    public void BackToMenu()
    {
        imageMenu.SetActive(true);
        selectCharacterPanel.SetActive(false);
        selectMapPanel.SetActive(false);
    }

    public void SelectCharacter()
    {
        //imageMenu.SetActive(false);
        //selectCharacterPanel.SetActive(true);
        SceneManager.LoadScene("Map1");
    }
    public void BackToSelectCharacter()
    {
        selectCharacterPanel.SetActive(true);
        selectMapPanel.SetActive(false);
    }
    public void SelectMap()
    {
        selectCharacterPanel.SetActive(false);
        selectMapPanel.SetActive(true);
    }
}
