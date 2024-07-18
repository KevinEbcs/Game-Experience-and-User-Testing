using UnityEngine;
using TMPro;
using System.Collections;

public class HintSelection : MonoBehaviour
{
    private int interactionCount = 0;
    private const int maxInteractions = 3; 

    public GameObject selectionPanel;
    public TextMeshProUGUI responseText;

   
    public string[] hints;
    public string[] responses;

    
    public GameObject hintObject;

    [SerializeField] private float hintClearDelay = 8f;

    private bool panelActive = false; 

    void Start()
    {
        selectionPanel.SetActive(false);
        responseText.text = "";  
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !panelActive && interactionCount < maxInteractions)
        {
            Debug.Log("Player entrou na �rea de colis�o");
            OpenSelectionPanel();
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player") && panelActive)
        {
            Debug.Log("Player saiu da �rea de colis�o");
            CloseSelectionPanel();
        }
    }

    void Update()
    {
        if (panelActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SelectHint(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SelectHint(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SelectHint(2);
            if (Input.GetKeyDown(KeyCode.Alpha4)) SelectHint(3);
            if (Input.GetKeyDown(KeyCode.Alpha5)) SelectHint(4);
        }
    }

    void OpenSelectionPanel()
    {
        selectionPanel.SetActive(true);
        panelActive = true; 
        Debug.Log("Painel de sele��o aberto");
    }

    void CloseSelectionPanel()
    {
        selectionPanel.SetActive(false);
        panelActive = false; 
        Debug.Log("Painel de sele��o fechado");
    }

    public void SelectHint(int index)
    {
        if (index >= 0 && index < hints.Length && interactionCount < maxInteractions)
        {
            responseText.text = responses[index]; 
            interactionCount++; 
            ActivateHintObject();  

            
            CloseSelectionPanel();

            
           
            StartCoroutine(ClearHintAfterDelay(hintClearDelay));
        }
    }

    private void ActivateHintObject()
    {
        hintObject.SetActive(true); 
    }

    private IEnumerator ClearHintAfterDelay(float delay)
    {
       
        yield return new WaitForSeconds(delay);

        
        responseText.text = "";

        
        if (interactionCount >= maxInteractions)
        {
           
            CloseSelectionPanel();
        }
    }
}
