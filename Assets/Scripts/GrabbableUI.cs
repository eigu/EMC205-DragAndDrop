using UnityEngine;
using TMPro;

public class GrabbableUI : MonoBehaviour
{
    private InputManager inputManager;

    public float maxDistance = 3f;
    public LayerMask grabbableLayer;

    private TextMeshProUGUI grabbableText;

    private void Start()
    {
        inputManager = InputManager.Instance;
        grabbableText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateGrabbableText();
    }

    private void UpdateGrabbableText()
    {
        Ray ray = inputManager.GetCrosshairPoint();
        RaycastHit hit;

        bool isGrabbable = Physics.Raycast(ray, out hit, maxDistance, grabbableLayer);

        if (isGrabbable)
        {
            if (!inputManager.CheckIfPlayerIsGrabbing()) grabbableText.text = "Grabbable!";
        }
        else
        {
            grabbableText.text = "";
        }  
    }
}
