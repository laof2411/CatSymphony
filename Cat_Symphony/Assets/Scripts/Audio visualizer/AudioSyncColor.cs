using System.Collections;
using UnityEngine;

public class AudioSyncColor : AudioSyncer
{
    private IEnumerator MoveToColor(Color target)
    {
        Color current = objectRenderer.material.color;
        Color initial = current;
        float timer = 0;

        while (current != target)
        {
            current = Color.Lerp(initial, target, timer / timeToBeat);
            timer += Time.deltaTime;

            objectRenderer.material.color = current;

            yield return null;
        }

        m_isBeat = false;
    }

    private Color RandomColor()
    {
        if (beatColors == null || beatColors.Length == 0) return Color.white;
        m_randomIndx = Random.Range(0, beatColors.Length);
        return beatColors[m_randomIndx];
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        objectRenderer.material.color = Color.Lerp(objectRenderer.material.color, restColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        Color newColor = RandomColor();

        StopCoroutine(nameof(MoveToColor));
        StartCoroutine(MoveToColor(newColor));
    }

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    public Color[] beatColors;
    public Color restColor;
    public float restSmoothTime = 2.0f;

    private int m_randomIndx;
    private Renderer objectRenderer;
}
