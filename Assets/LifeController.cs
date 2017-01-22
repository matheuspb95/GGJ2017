using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {
    public Slider slider;
    public Image Coracao1, Coracao2, Coracao3;
    public Sprite CoracaoFull, CoracaoHalf, CoracaoVazio;
	// Use this for initialization
	void Start () {
		
	}

    public void ChangeValue(int value)
    {
        slider.value = value;
        if (value == 6)
        {
            Coracao1.sprite = CoracaoFull;
            Coracao2.sprite = CoracaoFull;
            Coracao3.sprite = CoracaoFull;
        }
        else if (value == 5)
        {

            Coracao1.sprite = CoracaoFull;
            Coracao2.sprite = CoracaoFull;
            Coracao3.sprite = CoracaoHalf;
        }
        else if(value == 4)
        {

            Coracao1.sprite = CoracaoFull;
            Coracao2.sprite = CoracaoFull;
            Coracao3.sprite = CoracaoVazio;
        }
        else if(value == 3)
        {

            Coracao1.sprite = CoracaoFull;
            Coracao2.sprite = CoracaoHalf;
            Coracao3.sprite = CoracaoVazio;
        }
        else if (value == 2)
        {
            Coracao1.sprite = CoracaoFull;
            Coracao2.sprite = CoracaoVazio;
            Coracao3.sprite = CoracaoVazio;
        }
        else if (value == 1)
        {
            Coracao1.sprite = CoracaoHalf;
            Coracao2.sprite = CoracaoVazio;
            Coracao3.sprite = CoracaoVazio;
        }
        else
        {
            Coracao1.sprite = CoracaoVazio;
            Coracao2.sprite = CoracaoVazio;
            Coracao3.sprite = CoracaoVazio;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
