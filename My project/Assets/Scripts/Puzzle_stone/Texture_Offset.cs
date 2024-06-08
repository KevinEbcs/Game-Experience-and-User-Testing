using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture_Offset : MonoBehaviour
{
    private float scrollSpeed = 0.5f;

    private Renderer rend;

    private static readonly int StonePuzzleTexture = Shader.PropertyToID("stone_puzzle_texture");

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset(StonePuzzleTexture, new Vector2(offset, 0));
    }
}
