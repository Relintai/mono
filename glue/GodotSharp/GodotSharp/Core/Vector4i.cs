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
    /// 3-element structure that can be used to represent positions in 3D space or any other pair of numeric values.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4i : IEquatable<Vector4i>
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
        /// The vector's Z component. Also accessible by using the index position <c>[2]</c>.
        /// </summary>
        public int z;

        public int w;

        /// <summary>
        /// Constructs a new <see cref="Vector4i"/> with the given components.
        /// </summary>
        /// <param name="x">The vector's X component.</param>
        /// <param name="y">The vector's Y component.</param>
        /// <param name="z">The vector's Z component.</param>
        public Vector4i(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Constructs a new <see cref="Vector4i"/> from an existing <see cref="Vector4i"/>.
        /// </summary>
        /// <param name="v">The existing <see cref="Vector4i"/>.</param>
        public Vector4i(Vector4i v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
            w = v.w;
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
            if (obj is Vector4i)
            {
                return Equals((Vector4i)obj);
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
        public bool Equals(Vector4i other)
        {
            return x == other.x && y == other.y && z == other.z && w == other.w;
        }
        
        /// <summary>
        /// Serves as the hash function for <see cref="Vector4i"/>.
        /// </summary>
        /// <returns>A hash code for this vector.</returns>
        public override int GetHashCode()
        {
            return y.GetHashCode() ^ x.GetHashCode() ^ z.GetHashCode() ^ w.GetHashCode();
        }

        /// <summary>
        /// Converts this <see cref="Vector4i"/> to a string.
        /// </summary>
        /// <returns>A string representation of this vector.</returns>
        public override string ToString()
        {
            return $"({x}, {y}, {z}, {w})";
        }

        /// <summary>
        /// Converts this <see cref="Vector4i"/> to a string with the given <paramref name="format"/>.
        /// </summary>
        /// <returns>A string representation of this vector.</returns>
        public string ToString(string format)
        {
            return $"({x.ToString(format)}, {y.ToString(format)}, {z.ToString(format)}, {w.ToString(format)})";
        }
    }
}
