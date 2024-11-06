using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Map1()
    {
        SceneManager.LoadScene(1);
    }
    public void Map2()
    {
        SceneManager.LoadScene(2);
    }
    public void Map3()
    {
        SceneManager.LoadScene(3);
    }
    public void Map4()
    {
        SceneManager.LoadScene(4);
    }
    public void Menu()
    {
        SceneManager.LoadScene(5);
    }
}
