using System;
using System.Collections;
using Ez;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour , IWeapon
{
    public UnityEngine.GameObject Projectile;
    private static string FireButton = "Jump";
    public Transform FirePoint;

    //Event Strings; This can optimally be moved to an external file. Great use for a static "EventStrings" static class 
    private string CanFireChangedEvent = nameof(CanFireChangedEvent);

    private bool _canFireBacking = true;
    public bool CanFire
    {
        get => _canFireBacking;
        set
        {
            _canFireBacking = value;
            //Triggers canFireChanged event in the FSM
            CustomEvent.Trigger(gameObject, CanFireChangedEvent, value); //,parameters override 1..n
        }
    }
    
    public IEnumerable Reload()
    {
        Debug.Log("(Weapon) Reload! ; Time: "+Time.time);
        CanFire = true;
        yield return null;
    }

    public IEnumerable Fire()
    {
        throw new NotImplementedException();
    }
    
    public void Update()
    {
        if (!_canFireBacking)
            return;
        if (Input.GetButtonDown(FireButton))
        {
            var projectileGO = Instantiate(Projectile, FirePoint.position, Quaternion.identity);
            //projectileGO.GetComponent<Projectile>().SetFiringWeapon(this);        //DI pattern
            ///Send Message
            projectileGO.Send<IProjectile>(_ => _.SetFiringGameObject(gameObject));  //Messaging Pattern
            CanFire = false;
        }
    }

}