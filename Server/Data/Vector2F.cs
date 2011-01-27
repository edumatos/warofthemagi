using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WotMServer.Data
{
    [Serializable]
    public struct Vector2F
    {
        public static Vector2F Empty() { return new Vector2F(); }
        public static Vector2F Invalid() { return new Vector2F(-1, -1); }

        public float X { get; set; }

        public float Y { get; set; }

        public Vector2F(float x, float y) : this()
        {
            X = x; Y = y;
        }

        public static Vector2F operator -(Vector2F left, Vector2F right)
        {
            return new Vector2F(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2F operator +(Vector2F left, Vector2F right)
        {
            return new Vector2F(left.X + right.X, left.Y + left.Y);
        }

        public static Vector2F operator *(Vector2F left, float right)
        {
            return new Vector2F(left.X * right, left.Y * right);
        }

        public static Vector2F operator *(float left, Vector2F right)
        {
            return right * left;
        }

        public static Vector2F operator /(Vector2F left, float right)
        {
            return left * (1 / right);
        }

        public static Vector2F operator /(float left, Vector2F right)
        {
            return new Vector2F(left / right.X, left / right.Y);
        }

        public static bool operator ==(Vector2F left, Vector2F right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Vector2F left, Vector2F right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2F)
                return this == (Vector2F)obj;
            else
                return false;
        }

        public override string ToString()
        {
            return "(" + X.ToString() + ", " + Y.ToString() + ")";
        }

        public float Magnitude()
        {
            return Convert.ToSingle(Math.Sqrt(MagnitudeSquared()));
        }

        public float MagnitudeSquared()
        {
            return Dot(this);
        }

        public void Normalize()
        {
            this = this / Magnitude();
        }

        public float Dot(Vector2F other)
        {
            return X * other.X + Y * other.Y;
        }

        public bool isValid()
        {
            return X >= 0 && X < Area.Width && Y >= 0 && Y < Area.Height;
        }
    }
}
