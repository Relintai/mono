/**************************************************************************/
/*  nodepath_glue.h                                                       */
/**************************************************************************/
/*                         This file is part of:                          */
/*                             GODOT ENGINE                               */
/*                        https://godotengine.org                         */
/**************************************************************************/
/* Copyright (c) 2014-present Godot Engine contributors (see AUTHORS.md). */
/* Copyright (c) 2007-2014 Juan Linietsky, Ariel Manzur.                  */
/*                                                                        */
/* Permission is hereby granted, free of charge, to any person obtaining  */
/* a copy of this software and associated documentation files (the        */
/* "Software"), to deal in the Software without restriction, including    */
/* without limitation the rights to use, copy, modify, merge, publish,    */
/* distribute, sublicense, and/or sell copies of the Software, and to     */
/* permit persons to whom the Software is furnished to do so, subject to  */
/* the following conditions:                                              */
/*                                                                        */
/* The above copyright notice and this permission notice shall be         */
/* included in all copies or substantial portions of the Software.        */
/*                                                                        */
/* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,        */
/* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF     */
/* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. */
/* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY   */
/* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,   */
/* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE      */
/* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                 */
/**************************************************************************/

#ifndef STRING_NAME_GLUE_H
#define STRING_NAME_GLUE_H

#ifdef MONO_GLUE_ENABLED

#include "core/string/string_name.h"

#include "../mono_gd/gd_mono_marshal.h"

StringName *godot_icall_StringName_Ctor();

StringName *godot_icall_StringName_String_Ctor(MonoString *p_path);

StringName *godot_icall_StringName_StringName_Ctor(StringName *p_path);

void godot_icall_StringName_Dtor(StringName *p_ptr);

MonoString *godot_icall_StringName_operator_String(StringName *p_np);

MonoBoolean godot_icall_StringName_operator_Equals(StringName *p_sn1, StringName *p_sn2);

// Register internal calls

void godot_register_stringname_icalls();

#endif // MONO_GLUE_ENABLED

#endif // NODEPATH_GLUE_H
