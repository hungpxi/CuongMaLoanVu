using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float speed = 10f;
    public int dragonDamage = 50; // Sát thương của chiêu rồng
    public LayerMask enemyLayers; // C

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Dragon is moving");

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm thuộc enemyLayers
        if (((1 << collision.gameObject.layer) & enemyLayers) != 0)
        {
            // Gây sát thương cho kẻ địch nếu có component TakeDamage
            var enemy = collision.GetComponent<TakeDamege>();
            if (enemy != null)
            {
                gameObject.SetActive(false);
               // enemy.TakeDamage(dragonDamage);
                
            }

            // Ẩn chiêu thức rồng
            //gameObject.SetActive(false);
        }
    }
}
