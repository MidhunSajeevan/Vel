using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    Collider2D _collider;
    public List<Collider2D> _colliders = new List<Collider2D>();
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _colliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _colliders.Remove(collision);
    }
}
