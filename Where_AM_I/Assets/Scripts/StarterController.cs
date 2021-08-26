using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class StarterController : MonoBehaviour
{

    public Camera cam;

    public Text text;
    public Image interactButton;

    private RaycastHit hitInfo;
    public static RaycastHit hit;
    [SerializeField] private float range;

    public static bool interactive;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextEnable();
        hit = hitInfo;
        CheckInteractive();
        
    }

    private void TextEnable()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hitInfo, range))
        {
            if (hitInfo.transform.tag == "Interactive" || hitInfo.transform.tag == "Item")
            {
                text.enabled = true;
                interactButton.color = Color.yellow;
            }
            else
            {
                text.enabled = false;
                interactButton.color = Color.white;
            }
                
            

        }
    }

    private void CheckInteractive()
    {
        if (StarterAssetsInputs.interactive == true)
            interactive = true;
        else
            interactive = false;

    }
}
