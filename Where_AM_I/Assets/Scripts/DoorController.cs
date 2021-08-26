using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class DoorController : MonoBehaviour
{

    public Transform panel;
    private bool isOpen;
    public Transform player;
    
    public Text comment;

    float openSpeed = 2.0f;

    Vector3 moveDoorPos;
    private float distance;
    private Vector3 endDoorPos;

    private bool canOpen = false;
    public bool canClose = false;
    private bool isTrigger = false;

    private float textTime = 0f;

    public GameObject closeTriggerBox;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        moveDoorPos = new Vector3(0, -2f, 0f);
        comment.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDoor();
        EnableComment();
    }

    public void MoveDoor()
    {
        if (!isOpen && !isTrigger)
        {
            OpenDoor();
        }

        else if(isOpen)
        {
           CloseDoor();
        }
    }

    public void OpenDoor()
    {
        if(StarterController.hit.transform != null)
        {
            if (StarterController.hit.transform.tag == "Interactive")
            {
                if (StarterController.interactive == true)
                {
                    canOpen = true;
                    endDoorPos = transform.localPosition + moveDoorPos;
                }
            }
        }
       

        if (canOpen)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endDoorPos, Time.deltaTime * openSpeed);
            if (transform.localPosition == endDoorPos)
            {
                canOpen = false;
                isOpen = true;
            }
                

            /*if (Vector3.Distance(transform.position, endDoorPos) < 0.1f)
                tryOpen = false;*/
        }

    }

    public void CloseDoor()
    {
        if (Vector3.Distance(player.transform.position, closeTriggerBox.transform.position) < 1.0f)
        {
            canClose = true;
            if(panel !=null)
                DestroyImmediate(panel.gameObject);
        }

        if (isOpen && canClose)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endDoorPos - moveDoorPos, Time.deltaTime * openSpeed);

            if (transform.localPosition == endDoorPos - moveDoorPos)
            {
                isOpen = false;
            }
        }

       
    }

    public void EnableComment()
    {
        if(canClose)
        {
            textTime += Time.deltaTime;
            if (textTime > 1f && textTime < 3f)
                comment.enabled = true;
            if (textTime > 3f)
                comment.enabled = false;
        }
    }
}
