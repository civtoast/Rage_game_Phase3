using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudio : UICore {

    public Slider vol1, vol2;

    protected override void Start()
    {
        base.Start();
        //whatever else

        vol1.onValueChanged.AddListener(OnVolumeChange);

    }

    public override void Init()
    {
        base.Init();
        //load volume settins...

        ShowPanel();
    }

    void OnVolumeChange(float value)
    {
        print(value);
    }

}
