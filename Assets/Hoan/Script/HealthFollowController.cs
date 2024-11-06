using UnityEngine;
using UnityEngine.UI;

public class HealthFollowController : MonoBehaviour
{
    public GameObject player; // Nhân vật mà thanh máu sẽ đi theo
    public Image healthBarForeground; // Thanh máu chính
    public float maxHealth = 100f; // Sức khỏe tối đa
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Đặt sức khỏe hiện tại bằng sức khỏe tối đa
        UpdateHealthBar();
    }

    void Update()
    {
        // Thay đổi sức khỏe tại đây để thử nghiệm
        // Ví dụ: Giảm sức khỏe theo thời gian
        if (currentHealth > 0)
        {
            currentHealth -= Time.deltaTime * 10f; // Giảm 10 máu mỗi giây
            UpdateHealthBar();
        }

        // Đặt vị trí của thanh máu theo vị trí của nhân vật
        // Thay đổi khoảng cách nếu cần thiết
        transform.position = player.transform.position + new Vector3(0, 1.5f, 0); // Đặt thanh máu ở trên đầu nhân vật, bạn có thể điều chỉnh khoảng cách
    }

    void UpdateHealthBar()
    {
        healthBarForeground.fillAmount = currentHealth / maxHealth; // Cập nhật thanh máu
    }
}
