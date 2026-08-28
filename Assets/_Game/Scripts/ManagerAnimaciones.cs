using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAnimaciones : MonoBehaviour
{
    public List<Animator> anims1 = new List<Animator>();
    public List<Animator> anims2 = new List<Animator>();
    public List<Animator> anims3 = new List<Animator>();
    public List<Animator> anims4 = new List<Animator>();

    public void IniciarAnimaciones(List<Animator>animScene)
    {
        foreach(Animator anim in animScene)
        {
            if (anim == null) continue;
            anim.enabled = true;
        }
    }

    public void EjecutarAnims1() => IniciarAnimaciones(anims1);
    public void EjecutarAnims2() => IniciarAnimaciones(anims2);
    public void EjecutarAnims3() => IniciarAnimaciones(anims3);
    public void EjecutarAnims4() => IniciarAnimaciones(anims4);
}
