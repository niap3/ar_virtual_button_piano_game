using System.Collections;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public VirtualButtonBehaviour Vb1;
    public VirtualButtonBehaviour Vb2;
    public VirtualButtonBehaviour Vb3;
    public VirtualButtonBehaviour Vb4;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public Text score;
    public int scoreValue = 0;

    public int c = 0, d = 0, e = 0, f = 0;

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    private bool isCubeActive1 = false;
    private bool isCubeActive2 = false;
    private bool isCubeActive3 = false;
    private bool isCubeActive4 = false;

    void Start()
    {
        Vb1.RegisterOnButtonPressed(OnButtonPressed1);
        Vb1.RegisterOnButtonReleased(OnButtonReleased1);

        Vb2.RegisterOnButtonPressed(OnButtonPressed2);
        Vb2.RegisterOnButtonReleased(OnButtonReleased2);
        
        Vb3.RegisterOnButtonPressed(OnButtonPressed3);
        Vb3.RegisterOnButtonReleased(OnButtonReleased3);

        Vb4.RegisterOnButtonPressed(OnButtonPressed4);
        Vb4.RegisterOnButtonReleased(OnButtonReleased4);

        button1.onClick.AddListener(() => OnButtonClick(1));
        button2.onClick.AddListener(() => OnButtonClick(2));
        button3.onClick.AddListener(() => OnButtonClick(3));
        button4.onClick.AddListener(() => OnButtonClick(4));

        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
    }

    public void OnButtonPressed1(VirtualButtonBehaviour vb)
    {
        c = 1;
        d = 0; e = 0; f = 0;

        if (!isCubeActive1)
        {
            cube1.SetActive(true);
            isCubeActive1 = true;
        }
    }

    public void OnButtonReleased1(VirtualButtonBehaviour vb)
    {
        cube1.SetActive(false);
        isCubeActive1 = false;
    }
    
    public void OnButtonPressed2(VirtualButtonBehaviour vb)
    {
        d = 1;
        c = 0; e = 0; f = 0;

        if (!isCubeActive2)
        {
            cube2.SetActive(true);
            isCubeActive2 = true;
        }
    }

    public void OnButtonReleased2(VirtualButtonBehaviour vb)
    {
        cube2.SetActive(false);
        isCubeActive2 = false;
    }
    
    public void OnButtonPressed3(VirtualButtonBehaviour vb)
    {
        e = 1;
        c = 0; d = 0; f = 0;

        if (!isCubeActive3)
        {
            cube3.SetActive(true);
            isCubeActive3 = true;
        }
    }

    public void OnButtonReleased3(VirtualButtonBehaviour vb)
    {
        cube3.SetActive(false);
        isCubeActive3 = false;
    }
    
    public void OnButtonPressed4(VirtualButtonBehaviour vb)
    {
        f = 1;
        c = 0; d = 0; e = 0;

        if (!isCubeActive4)
        {
            cube4.SetActive(true);
            isCubeActive4 = true;
        }
    }

    public void OnButtonReleased4(VirtualButtonBehaviour vb)
    {
        cube4.SetActive(false);
        isCubeActive4 = false;
    }    

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is on a UI element
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check which button was touched and invoke its click event
                    if (hit.collider.gameObject == button1.gameObject)
                        button1.onClick.Invoke();
                    else if (hit.collider.gameObject == button2.gameObject)
                        button2.onClick.Invoke();
                    else if (hit.collider.gameObject == button3.gameObject)
                        button3.onClick.Invoke();
                    else if (hit.collider.gameObject == button4.gameObject)
                        button4.onClick.Invoke();
                }
            }
        }

    }

    void OnButtonClick(int buttonNumber)
    {
        if (buttonNumber == 1 && c == 1)
        {
            Debug.Log("correct! (c)");
            button1.image.color = Color.green;
            ScoreAdder();
            StartCoroutine(DelayedFunction(button1));
        }
        else if (buttonNumber == 2 && d == 1)
        {
            Debug.Log("correct! (d)");
            button2.image.color = Color.green;
            ScoreAdder();
            StartCoroutine(DelayedFunction(button2));
        }
        else if (buttonNumber == 3 && e == 1)
        {
            Debug.Log("correct! (e)");
            button3.image.color = Color.green;
            ScoreAdder();
            StartCoroutine(DelayedFunction(button3));
        }
        else if (buttonNumber == 4 && f == 1)
        {
            Debug.Log("correct! (f)");
            button4.image.color = Color.green;
            ScoreAdder();
            StartCoroutine(DelayedFunction(button4));
        }


        else if (buttonNumber == 1 && c != 1)
        {
            button1.image.color = Color.red;
            ScoreSub();
            StartCoroutine(DelayedFunction(button1));
        }
        else if (buttonNumber == 2 && d != 1)
        {
            button2.image.color = Color.red;
            ScoreSub();
            StartCoroutine(DelayedFunction(button2));
        }
        else if (buttonNumber == 3 && e != 1)
        {
            button3.image.color = Color.red;
            ScoreSub();
            StartCoroutine(DelayedFunction(button3));
        }
        else if (buttonNumber == 4 && f != 1)
        {
            button4.image.color = Color.red;
            ScoreSub();
            StartCoroutine(DelayedFunction(button4));
        }
    }

    void ScoreAdder()
    {
        if (scoreValue < 4)
        {
            scoreValue ++;
            score.text = scoreValue +"/4";
        }
    }
    
    void ScoreSub()
    {
        if (scoreValue > 0)
        {
            scoreValue --;
            score.text = scoreValue +"/4";
        }
    }

    IEnumerator DelayedFunction(Button button) 
    {
        yield return new WaitForSeconds(4);
        c = 0; d = 0; e = 0; f = 0;
        button.image.color = Color.white;
    }
}

