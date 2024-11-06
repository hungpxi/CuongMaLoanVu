using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform player1StartPosition;    // Vị trí bắt đầu của người chơi 1
    public Transform player2StartPosition;    // Vị trí bắt đầu của người chơi 2
    public GameObject[] characterPrefabs;     // Mảng chứa các prefab nhân vật

    void Start()
    {
        // Lấy lựa chọn nhân vật từ PlayerPrefs
        int player1Index = PlayerPrefs.GetInt("Player1CharacterIndex", -1);
        int player2Index = PlayerPrefs.GetInt("Player2CharacterIndex", -1);

        // Instantiate và đặt vị trí cho nhân vật người chơi 1
        if (player1Index != -1 && player1Index < characterPrefabs.Length)
        {
            GameObject player1Character = Instantiate(characterPrefabs[player1Index], player1StartPosition.position, Quaternion.identity);
            player1Character.name = "Player1Character";
            

            // Đảm bảo nhân vật của người chơi 1 giữ nguyên scaleX ban đầu
            Vector3 player1Scale = player1Character.transform.localScale;
            player1Character.transform.localScale = new Vector3(Mathf.Abs(player1Scale.x), player1Scale.y, player1Scale.z);

            
            
            Debug.Log("Đã đặt vị trí và scale cho người chơi 1.");
        }

        // Instantiate và đặt vị trí cho nhân vật người chơi 2
        if (player2Index != -1 && player2Index < characterPrefabs.Length)
        {
            GameObject player2Character = Instantiate(characterPrefabs[player2Index], player2StartPosition.position, Quaternion.identity);
            player2Character.name = "Player2Character";
            

            // Đặt scaleX thành giá trị âm để nhân vật quay mặt về phía khác
            Vector3 player2Scale = player2Character.transform.localScale;
            player2Character.transform.localScale = new Vector3(-Mathf.Abs(player2Scale.x), player2Scale.y, player2Scale.z);

            Debug.Log("Đã đặt vị trí và scale cho người chơi 2.");
        }
    }
}
