# GMA Format

Header:

	04 Number of models
	04 Model data base offset
	---
	For each model: 08*No. of models:
	04 Model offset from base
	04 Name offset from start of names/end of header

Names:

	Ascii names of models (null terminated)

Models:

	04 ASCII "GCMF"
	04 Unknown uint
	04 Unknown float
	04 Unknown float
	04 Unknown float
	04 Unknown float
	02 Number of textures
	02 No. txus in Section 1
	02 No. txus in Section 2
	01 No. header blobs? (Unknown, ignore)
	01 Check ubyte 0
	04 End of header offset? (Unknown, ignore)
	04 Check uint 0
	04 Unknown int
	04 Check int -1
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0

For number of TXUs:

	04 Unknown uint (Last byte is clamping: 80 CLAMP BOTH, 84 CLAMP T, 90 CLAMP S, 94 NO CLAMP)
	02 TPL texture number
	02 Unknown uint
	04 Check uint 0
	02 Unknown uint
	02 Texture index
	04 Unknown uint
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0

Sections:

	04 Unknown uint
	04 Unknown uint
	04 Unknown uint
	04 Unknown uint
	04 Unknown uint
	02 Unknown int
	02 Unknown int
	02 Unknown int
	02 Unknown int
	04 Vertex Flags (00000001 UNKNOWN BYTE 00000200 COORDINATES 00000400 NORMALS 00000800 RGBA FORMAT VERTEX SHADERS 00002000 TEXCOORDS 00004000 UNKNOWN 8 BYTES 00008000 UNKNOWN 8 BYTES 02000000 UNKNOWN 24 OR 36? BYTES)
	04 Check int -1
	04 Check int -1
	04 Chunk 1 size
	04 Chunk 2 size
	04 Unknown float
	04 Unknown float
	04 Unknown float
	04 Unknown float
	04 Unknown uint
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0
	04 Check uint 0

Chunk:

	00 FILLER (ONLY IN FIRST STRIP)

	98/99 ## ##
	98: FLOAT/SINGLE
	99: INT/16BIT

	SET OF ? VERTICES(x4):
	04 Pos X
	04 Pos Y
	04 Pos Z
	04 Normal I
	04 Normal J
	04 Normal K
	04 Color RGBA
	04 Texture S
	04 Texture T
