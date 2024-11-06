//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class BGScript : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public class CharAndAnimator
//    {
//        public Animator animator1;
//        public Canvas canvas;
//    }

//    public CharAndAnimator p1, p2;
//    // Script tru mau: public PlayerHealth playerHealth;
//    private List<CharAndAnimator> listPlayer = new List<CharAndAnimator>();
//    private Image mana1, rage1, healthbar1, mana2, rage2, healthbar2;
//    void Start()
//    {
//        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
//        Canvas canvas1 = GameObject.FindGameObjectWithTag("Health1").GetComponent<Canvas>();
//        Canvas canvas2 = GameObject.FindGameObjectWithTag("Health2").GetComponent<Canvas>();
//        GameObject player1, player2;
//        foreach (GameObject player in players)
//        {
//            if (player.transform.localScale.x > 0)
//            {
//                player1.AddComponent<canvas1>();    
//            }
//            else
//            {
//                var active = player.gameObject.GetComponent<PlayerMoves_P1>();
//                if (active != null)
//                {
//                    active.enabled = false;
//                }

//                player2 = player;
//                p2 = new CharAndAnimator()
//                {
//                    animator1 = player2.GetComponent<Animator>(),
//                    canvas = canvas2
//                };
//                listPlayer.Add(p2);
//            }
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }


//}
