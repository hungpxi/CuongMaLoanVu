using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Script : MonoBehaviour
{
    [SerializeField]
    float forceX, forceY;
    Rigidbody2D rigit;

    Animator animator;

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform boomPoint;
    [SerializeField] private GameObject[] Boommerangs;
    private float cooldownTimer = Mathf.Infinity;

    void Awake()
    {
        rigit = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetInteger("StateIndex", 0);
    }

    // Update is called once per frame
    void Update()
    {

        // Kiểm tra trạng thái nhảy trước tiên để ưu tiên nhảy khi có phím nhấn
        if (Input.GetKeyDown(KeyCode.UpArrow) && rigit.velocity.y == 0)
        {
            rigit.velocity = new Vector2(rigit.velocity.x, forceY); // Tạo vận tốc nhảy lên
            animator.SetInteger("StateIndex", 1); // Set trạng thái nhảy lên
        }
        // Kiểm tra trạng thái rơi
        else if (rigit.velocity.y < 0) // Nếu vận tốc dọc âm (nhân vật đang rơi)
        {
            animator.SetInteger("StateIndex", 3); // Set trạng thái rơi
        }
        // Di chuyển sang phải
        else if (Input.GetKey(KeyCode.RightArrow) && rigit.velocity.y == 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
            rigit.velocity = new Vector2(forceX, rigit.velocity.y); // Di chuyển với vận tốc forceX
            animator.SetInteger("StateIndex", 2); // Set trạng thái chạy
        }
        // Di chuyển sang trái
        else if (Input.GetKey(KeyCode.LeftArrow) && rigit.velocity.y == 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
            rigit.velocity = new Vector2(-forceX, rigit.velocity.y); // Di chuyển với vận tốc -forceX
            animator.SetInteger("StateIndex", 2); // Set trạng thái chạy
        }
        // Đứng yên nếu không có vận tốc và không nhấn phím nào
        else if (rigit.velocity.x == 0 && rigit.velocity.y == 0)
        {
            animator.SetInteger("StateIndex", 0); // Trạng thái đứng yên
        }


        if (Input.GetKeyDown(KeyCode.J)) // Đánh thường
        {
            animator.SetTrigger("Combo1"); // Kích hoạt trigger Attack
        }

        if (Input.GetKeyDown(KeyCode.I)) // Sử dụng Ultimate
        {
            animator.SetTrigger("Special"); // Kích hoạt trigger Ultimate
        }

        if (Input.GetKeyDown(KeyCode.O)) // Combo 2
        {
            animator.SetTrigger("Combo3"); // Kích hoạt trigger Combo2
        }









        cooldownTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && cooldownTimer > attackCooldown)
        {
            animator.SetInteger("StateIndex", 4);
            //Attack();

            cooldownTimer = 0;
            Boommerangs[FindBoomerang()].transform.position = boomPoint.position;
           // Boommerangs[FindBoomerang()].GetComponent<Bummerang1>().SetDirection(Mathf.Sign(transform.localScale.x));

        }
        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.CompareTag("enemy"))
        //        animator.SetInteger("StateIndex", 4);
        //}
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("dragon"))
    //    {

    //        // Chuyển sang animation HitDame
    //        animator.SetTrigger("HitDame");
    //    }
    //}

    //private void Attack()
    //{
    //    animator.SetTrigger("Attack");
    //    cooldownTimer = 0;


    //    Boommerangs[FindBoomerang()].transform.position = boomPoint.position;
    //    Boommerangs[FindBoomerang()].GetComponent<Bummerang1>().SetDirection(Mathf.Sign(transform.localScale.x));
    //}
    private int FindBoomerang()
    {
        for (int i = 0; i < Boommerangs.Length; i++)
        {
            if (!Boommerangs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
