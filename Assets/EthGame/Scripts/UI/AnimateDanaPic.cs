using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateDanaPic : MonoBehaviour
{

    public RawImage UIFace;
    public Texture FaceReg;
    public Texture FaceCringe;
    public Texture FaceSmile;
    public Texture FaceLow;

    public void SendRegular()
    {
        UIFace.texture = FaceReg;
    }

    public void SendCringe()
    {
        UIFace.texture = FaceCringe;
    }

    public void SendSmile()
    {
        UIFace.texture = FaceSmile;
    }

    public void SendHurt()
    {
        UIFace.texture = FaceLow;
    }
}
