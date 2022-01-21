# INbtToken

~~~cs
namespace Helium.Nbt;

[RequiresPreviewFeatures]
public interface INbtToken
~~~

`INbtToken` serves as base interface for all NBT tokens. It forces the specific token implementation to expose common data required for all tokens.

# Properties

~~~cs
public abstract static Byte Declarator { get; }
~~~

Declares the NBT binary type declarator; the byte in the NBT stream that indicates the token datatype.

---

~~~cs
public abstract static Byte Length { get; }
~~~

Declares the binary length of the value of this token. 0 indicates a variable- or zero-length token.

---

~~~cs
public Byte[] Name { get; }
~~~

Declares the name of this token. May be ommitted for the root `NbtCompoundToken` or tokens inside a `NbtListToken`.

---

~~~cs
public INbtToken? Parent { get; set; }
~~~

Unused, planned to be used in the future. Denotes the parent token of this `INbtToken`. May be `null` at any time.

## Methods

~~~cs
public abstract static void WriteNameless(Stream stream, INbtToken token);
~~~

Defines a way to write a nameless instance of this token to a stream. This is not implemented in `NbtCompoundToken`, `NbtListToken` and `NbtEndToken`

## See also

- [`NbtCompoundToken`](./nbtcompoundtoken.md)