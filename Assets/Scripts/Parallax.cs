using UnityEngine;

public class Parallax: MonoBehaviour
{
    // Khai báo MeshRenderer để truy cập vào material và điều khiển texture offset
    private MeshRenderer meshRenderer;

    // Tốc độ cuộn background
    public float animationSpeed = 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // di chuyển texture sang trái/phải 
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
