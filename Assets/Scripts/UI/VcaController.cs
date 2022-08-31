using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VcaController : MonoBehaviour
{
    private FMOD.Studio.VCA VcaController1;
    public string VcaName;
    [SerializeField]private float vcaVolume;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        VcaController1 = FMODUnity.RuntimeManager.GetVCA("vca:/" + VcaName);
        slider = GetComponent<Slider>();
        VcaController1.getVolume(out vcaVolume);
        
    }

    public void SetVolume(float volume)
    {
        VcaController1.setVolume(volume);
        VcaController1.getVolume(out vcaVolume);
    }
}
