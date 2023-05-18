using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class change : MonoBehaviour
{
    public TMP_FontAsset [] myFonts;
    

    public TMP_Text m_TextComponent;

    private int counter = 0;
 
    public void changeFont()
    { 
        counter+=1;

        m_TextComponent.font = myFonts[counter];


        if (counter  == 24){ counter = 0;}

    }
    
}
 

