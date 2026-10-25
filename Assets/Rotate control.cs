using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem; // 引入新版 Input System 命名空間

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;
    AudioSource audioSource;

    void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 使用新版 Input System 偵測滑鼠左鍵按下瞬間
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            this.rotSpeed = 30f;

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        transform.Rotate(0, 0, this.rotSpeed);

        this.rotSpeed *= 0.96f;

        if (this.rotSpeed > 0 && this.rotSpeed < 0.05f)
        {
            this.rotSpeed = 0;
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}

