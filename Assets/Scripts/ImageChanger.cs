using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Sprite[] Hairstyles;
    public int i = 0;
    SpriteRenderer SpriteRenderer;
    public CubeGestureListener GestureListener;
    public float YposChanger = 1f;
    public bool HairstleOption = false;
    public string SaveFolder;
    public bool Takescreenshot = false;
    private float _stimer;
    public GameObject[] Counterimages;
    public int countercont = 0;
    public GameObject FrameTexture;
    private AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        GestureListener = CubeGestureListener.Instance;
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // StartCoroutine(Timer());
        if (HairstleOption)
        {
            var _pos = gameObject.transform.position;
            _pos.y = _pos.y + YposChanger;
            gameObject.transform.position = _pos;
            gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
        i = Mathf.Clamp(i, 0, Hairstyles.Length-1);

        if (GestureListener.IsSwipeLeft())
        {
            Debug.Log("Swipe Left");
            i++;
            SpriteRenderer.sprite = Hairstyles[i];
        }
        if (GestureListener.IsSwipeRight())
        {
            Debug.Log("Swipe Right");
            i--;
            SpriteRenderer.sprite = Hairstyles[i];
        }
        if (GestureListener.IsSwipeUp())
        {
            Debug.Log("Swipe Up");

            StartCoroutine(TakeScreenShot());
        }
        if (Takescreenshot)
        {
            Texture2D SH = ScreenCapture.CaptureScreenshotAsTexture();            
            SH.Apply();
            byte[] btScreenShot = SH.EncodeToJPG();
            Destroy(SH);
      
            // save the screenshot as jpeg file
            string sDirName = SaveFolder + "/Screenshots";
            if (!Directory.Exists(sDirName))
                Directory.CreateDirectory(sDirName);

            string sFileName = sDirName + "/" + string.Format("{0:F0}", Time.realtimeSinceStartup * 10f) + ".jpg";
            File.WriteAllBytes(sFileName, btScreenShot);
            Audio.Play();
            Takescreenshot = false;
            FrameTexture.SetActive(false);
        }
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            Debug.Log("LeftHamd");


        }
        if (other.gameObject.CompareTag("RightHand"))
        {
            Debug.Log("RightHand");

        }
    }
    public IEnumerator Timer()
    {
        if (Takescreenshot)
        {
            for (int i = 0; i < Counterimages.Length; i++)
            {
                yield return new WaitForSeconds(1f);
                Counterimages[i].SetActive(true);
            }
        }
        if (!Takescreenshot)
        {
            for (int i = 0; i < Counterimages.Length; i++)
            {
                Counterimages[i].SetActive(false);
            }
        }
    }
    public IEnumerator TakeScreenShot()
    {
        FrameTexture.SetActive(true);
        for (int i = 0; i < Counterimages.Length; i++)
        {
            if (Counterimages[i])
            {
                Counterimages[i].SetActive(true);
            }
            yield return new WaitForSeconds(1f);
            if (Counterimages[i])
            {
                Counterimages[i].SetActive(false);
            }
        }
        Takescreenshot = true;
    }
    
}