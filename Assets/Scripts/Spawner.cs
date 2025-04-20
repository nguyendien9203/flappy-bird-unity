using UnityEngine;

public class Spawner: MonoBehaviour
{
    // Khai báo đối tượng pipe
    public GameObject prefab;

    // Thời gian mỗi lần sinh ra (1 giây = mỗi giây sinh ra 1 lần)
    public float spawnRate = 1f;

    // Dải tọa độ Y ngẫu nhiên để spawn prefab (để pipe cao/thấp khác nhau)
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void Start()
    {
        // Cứ 1 giây sẽ spawn 1 prefab
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Tránh việc vẫn tiếp tục spawn khi object không còn hoạt động
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Tạo 1 object pipes mới xuất hiện ở vị trí của Spawner
        // transform.position là ví trí hiện tại của Spawner
        // Quaternion.identity là giữ nguyên hướng xoay khi pipe đc sinh ra
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Các prefab đc spawn ra sẽ có vị trí cao thấp khác nhau từ ví trí ban đầu
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
