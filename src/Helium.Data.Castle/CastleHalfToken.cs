namespace Helium.Data.Castle;

using System;
using System.Runtime.Versioning;

using Helium.Data.Abstraction;
using Helium.Data.Nbt;

[RequiresPreviewFeatures]
public record struct CastleHalfToken : ICastleToken, IValueToken<Half>
{
	public static Byte Declarator => 0x09;

	public UInt16 NameId { get; internal set; }

	public Half Value { get; set; }

	public Byte RefDeclarator => Declarator;

	public String Name
	{
		get => (this.RootToken as CastleRootToken)?.TokenNames[NameId]!;
		set
		{
			CastleRootToken root = this.RootToken as CastleRootToken ?? throw new ArgumentException(
				$"Root token of CastleHalfToken {NameId}:{Value} was not of type CastleRootToken");

			if(!root.TokenNames.Contains(value))
			{
				root.TokenNames.Add(value);
			}

			this.NameId = (UInt16)root.TokenNames.IndexOf(value);
		}
	}

	public IRootToken? RootToken { get; init; }

	public IDataToken? ParentToken { get; set; }

	public IDataToken ToNbtToken()
	{
		return new NbtSingleToken
		{
			Name = this.Name,
			Value = (Single)this.Value
		};
	}
}
