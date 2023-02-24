using UnityEngine;
using UnityEngine.UI;

public class MainSliderValueView: MonoBehaviour
{
    private MainSlider _slider;
    [SerializeField] TMPro.TMP_Text _text;
    private void Awake()
    {

        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                   .GetComponent<MainSlider>();
    }

    private void Update()
    {

        _text.text = _slider.Value.ToString("C0");
    }
   

}
