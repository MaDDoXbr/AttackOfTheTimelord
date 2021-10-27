using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IProjectile : IEventSystemHandler
{
    IEnumerable SetFiringGameObject(GameObject firingGameObject);
}