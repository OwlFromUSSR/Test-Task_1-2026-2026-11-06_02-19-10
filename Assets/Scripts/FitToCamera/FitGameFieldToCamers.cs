using UnityEngine;

public class FitGameFieldToCamers : MonoBehaviour
{
    void Start()
    {
        Camera camera = Camera.main;

        if(camera != null && camera.orthographic)
        {
            float cameraHeight = camera.orthographicSize * 2f;
            float cameraWidth = cameraHeight * camera.aspect;

            //transform.localScale = new Vector3(cameraWidth, cameraHeight, 1f);
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null && sr.sprite != null)
            {
                float spriteWidth = sr.sprite.bounds.size.x;
                float spriteHeight = sr.sprite.bounds.size.y;
                transform.localScale = new Vector3(cameraWidth / spriteWidth, cameraHeight / spriteHeight, 1f);
            }
        }
    }
}
