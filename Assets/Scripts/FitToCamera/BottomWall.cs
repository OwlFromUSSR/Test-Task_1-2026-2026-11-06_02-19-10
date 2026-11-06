using UnityEngine;

public class BottomWall : MonoBehaviour
{
    void Start()
    {
        Camera camera = Camera.main;

        if (camera != null && camera.orthographic)
        {
            float cameraHalfHeight = camera.orthographicSize;

            transform.position = new Vector3(0f, -1f * cameraHalfHeight, 0f);

            BoxCollider2D col = GetComponent<BoxCollider2D>();
            if (col != null)
            {
                float cameraWidth = cameraHalfHeight * 2 * camera.aspect;
                float colWidth = col.size.x;

                col.size = new Vector2(cameraWidth / colWidth, 1f);
            }
        }
    }
}
