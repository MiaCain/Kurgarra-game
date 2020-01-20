using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateDanaPic : MonoBehaviour
{

    public RawImage UIFace;
    public Texture FaceReg;
    public Texture FaceCringe;

    public void SendRegular()
    {
        UIFace.texture = FaceReg;
    }

    public void SendCringe()
    {
        UIFace.texture = FaceCringe;
    }
}
