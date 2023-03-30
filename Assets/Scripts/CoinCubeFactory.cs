using System.Collections;
using UnityEngine;

public class CoinCubeFactory : MonoBehaviour
{
    [SerializeField] private CoinCube _prefab;
    [SerializeField] private Resources _resources;
    [Header("Animation")]
    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _flyCurve;
    [SerializeField] private float _yModifier = 1f;
    [SerializeField] private Interval _XAndZSpread;

    public Vector3 DestinationRandomOffset
    {
        get
        {
            Vector2 position2D = Random.insideUnitCircle.normalized * _XAndZSpread.Random;
            return new Vector3(position2D.x, 0, -Mathf.Abs(position2D.y));
        }
    }

    public void Create(int coinValue)
    {
        CoinCube cube = Instantiate(_prefab, _prefab.transform.position, Quaternion.identity, transform);
        cube.Init(_resources, coinValue);

        Vector3 destination = cube.transform.position + DestinationRandomOffset;

        StartCoroutine(FlyingAnimation(cube, cube.transform.position, destination));
    }

    private IEnumerator FlyingAnimation(CoinCube cube, Vector3 from, Vector3 to)
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _duration)
        {
            var position = Vector3.Lerp(from, to, t);
            position.y += _flyCurve.Evaluate(t) * _yModifier;

            cube.transform.position = position;
            yield return null;
        }
        cube.Landed = true;
    }
}
