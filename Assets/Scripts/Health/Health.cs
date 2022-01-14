using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;

    public float currHealth { get; private set; }

    private void Awake()
    {
        currHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);

        if(currHealth > 0)
        {
            // player hurt
        } else
        {
            // player dead
        }
    }
}
