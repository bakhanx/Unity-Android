using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public DoorController doorCon;
    public float timeCount;

    public GameObject obj;
    public Image img;

    public Text timeText;

    public bool isOpacity = false;

    public StarterAssets.StarterAssetsInputs sInput;
    public Transform player;

    private float xRot;
    private float yRot;
    [SerializeField]
    private float zRot;

    // Start is called before the first frame update
    void Start()
    {
        timeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCount();
        TryFadeOut();
    }

    private void StartCount()
    {
        if (doorCon.canClose)
        {
            timeCount -= Time.deltaTime;
            if(timeText !=null)
            {
                timeText.text = $"{timeCount:N2}";
                timeText.enabled = true;
            }
               
        }
    }

 

    private void TryFadeOut()
    {
        if (timeCount < 0)
        {


            obj.SetActive(true);
            if (timeText != null)
            {
                xRot = player.rotation.x;
                yRot = player.rotation.y;

                DestroyImmediate(timeText);
            }
                

            sInput.enabled = false;

            StartCoroutine("StartFadeOut");

            if (isOpacity)
                SceneManager.LoadScene("Forest");
        }
    }

    public void FallDown()
    {
        if(zRot < 90)
        {
            zRot += 1f;
            player.rotation = Quaternion.Euler(xRot, yRot, zRot);
        }
    }



    IEnumerator StartFadeOut()
    {
        FallDown();
       

        Color color = img.color;

        for(int i = 0; i<=100; i++)
        {
            color.a += Time.deltaTime * 0.005f;
            img.color = color;

            if (img.color.a >= 255)
                isOpacity = true;
        }
        yield return null;

    }
    
}
