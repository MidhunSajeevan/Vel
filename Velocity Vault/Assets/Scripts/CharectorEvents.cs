using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharectorEvents
{
    public static UnityAction<GameObject, int> charectorDamaged;
    public static UnityAction<GameObject, int> charectorHealed;
    public static UnityAction playerDead;
}
