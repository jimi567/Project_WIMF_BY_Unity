/*
 * 
 * 
 *  유니티 손전등 스크립트
 *  F키로 점멸가능
 *  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Light flash_light;

    [SerializeField]
    AudioSource turnOn;
    [SerializeField]
    AudioSource turnOff;

    Transform tr;
    KeyCode[] KeyCode_List; //키코드값 케싱

    //
    [SerializeField]
    private Camera getCamera;

    void Awake()
    {
        flash_light = GetComponent<Light>();
        tr = this.transform;

        Key_Depoly();
    }

    void Key_Depoly()
    {
        //키 배열
        KeyCode_List = new KeyCode[10];

        //코드값 케싱하기
        KeyCode_List[0] = KeyCode.F;
        KeyCode_List[1] = KeyCode.Escape;
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode result = User_Input();
        //tr.rotation = getCamera.transform.rotation;
        //tr.position = getCamera.transform.position;


        if (result == KeyCode_List[0])
        {
            if (flash_light.enabled)
            {
                flash_light.enabled = false;
                turnOff.Play();
            }
            else
            {
                flash_light.enabled = true;
                turnOn.Play();
            }
        }
    }

    //무엇이 눌렸는가
    KeyCode User_Input()
    {
        KeyCode result = KeyCode_List[1];

        for (int i = 0; i < KeyCode_List.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode_List[i]))
            {
                result = KeyCode_List[i];
            }
        }

        return result;

    }
}
