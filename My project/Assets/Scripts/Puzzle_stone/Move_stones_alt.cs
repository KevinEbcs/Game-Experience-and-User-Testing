using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_stones_alt : MonoBehaviour
{
    public GameObject gameObject;
    public Material selected_Material;

    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<MeshRenderer>().sharedMaterial == selected_Material){
            float hori = Input.GetAxis("Horizontal");
            float verti = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(verti, hori, 0);
            movement = Vector3.ClampMagnitude(movement, 1);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }
}
