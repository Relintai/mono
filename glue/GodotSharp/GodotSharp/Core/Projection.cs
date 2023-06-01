#if REAL_T_IS_DOUBLE
using real_t = System.Double;
#else
using real_t = System.Single;
#endif
using System;
using System.Runtime.InteropServices;

namespace Godot
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Projection : IEquatable<Projection>
    {
        /// <summary>
        /// Row 0 of the basis matrix. Shows which vectors contribute
        /// to the X direction. Rows are not very useful for user code,
        /// but are more efficient for some internal calculations.
        /// </summary>
        public Vector4 Row0;

        /// <summary>
        /// Row 1 of the basis matrix. Shows which vectors contribute
        /// to the Y direction. Rows are not very useful for user code,
        /// but are more efficient for some internal calculations.
        /// </summary>
        public Vector4 Row1;

        /// <summary>
        /// Row 2 of the basis matrix. Shows which vectors contribute
        /// to the Z direction. Rows are not very useful for user code,
        /// but are more efficient for some internal calculations.
        /// </summary>
        public Vector4 Row2;


        public Vector4 Row3;

        private static readonly Projection _identity = new Projection();

        public static Projection Identity { get { return _identity; } }

        public void set_identity() {
            Row0[0] = 1;
            Row1[1] = 1;
            Row2[2] = 1;
            Row3[3] = 1;
        }

        public Projection() {
            set_identity();
        }

        public Projection(Vector4 Row0, Vector4 Row1, Vector4 Row2, Vector4 Row3) {
            this.Row0 = Row0;
            this.Row1 = Row1;
            this.Row2 = Row2;
            this.Row3 = Row3;
        }


        /// <summary>
        /// Returns <see langword="true"/> if the <see cref="Projection"/> is
        /// exactly equal to the given object (<see paramref="obj"/>).
        /// Note: Due to floating-point precision errors, consider using
        /// <see cref="IsEqualApprox"/> instead, which is more reliable.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>Whether or not the basis matrix and the object are exactly equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Projection)
            {
                return Equals((Projection)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns <see langword="true"/> if the basis matrices are exactly
        /// equal. Note: Due to floating-point precision errors, consider using
        /// <see cref="IsEqualApprox"/> instead, which is more reliable.
        /// </summary>
        /// <param name="other">The other basis.</param>
        /// <returns>Whether or not the basis matrices are exactly equal.</returns>
        public bool Equals(Projection other)
        {
            return Row0.Equals(other.Row0) && Row1.Equals(other.Row1) && Row2.Equals(other.Row2) && Row3.Equals(other.Row2);
        }

        /// <summary>
        /// Serves as the hash function for <see cref="Projection"/>.
        /// </summary>
        /// <returns>A hash code for this basis.</returns>
        public override int GetHashCode()
        {
            return Row0.GetHashCode() ^ Row1.GetHashCode() ^ Row2.GetHashCode()^ Row3.GetHashCode();
        }

        /// <summary>
        /// Converts this <see cref="Projection"/> to a string.
        /// </summary>
        /// <returns>A string representation of this basis.</returns>
        public override string ToString()
        {
            return String.Format("({0}, {1}, {2}, {3})", new object[]
            {
                Row0.ToString(),
                Row1.ToString(),
                Row2.ToString(),
                Row3.ToString()
            });
        }

        /// <summary>
        /// Converts this <see cref="Projection"/> to a string with the given <paramref name="format"/>.
        /// </summary>
        /// <returns>A string representation of this basis.</returns>
        public string ToString(string format)
        {
            return String.Format("({0}, {1}, {2}, {3})", new object[]
            {
                Row0.ToString(format),
                Row1.ToString(format),
                Row2.ToString(format),
                Row3.ToString(format)
            });
        }
    }
}
