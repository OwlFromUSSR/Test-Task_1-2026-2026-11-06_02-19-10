using UnityEngine;
using UnityEngine.UI;

public class SpeedIndicator : MonoBehaviour
{
    [SerializeField] SpeedBoost boost;
    [SerializeField] Image fill;
    [SerializeField] CanvasGroup group;
    [SerializeField] float blinkThreshold = 2f;
    [SerializeField] float blinkHz = 4f;

    private void Update()
    {
        if (!boost.Active)
            group.alpha = 0f;
        else
        {
            fill.fillAmount = boost.Remaining / boost.Duration;

            bool blinking = boost.Remaining < blinkThreshold;
            bool visible = !blinking || Mathf.Sin(Time.time * blinkHz * 2f * Mathf.PI) > 0f;
            group.alpha = visible ? 1f : 0.2f;
        }
    }
}
