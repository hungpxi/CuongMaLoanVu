using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    public GameObject dragonPrefab; // Prefab của chiêu thức rồng
    public Transform firePoint; // Vị trí phát ra chiêu thức
    public float dragonLifeTime = 5f; // Thời gian tồn tại của chiêu thức

    public void Activate()
    {
        // Đảm bảo dragonPrefab luôn được kích hoạt trước khi tạo
        dragonPrefab.SetActive(true);

        // Tạo chiêu thức rồng tại vị trí và hướng của firePoint
        GameObject dragon = Instantiate(dragonPrefab, firePoint.position, firePoint.rotation);

        // Kiểm tra hướng của nhân vật
        if (transform.localScale.x < 0) // Nếu nhân vật đang quay trái
        {
            // Đảo hướng di chuyển của rồng và scale của nó
            dragon.GetComponent<DragonMovement>().speed = -Mathf.Abs(dragon.GetComponent<DragonMovement>().speed); // Đặt tốc độ âm
            dragon.transform.localScale = new Vector3(-Mathf.Abs(dragon.transform.localScale.x), dragon.transform.localScale.y, dragon.transform.localScale.z); // Đảo scale.x
        }
        else // Nếu nhân vật đang quay phải
        {
            // Đảm bảo rồng di chuyển với tốc độ dương
            dragon.GetComponent<DragonMovement>().speed = Mathf.Abs(dragon.GetComponent<DragonMovement>().speed);
            dragon.transform.localScale = new Vector3(Mathf.Abs(dragon.transform.localScale.x), dragon.transform.localScale.y, dragon.transform.localScale.z);
        }

        // Hủy chiêu thức sau thời gian tồn tại
        Destroy(dragon, dragonLifeTime);
    }
}
