using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Tốc độ pipe sẽ di chuyển từ phải qua trái
    public float speed = 5f;

    // Lưu tọa độ x mép trái của màn hình
    private float leftEdge;

    private void Start()
    {
        // Lấy ví trí mép trái của màn hình
        // Để biết pipe nào ra khỏi màn hình bên trái thì xóa nó đi 
        // Không xóa ngay khi chạm mép màn hình
        // Xóa sau khi hoàn toàn đi khỏi màn hình 1 đơn vị
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    public void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Nếu ví trí của pipe nhỏ hơn mép trái (pipe đã ra khỏi màn hình) để xóa pipe đó khỏi game
        // Giải phóng bộ nhớ, tránh game bị chậm khi quá nhiều object dư thừa tồn tại
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
