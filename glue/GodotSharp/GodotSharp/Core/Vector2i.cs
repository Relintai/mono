#if REAL_T_IS_DOUBLE
using real_t = System.Double;
#else
using real_t = System.Single;
#endif
using System;
using System.Runtime.InteropServices;

namespace Godot
{
    /// <summary>
    /// 2-element structure that can be used to represent positions in 2D space or any other pair of numeric values.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2i : IEquatable<Vector2i>
    {
        /// <summary>
        /// The vector's X component. Also accessible by using the index position <c>[0]</c>.
        /// </summary>
        public int x;

        /// <summary>
        /// The vector's Y component. Also accessible by using the index position <c>[1]</c>.
        /// </summary>
        public int y;


        /// <summary>
        /// Constructs a new <see cref="Vector2i"/> with the given components.
        /// </summary>
        /// <param name="x">The vector's X component.</param>
        /// <param name="y">The vector's Y component.</param>
        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Constructs a new <see cref="Vector2i"/> from an existing <see cref="Vector2i"/>.
        /// </summary>
        /// <param name="v">The existing <see cref="Vector2i"/>.</param>
        public Vector2i(Vector2i v)
        {
            x = v.x;
            y = v.y;
        }

        /// <summary>
        /// Returns <see langword="true"/> if the vector is exactly equal
        /// to the given object (<see paramref="obj"/>).
        /// Note: Due to floating-point precision errors, consider using
        /// <see cref="IsEqualApprox"/> instead, which is more reliable.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>Whether or not the vector and the object are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2i)
            {
                return Equals((Vector2i)obj);
            }
            return false;
        }

        /// <summary>
        /// Returns <see langword="true"/> if the vectors are exactly equal.
        /// Note: Due to floating-point precision errors, consider using
        /// <see cref="IsEqualApprox"/> instead, which is more reliable.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>Whether or not the vectors are exactly equal.</returns>
        public bool Equals(Vector2i other)
        {
            return x == other.x && y == other.y;
        }

        /// <summary>
        /// Serves as the hash function for <see cref="Vector2i"/>.
        /// </summary>
        /// <returns>A hash code for this vector.</returns>
        public override int GetHashCode()
        {
            return y.GetHashCode() ^ x.GetHashCode();
        }

        /// <summary>
        /// Converts this <see cref="Vector2i"/> to a string.
        /// </summary>
        /// <returns>A string representation of this vector.</returns>
        public override string ToString()
        {
            return $"({x}, {y})";
        }

        /// <summary>
        /// Converts this <see cref="Vector2i"/> to a string with the given <paramref name="format"/>.
        /// </summary>
        /// <returns>A string representation of this vector.</returns>
        public string ToString(string format)
        {
            return $"({x.ToString(format)}, {y.ToString(format)})";
        }
    }
}
