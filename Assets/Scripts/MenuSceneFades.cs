using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneFades : MonoBehaviour
{
    public static MenuSceneFades instanace;
    public ScreenFades screenFade;


    // Start is called before the first frame update
    void Start()
    {

        if(instanace == null)
        {
            instanace = this;
        }

        else
        {
            Destroy(gameObject);
        }
        screenFade = FindObjectOfType<ScreenFades>();
        screenFade.Setup();

        screenFade.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
