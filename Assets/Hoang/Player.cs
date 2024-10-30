using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật  
    private Rigidbody2D rb;

    void Start()
    {
        // Lấy Rigidbody2D để di chuyển nhân vật  
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lấy đầu vào từ bàn phím  
        float moveX = Input.GetAxis("Horizontal"); // Nhận đầu vào từ phím trái/phải  
        float moveY = Input.GetAxis("Vertical"); // Nhận đầu vào từ phím lên/xuống (nếu cần)  

        // Tính toán vectơ di chuyển  
        Vector2 move = new Vector2(moveX, moveY);

        // Gọi hàm để di chuyển  
        Move(move);
    }

    void Move(Vector2 direction)
    {
        // Di chuyển nhân vật  
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}