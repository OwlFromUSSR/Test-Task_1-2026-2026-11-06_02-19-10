using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartsUI : MonoBehaviour
{
    [SerializeField] PlayerHealth health;
    [SerializeField] Image heartPrefab;
    [SerializeField] Sprite full, empty;

    private readonly List<Image> hearts = new();


    private void Start()
    {
        for (int i = 0; i < health.MaxHP; ++i)
            hearts.Add(Instantiate(heartPrefab, transform));
        health.Changed += Redraw;
        Redraw();
    }

    private void OnDestroy()
    {
        if (health != null) health.Changed -= Redraw;
    }

    private void Redraw()
    {
        for (int i = 0; i < hearts.Count; ++i)
        {
            int left = health.HP - i;
            hearts[i].sprite = left >= 1 ? full : empty;
        }
    }

}
