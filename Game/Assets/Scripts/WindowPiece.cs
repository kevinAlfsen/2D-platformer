﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPiece : MonoBehaviour
{
    Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }
}
