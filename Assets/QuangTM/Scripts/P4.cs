using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4 : MonoBehaviour
{
    public float speed = 10f;
    public int height = 5;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isFacingRight = true;
    private float movement;

    //Bullet
    public GameObject bulletPrefab;
    private List<GameObject> bulletList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (isFacingRight && movement < 0 || !isFacingRight && movement > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("Integer", 1);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetInteger("Integer", 2);
            rb.velocity = new Vector2(rb.velocity.x, height);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetInteger("Integer", 3);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            anim.SetInteger("Integer", 4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            anim.SetInteger("Integer", 5);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            anim.SetInteger("Integer", 6);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) 
            && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow)
            && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow)
            && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow)
            && !Input.GetKey(KeyCode.Keypad1)
            && !Input.GetKey(KeyCode.Keypad2)
            && !Input.GetKey(KeyCode.Keypad3))
        {
            anim.SetInteger("Integer", 0);
        }
    }

    public void Shoot()
    {
        // Tạo một viên đạn tại vị trí của nhân vật với hướng đối mặt
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletList.Add(bullet);

        // Lấy hướng nhân vật đang đối mặt
        Vector2 shootDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        // Flip viên đạn theo hướng của nhân vật
        if (shootDirection == Vector2.left)
        {
            Vector3 bulletScale = bullet.transform.localScale;
            bulletScale.x = -Mathf.Abs(bulletScale.x); // Đảm bảo hướng về trái
            bullet.transform.localScale = bulletScale;
        }
        else
        {
            Vector3 bulletScale = bullet.transform.localScale;
            bulletScale.x = Mathf.Abs(bulletScale.x); // Đảm bảo hướng về phải
            bullet.transform.localScale = bulletScale;
        }

        // Cài đặt hướng của đạn
        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * 10f; // 10f là tốc độ của đạn, có thể điều chỉnh

        // Hủy viên đạn sau 1 giây và xóa khỏi danh sách
        StartCoroutine(DestroyBulletAfterTime(bullet, 1f));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        bulletList.Remove(bullet);
        bullet.SetActive(false);
    }
}
