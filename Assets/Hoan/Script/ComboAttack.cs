using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    public Animator ani;
    public int combo;
    public bool canattack;
    public AudioSource audio_S;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        //audio_S = GetComponent<AudioSource>();
    }

    public void Start_Combo()
    {
        canattack = false;
        if (combo < 3)
        {
            combo++;
        }
        
    }

    public void Finish_Ani()
    {
        canattack = false;
        combo = 0;

    }
    public void Combo()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && !canattack)
        {
            canattack = true;
            ani.SetTrigger("" + combo);
            //audio_S.clip = audioClips[combo];
            //audio_S.Play();

        }

    }
    // Update is called once per frame
    void Update()
    {

        Combo();
    }
}
