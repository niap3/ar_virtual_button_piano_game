using UnityEngine;
using Vuforia;

public class ButtonScript : MonoBehaviour
{
    public VirtualButtonBehaviour Vb;
    // public VirtualButtonBehaviour Vb2;
    // public VirtualButtonBehaviour Vb3;
    // public VirtualButtonBehaviour Vb4;
    public AudioClip buttonPressSound;
    // public AudioClip buttonPressSound2;
    // public AudioClip buttonPressSound3;
    // public AudioClip buttonPressSound4;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Vb.RegisterOnButtonPressed(OnButtonPressed1);

        /*/ Vb2.RegisterOnButtonPressed(OnButtonPressed2);
        // Vb3.RegisterOnButtonPressed(OnButtonPressed3);
        // Vb4.RegisterOnButtonPressed(OnButtonPressed4);

        // Get or add AudioSource component
        // audioSource = GetComponentInChildren<AudioSource>();

        // if (audioSource == null)
        // {
        //     audioSource = gameObject.AddComponent<AudioSource>();
        /*/
    }

    void PlaySound(AudioClip buttonPressSound) 
    {
        audioSource.clip = buttonPressSound;
        audioSource.Play();
    }

    public void OnButtonPressed1(VirtualButtonBehaviour vb)
    {
        PlaySound(buttonPressSound);
    }

    // public void OnButtonPressed2(VirtualButtonBehaviour vb)
    // {
    //     playSound(buttonPressSound2);
    //     Debug.Log("2");
    // }

    // public void OnButtonPressed3(VirtualButtonBehaviour vb)
    // {
    //     playSound(buttonPressSound3);
    //     Debug.Log("3");
    // }
    // public void OnButtonPressed4(VirtualButtonBehaviour vb)
    // {
    //     playSound(buttonPressSound4);
    //     Debug.Log("4");
    // }
}