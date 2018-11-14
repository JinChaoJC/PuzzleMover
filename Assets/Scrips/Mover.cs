using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mover : Recever
{
    private Tween m_Tween;
    public override void Execute(ShareData data)
    {
        Debug.Log(data.msg);
        MoveTo(data.v3);
    }
    private void MoveTo(Vector3 aimPos)
    {
        if (m_Tween != null) m_Tween.Kill();
        m_Tween = this.transform.DOMove(aimPos, 0.1f);
    }
}
