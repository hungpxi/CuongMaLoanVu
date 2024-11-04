using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Heart, RedBull, Diamond }
    public ItemType itemType;
    public int value = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.tag == "P4")
        {
            P4 player = collision.gameObject.GetComponent<P4>();
            if (player != null)
            {
                switch (itemType)
                {
                    case ItemType.Heart:
                        //player.AddHealth(value);
                        break;
                    case ItemType.RedBull:
                        //player.AddMana(value);
                        break;
                    case ItemType.Diamond:
                        //player.AddStrength(value);
                        break;
                }
                gameObject.SetActive(false); // Return to the pool
            }
        }
    }
}
