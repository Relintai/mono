using System;
using System.Runtime.CompilerServices;

namespace Godot
{
    public sealed partial class StringName : IDisposable, IEquatable<StringName>
    {
        private bool _disposed = false;

        private IntPtr ptr;

        internal static IntPtr GetPtr(StringName instance)
        {
            if (instance == null)
                throw new NullReferenceException($"The instance of type {nameof(StringName)} is null.");

            if (instance._disposed)
                throw new ObjectDisposedException(instance.GetType().FullName);

            return instance.ptr;
        }

        ~StringName()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes of this <see cref="StringName"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (ptr != IntPtr.Zero)
            {
                godot_icall_StringName_Dtor(ptr);
                ptr = IntPtr.Zero;
            }

            _disposed = true;
        }

        internal StringName(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// The pointer to the native instance of this <see cref="StringName"/>.
        /// </summary>
        public IntPtr NativeInstance
        {
            get { return ptr; }
        }

        public StringName() {
            ptr = godot_icall_StringName_Ctor();
        }

        public StringName(string path)
        {
            ptr = godot_icall_StringName_String_Ctor(path);
        }

        public static implicit operator StringName(string from)
        {
            return new StringName(from);
        }

        public static implicit operator string(StringName from)
        {
            return godot_icall_StringName_operator_String(StringName.GetPtr(from));
        }

        /// <summary>
        /// Converts this <see cref="StringName"/> to a string.
        /// </summary>
        /// <returns>A string representation of this <see cref="StringName"/>.</returns>
        public override string ToString()
        {
            return (string)this;
        }

        public static bool operator ==(StringName left, StringName right)
        {
            return godot_icall_StringName_operator_Equals(StringName.GetPtr(left), StringName.GetPtr(right));
        }

        public static bool operator !=(StringName left, StringName right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (obj is StringName)
            {
                return Equals((StringName)obj);
            }

            return false;
        }

        public bool Equals(StringName other)
        {
            return godot_icall_StringName_operator_Equals(StringName.GetPtr(this), StringName.GetPtr(other));
        }

        public override int GetHashCode()
        {
            return (int)ptr;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern IntPtr godot_icall_StringName_Ctor();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern IntPtr godot_icall_StringName_String_Ctor(string path);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void godot_icall_StringName_Dtor(IntPtr ptr);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern string godot_icall_StringName_operator_String(IntPtr ptr);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool godot_icall_StringName_operator_Equals(IntPtr ptr1, IntPtr ptr2);
    }
}
