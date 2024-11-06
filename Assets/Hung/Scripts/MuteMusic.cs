using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{

    private static MuteMusic muteMusic;

    private void Awake()
    {
        if (muteMusic == null)
        {
            muteMusic = this;
            DontDestroyOnLoad(muteMusic);
        }
        else
        {
            Destroy(muteMusic);
        }
    }
}
