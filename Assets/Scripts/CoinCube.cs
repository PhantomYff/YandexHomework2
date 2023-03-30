using UnityEngine;

public class CoinCube : MonoBehaviour
{
    public bool Landed { get; set; }

    private Resources _resources;
    private int _value;

    public void Init(Resources resources, int value)
    {
        _resources = resources;
        _value = value;
    }

    protected void OnMouseEnter()
    {
        if (Landed)
        {
            _resources.CollectCoins(_value, transform.position);
            Destroy(gameObject);
        }
    }
}
