using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GraplingBow : Spear
{
    [SerializeField] protected float combackTime;
    private Tween GraplingArrowTween;
    Rigidbody2D rigArrow;
    protected override void Start()
    {
        base.Start();
        rigArrow = arrow.GetComponent<Rigidbody2D>();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Shoot(GameObject arrow, float factorDraw, Vector3 direction)
    {
        arrow.transform.position = gameObject.transform.position;
        arrow.transform.rotation = bow.transform.localRotation;


        GraplingArrowTween = DOTween.To(() => arrow.GetComponent<Rigidbody2D>().velocity, x => arrow.GetComponent<Rigidbody2D>().velocity = x, (Vector2)bow.up * factorDraw * speedArrow, 0.1f).SetEase(accelerateCurve)
             .OnComplete(() => Invoke("CombackGraphling", combackTime));

    }

    protected override void ResetState()
    {
        base.ResetState();
        StopGrapling();
    }

    private void StopGrapling()
    {
        GraplingArrowTween.Kill();
        rigArrow.velocity = Vector2.zero;
    }

    private void CombackGraphling()
    {
        StopGrapling();
        arrow.transform.DOMove(gameObject.transform.position, 0.2f, false);
    }
}
