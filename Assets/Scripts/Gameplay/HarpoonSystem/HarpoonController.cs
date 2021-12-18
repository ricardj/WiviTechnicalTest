using DG.Tweening;
using UnityEngine;

[ExecuteAlways]
public class HarpoonController : MonoBehaviour
{
    public Transform headTransform;
    public Transform groundPlaceholder;
    public Transform maxHeightPlaceholder;

    [Header("Harpoon settings")]
    public float harpoonSpeed = 2;

    public void Activate()
    {

        headTransform.DOMoveY(maxHeightPlaceholder.position.y, harpoonSpeed).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
    public void Deactivate()
    {
        headTransform.DOKill(false);
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            CombatManager.KillDamageable(damageable);
            Deactivate();

        }
    }

    public void OnDrawGizmos()
    {
        if (maxHeightPlaceholder != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(maxHeightPlaceholder.transform.position, 0.5f);
        }
        if (groundPlaceholder != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(groundPlaceholder.transform.position, 0.5f);
        }
    }

    internal void Reset()
    {
        headTransform.transform.DOKill(false);
        headTransform.transform.position = groundPlaceholder.transform.position;
    }
}