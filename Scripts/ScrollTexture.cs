using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.2f;
    private float offset = 0f;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}

