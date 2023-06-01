using System;
using System.Runtime.CompilerServices;

namespace Godot
{
    public sealed partial class StringName : IDisposable
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
            ptr = godot_icall_StringName_Ctor(path);
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
            return godot_icall_StringName_operator_String(StringName.GetPtr(left), StringName.GetPtr(right));
        }

        public static bool operator !=(Rect2 left, Rect2 right)
        {
            return !left.Equals(right);
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
