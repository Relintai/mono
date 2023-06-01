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
    /// 2D axis-aligned bounding box. Rect2i consists of a position, a size, and
    /// several utility functions. It is typically used for fast overlap tests.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect2i : IEquatable<Rect2i>
    {
        private Vector2i _position;
        private Vector2i _size;

        /// <summary>
        /// Beginning corner. Typically has values lower than <see cref="End"/>.
        /// </summary>
        /// <value>Directly uses a private field.</value>
        public Vector2i Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Size from <see cref="Position"/> to <see cref="End"/>. Typically all components are positive.
        /// If the size is negative, you can use <see cref="Abs"/> to fix it.
        /// </summary>
        /// <value>Directly uses a private field.</value>
        public Vector2i Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Constructs a <see cref="Rect2i"/> from a position and size.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        public Rect2i(Vector2i position, Vector2i size)
        {
            _position = position;
            _size = size;
        }

        /// <summary>
        /// Constructs a <see cref="Rect2i"/> from a position, width, and height.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Rect2i(Vector2i position, real_t width, real_t height)
        {
            _position = position;
            _size = new Vector2i(width, height);
        }

        /// <summary>
        /// Constructs a <see cref="Rect2i"/> from x, y, and size.
        /// </summary>
        /// <param name="x">The position's X coordinate.</param>
        /// <param name="y">The position's Y coordinate.</param>
        /// <param name="size">The size.</param>
        public Rect2i(real_t x, real_t y, Vector2i size)
        {
            _position = new Vector2i(x, y);
            _size = size;
        }

        /// <summary>
        /// Constructs a <see cref="Rect2i"/> from x, y, width, and height.
        /// </summary>
        /// <param name="x">The position's X coordinate.</param>
        /// <param name="y">The position's Y coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Rect2i(real_t x, real_t y, real_t width, real_t height)
        {
            _position = new Vector2i(x, y);
            _size = new Vector2i(width, height);
        }

        /// <summary>
        /// Returns <see langword="true"/> if this rect and <paramref name="obj"/> are equal.
        /// </summary>
        /// <param name="obj">The other object to compare.</param>
        /// <returns>Whether or not the rect and the other object are exactly equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Rect2i)
            {
                return Equals((Rect2i)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns <see langword="true"/> if this rect and <paramref name="other"/> are equal.
        /// </summary>
        /// <param name="other">The other rect to compare.</param>
        /// <returns>Whether or not the rects are exactly equal.</returns>
        public bool Equals(Rect2i other)
        {
            return _position.Equals(other._position) && _size.Equals(other._size);
        }

        /// <summary>
        /// Serves as the hash function for <see cref="Rect2i"/>.
        /// </summary>
        /// <returns>A hash code for this rect.</returns>
        public override int GetHashCode()
        {
            return _position.GetHashCode() ^ _size.GetHashCode();
        }

        /// <summary>
        /// Converts this <see cref="Rect2i"/> to a string.
        /// </summary>
        /// <returns>A string representation of this rect.</returns>
        public override string ToString()
        {
            return String.Format("({0}, {1})", new object[]
            {
                _position.ToString(),
                _size.ToString()
            });
        }

        /// <summary>
        /// Converts this <see cref="Rect2i"/> to a string with the given <paramref name="format"/>.
        /// </summary>
        /// <returns>A string representation of this rect.</returns>
        public string ToString(string format)
        {
            return String.Format("({0}, {1})", new object[]
            {
                _position.ToString(format),
                _size.ToString(format)
            });
        }
    }
}
