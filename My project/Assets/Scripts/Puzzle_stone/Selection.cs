using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;

    
    private Transform highlight;
    private Move_stones highlightMoveStones;
    
    private Transform selection;
    private Move_stones selectionMoveStones;
    
    
    private RaycastHit raycastHit;
    //private int layerMask;


    void Start()
    {
        //layerMask = LayerMask.GetMask("LayerMask");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (highlight != null){
            highlightMoveStones.ResetMaterial();
            highlight = null;
            highlightMoveStones = null;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("LayerMask"))){
            highlight = raycastHit.transform;
            highlightMoveStones = highlight.GetComponent<Move_stones>();
            if (highlight.CompareTag("Selectable") && highlight != selection){ // if it's selectable and not selected, it can be highlighted (when hovered)
                if (highlightMoveStones._meshRenderer.material != highlightMaterial){ // if Material is not highlightMaterial, set it to highlightMaterial
                    highlightMoveStones._meshRenderer.material = highlightMaterial;
                }
            }
            else {
                highlight = null;
                highlightMoveStones = null;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()){
            if (selection != null){
                selectionMoveStones.ResetMaterial(); // set Material to originalMaterial
                selection = null;
                selectionMoveStones = null;
            }
            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit, Mathf.Infinity, 1 << LayerMask.NameToLayer("LayerMask"))){
                selection = raycastHit.transform;
                selectionMoveStones = selection.GetComponent<Move_stones>();
                if (selection.CompareTag("Selectable")){
                    selectionMoveStones._meshRenderer.material = selectionMaterial; // set Material to selectionMaterial
                }
                else {
                    selection = null;
                    selectionMoveStones = null;
                }
            }
        }
    }
    
    
}
