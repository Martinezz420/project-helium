﻿namespace Helium.Data.Nbt;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;

using Helium.Data.Abstraction;

[RequiresPreviewFeatures]
public sealed record NbtInt32ArrayToken : IArrayToken<Int32>
{
	internal List<Int32> children = new();

	public Int32 this[Int32 index]
	{
		get => children[index];
		set => children[index] = value;
	}

	/// <summary>
	/// Stores the binary marker for this token type.
	/// </summary>
	public static Byte Declarator => 0x0B;

	/// <summary>
	/// Provides an instance access field for this token type.
	/// </summary>
	public Byte RefDeclarator => Declarator;

	/// <summary>
	/// Stores which token type is tolerated as child for this list.
	/// </summary>
	public Byte ListTypeDeclarator { get; init; }

	/// <summary>
	/// The name of this array token.
	/// </summary>
	public String Name { get; set; } = null!;

	/// <summary>
	/// The root token of this tree.
	/// </summary>
	public IRootToken? RootToken { get; set; }

	/// <summary>
	/// The immediate parent for this token.
	/// </summary>
	public IDataToken? ParentToken { get; set; }

	public Int32 Count => this.children.Count;

	public Boolean IsReadOnly => false;

	public void Add(Int32 item)
	{
		this.children.Add(item);
	}

	public void Clear()
	{
		this.children.Clear();
	}

	public Boolean Contains(Int32 item)
	{
		return this.children.Contains(item);
	}

	public void CopyTo(Int32[] array, Int32 arrayIndex)
	{
		this.children.CopyTo(array, arrayIndex);
	}

	public IEnumerator<Int32> GetEnumerator()
	{
		return this.children.GetEnumerator();
	}

	public Int32 IndexOf(Int32 item)
	{
		return this.children.IndexOf(item);
	}

	public void Insert(Int32 index, Int32 item)
	{
		this.children.Insert(index, item);
	}

	public Boolean Remove(Int32 item)
	{
		return this.children.Remove(item);
	}

	public void RemoveAt(Int32 index)
	{
		this.children.RemoveAt(index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.children.GetEnumerator();
	}

	internal void SetChildren(Span<Int32> children)
	{
		this.children = children.ToArray().ToList();
	}
}
