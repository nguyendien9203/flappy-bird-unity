using Unity.Jobs;
using UnityEngine;

// MonoBehaviour là 1 lớp base để script hoạt động
// Kế thừa MonoBehavior để 1 GameObject có thể hoạt động Start , Update,... tưởng tác vơi Unity Engine
public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Định nghĩa 1 mảng sprite
    public Sprite[] sprites;

    // Theo dõi chỉ mục hiện tại trong mảng sprites
    private int spriteIndex; 

    // Khai báo hướng trong không gian 3 chiều
    private Vector3 direction;

    // Khai báo trọng lực
    public float gravity = -9.8f;

    // Độ mạnh của lực nhảy
    public float strength = 5f;

    // Tự động gọi khi GameObject dc khởi tạo
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Gọi đi gọi lại hàm AnimateSprite theo thời gian định kỳ
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        // Xử lý đầu vào bằng nút space hoặc nhấp chuột trái
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Khi user input hướng sẽ lên trên với độ dài = strength
            direction = Vector3.up * strength;
        }

        // Xử lý nút chạm trên thiết bị di động
        // Check user có chạm vào màn hình ít nhất 1 ngón tay hay không
        if (Input.touchCount > 0)
        {
            // Lấy thông tin về ngón đầu tiên đang chạm vào màn hình
            Touch touch = Input.GetTouch(0);

            // Check trạng thái "vừa mới chạm"
            if (touch.phase == TouchPhase.Began)
            {
                // Nếu vừa chạm, gán lực bay lên
                direction = Vector3.up * strength;
            }
        }
            // Cập nhật vận tốc rơi của chim theo thời gian trên trục y
            direction.y += gravity * Time.deltaTime;

            // cập nhật vị trí mới từng chút một trong mỗi frame
            // transform.position : Vị trí hiện tại 
            transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite ()
    {
        // Tăng chỉ số hình ảnh lên 1 để chuyển sang sprite kế tiếp
        spriteIndex++;

        // Nếu chỉ số vượt quá số lượng sprite trong mảng thì reset lại chỉ số về 0 để bắt đầu lại từ sprite đầu tiên
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        // Gán sprite tương ứng từ mảng vào SpriteRenderer
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
