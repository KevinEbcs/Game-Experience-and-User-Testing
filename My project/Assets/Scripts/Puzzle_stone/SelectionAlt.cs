using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionAlt : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material originalMaterial;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;


    // Update is called once per frame
    void Update()
    {
        if (highlight != null){
            highlight.GetComponent<MeshRenderer>().material = originalMaterial;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)){
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection){ // if it's selectable and not selected, it can be highlighted (when hovered)
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial){ // if Material is not highlightMaterial, set it to highlightMaterial
                    originalMaterial = highlight.GetComponent<MeshRenderer>().material;// save originalMaterial, so it can be accessed again later
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
            else {
                highlight = null;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()){
            if (selection != null){
                selection.GetComponent<MeshRenderer>().material = originalMaterial; // set Material to originalMaterial
                selection = null;
            }
            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)){
                selection = raycastHit.transform;
                if (selection.CompareTag("Selectable")){
                    selection.GetComponent<MeshRenderer>().material = selectionMaterial; // set Material to selectionMaterial
                }
                else {
                    selection = null;
                }
            }
        }
    }
}
