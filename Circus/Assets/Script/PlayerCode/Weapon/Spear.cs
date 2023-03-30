using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Player;
public class Spear : MonoBehaviour, Weapon
{
    //const
    private const int DEFAULT_CURRENT_CHARGE = 0;
    //asign

    [SerializeField] protected Arrow arrow;
    [SerializeField] protected Transform bow;
    [SerializeField] protected AnimationCurve accelerateCurve;
    [SerializeField] protected GameObject aimIcon;
    //setup

    [Tooltip("Speed arrow unit per second")]
    [SerializeField] protected float speedArrow;
    [Tooltip("Speed draw unit per second")]
    [SerializeField] protected float atkSpeed;
    [SerializeField] protected float maxCharge = 3f;
    [SerializeField] protected float drawFactor = 1;
    [SerializeField] protected float power = 2;
    [SerializeField] protected float currentCharge;
    [SerializeField] protected float maxRange;
    //handler vector
    private Vector3 aimDirection;
    private Vector3 aimIconDefaultPos;
    //handler thread    
    private Coroutine ChargeCoroutine;
    private Tween aimingTween;

    //state
    [SerializeField] protected bool isAiming;
    bool isEquiped;
    [SerializeField] protected private bool isResting;
    [SerializeField] float offsetAimIcon=30;

    public float CurrentCharge { get => currentCharge; set => currentCharge = Mathf.Clamp(value, 0, maxCharge); }
    public Tween AimingTween
    {
       
        get => aimingTween; set
        {
            aimingTween.Kill();
            aimingTween = value;
        }
    }

    protected virtual void Start()
    {
      
        aimIconDefaultPos = aimIcon.transform.localPosition;
    }
    public void chuhe() {
        Debug.Log("he");
    }
    protected virtual void Update()
    {
        if(isEquiped)
        VisibleAimIcon();
   
    }

    private void VisibleAimIcon()
    {
        aimDirection = (Vector2)(Camera.main.ScreenToWorldPoint(Pointer.current.position.ReadValue()) - bow.transform.position);
        bow.transform.localRotation = Quaternion.LookRotation(bow.transform.forward, aimDirection);
        if (isAiming)
        {
            //aim icon dinamic react
            aimIcon.SetActive(true);

        }
        else
        {
            aimIcon.SetActive(false);
        }

    }
    public virtual void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Charge();
        }
        if (context.canceled)
        {
            PerformAttack();
        }
    }
    protected virtual void Shoot(GameObject arrow, float factorDraw, Vector3 direction)
    {
        GameObject obj = Instantiate(arrow, bow.position, bow.transform.localRotation);

        obj.GetComponent<Arrow>().OnHit.AddListener(() =>
        {
            Debug.Log("Chuhe");
        });
        DOTween.To(() => obj.GetComponent<Rigidbody2D>().velocity, x => obj.GetComponent<Rigidbody2D>().velocity = x,(Vector2) bow.up * factorDraw*speedArrow,0.1f).SetEase(accelerateCurve);

    }
    private IEnumerator Cooldown()
    {
        isResting = true;
        yield return new WaitForSeconds(1 / atkSpeed);
        isResting = false;
    }
    protected virtual void PerformAttack()
    {
        //stop charge
        if (ChargeCoroutine != null)
        {

            StopCoroutine(ChargeCoroutine);
            AimingTween.Kill();
            aimIcon.transform.localPosition = aimIconDefaultPos;
        }

        //stop aim
        isAiming = false;
        //perform atk

        if (CurrentCharge > maxCharge / 2)
        {
            Debug.Log("charge");
            Shoot(arrow.gameObject, CurrentCharge / maxCharge*power, aimDirection);
        }
        else if (!isResting)
        {
            Debug.Log("rapid");

            Shoot(arrow.gameObject, 0.5f*power, aimDirection);
            StartCoroutine(Cooldown());

        }



        //rest after perform

        CurrentCharge = DEFAULT_CURRENT_CHARGE;

    }
    private IEnumerator AimShoot()
    {
        aimIcon.transform.localPosition = aimIconDefaultPos;
        AimingTween = aimIcon.transform.DOLocalMove(Vector3.up*2, 0.5f, false).SetEase(accelerateCurve);
        while (isAiming)
        {

            CurrentCharge += Time.deltaTime * drawFactor;

            yield return new WaitForEndOfFrame();
        }

    }

    protected virtual void Charge()
    {

        isAiming = true;
        ChargeCoroutine = StartCoroutine(AimShoot());
    }

    public GameObject getObject()
    {
        return gameObject;
    }

    public void Equip()
    {
        ResetState();
        isEquiped = true;
        getObject().layer = LayerMask.NameToLayer("Equipment");
    }
    public void UnEquip()
    {
        ResetState();
        getObject().layer = LayerMask.NameToLayer("Weapon");
    }
    protected virtual void ResetState()
    {
        aimingTween.Kill();
        isEquiped = false;
        isAiming = false;
        aimIcon.transform.localPosition = aimIconDefaultPos;
    }


}
