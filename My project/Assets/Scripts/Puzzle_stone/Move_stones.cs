using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_stones : MonoBehaviour
{
    [HideInInspector] public GameObject gameObject;
    public Material selected_Material;
    

    public float speed = 0.5f;

    [HideInInspector] public MeshRenderer _meshRenderer;
    
    private Material originalMaterial;
    

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = _meshRenderer.material;
        gameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_meshRenderer.sharedMaterial == selected_Material){
            float hori = Input.GetAxis("Horizontal");
            float verti = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(verti, hori, 0);
            movement = Vector3.ClampMagnitude(movement, 1);
            transform.Translate(speed * Time.deltaTime * movement);
        }
    }

    public void ResetMaterial()
    {
        _meshRenderer.material = originalMaterial;
    }
}
