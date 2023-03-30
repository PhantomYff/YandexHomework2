using System;
using UnityEngine;

[Serializable]
public struct Interval : IEquatable<Interval>
{
    public Interval(float minimum, float maximum)
    {
        Min = minimum;
        Max = maximum;

        if (Max <= Min)
        {
            throw new ArgumentOutOfRangeException($"{nameof(Max)} cannot be less than or equal to {nameof(Min)}");
        }
    }

    public Interval((float, float) bounds)
    {
        this = new Interval(bounds.Item1, bounds.Item2);
    }

    [field: SerializeField] public float Min { get; private set; }
    [field: SerializeField] public float Max { get; private set; }

    public float Random => UnityEngine.Random.Range(Min, Max);

    public float Length => Max - Min;

    public float Middle => Min + Length / 2;

    public bool IsInteger => Min == (int)Min && Max == (int)Max;

    public bool Includes(float value)
    {
        return Min <= value && value <= Max;
    }

    public bool Includes(Interval other)
    {
        return this.Min <= other.Min && other.Max <= this.Max;
    }

    public bool Intersects(Interval other)
    {
        return this.Min <= other.Max || this.Max >= other.Min;
    }

    public Interval Clamped(float min, float max)
    {
        min = min < Min ? min : Min;
        max = max > Max ? max : Max;

        return new Interval(min, max);
    }

    public bool Equals(Interval other)
    {
        return this.Min == other.Min && other.Max == this.Max;
    }

    public override bool Equals(object obj)
    {
        return obj is Interval interval && this.Equals(interval);
    }

    public override int GetHashCode()
    {
        return Min.GetHashCode() * Max.GetHashCode();
    }

    public static bool operator ==(Interval obj, Interval other) => obj.Equals(other);

    public static bool operator !=(Interval obj, Interval other) => (obj == other) == false;
}