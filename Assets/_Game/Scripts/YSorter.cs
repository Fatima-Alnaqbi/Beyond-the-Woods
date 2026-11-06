using UnityEngine;

/// <summary>Draws things lower on screen in front (top-down depth sorting).</summary>
[RequireComponent(typeof(SpriteRenderer))]
public class YSorter : MonoBehaviour
{
    public bool isStatic;
    public int offset;
    SpriteRenderer sr;

    void Awake() { sr = GetComponent<SpriteRenderer>(); Apply(); }
    void LateUpdate() { if (!isStatic) Apply(); }
    void Apply() { sr.sortingOrder = -Mathf.RoundToInt(transform.position.y * 100f) + offset; }
}
