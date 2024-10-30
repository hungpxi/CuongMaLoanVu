using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharMovement : MonoBehaviour
{
    public class CharAndAnimator
    {
        public Animator animator;
        public Canvas canvas;
    }

    //Rigidbody2D Rigidbody2D;

    private List<CharAndAnimator> listPlayer = new List<CharAndAnimator>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Canvas canvas1 = GameObject.FindGameObjectWithTag("Health1").GetComponent<Canvas>();
        Canvas canvas2 = GameObject.FindGameObjectWithTag("Health2").GetComponent<Canvas>();
        GameObject player1, player2;

        foreach (GameObject player in players)
        {
            if (player.transform.localScale.x > 0)
            {
                player1 = player;
                CharAndAnimator p1 = new CharAndAnimator()
                {
                    animator = player1.GetComponent<Animator>(),
                    canvas = canvas1
                };
                listPlayer.Add(p1);
            }
            else
            {
                player2 = player;
                CharAndAnimator p2 = new CharAndAnimator()
                {
                    animator = player2.GetComponent<Animator>(),
                    canvas = canvas2
                };
                listPlayer.Add(p2);
            }
        }

        Debug.Log(listPlayer.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
