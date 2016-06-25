# Stage Layout Format

File header (0xA0 bytes):

	## ## ## ## - ??? (Usually 00 00 00 01)
	## ## ## ## - ??? (Usually 00 00 00 64)
	## ## ## ## - COLLISION
	## ## ## ## - OFFSET 1
	00 00 00 A0 ## ## ## ## - ALWAYS
	## ## ## ## - NO. GOALS???
	## ## ## ## - OFFSET 2
	## ## ## ## - NO. GOALS???
	00 00 00 00 - ALWAYS
	## ## ## ## - BUMPERS
	## ## ## ## - OFFSET 3
	## ## ## ## - NO. JAMABARS (SEE AD14 AND AD25)
	## ## ## ## - OFFSET
	## ## ## ## - BANANAS
	## ## ## ## - OFFSET 4
	00 00 00 00 00 00 00 00 - ALWAYS
	00 00 00 00 00 00 00 00 - ALWAYS
	## ## ## ## - NO. SOMETHING
	## ## ## ## - OFFSET 5
	## ## ## ## - LEVEL MODELS
	## ## ## ## - OFFSET 6
	00 00 00 00 00 00 00 00 - ALWAYS
	## ## ## ## - MODELS
	## ## ## ## - OFFSET 7
	## ## ## ## - NO. SOMETHING
	## ## ## ## - OFFSET
	## ## ## ## ## ## ## ## - ???
	## ## ## ## - REFLECTION FLAG?
	## ## ## ## - OFFSET 8
	00 00 00 00 00 00 00 00 - ALWAYS
	00 00 00 00 00 00 00 00 - ALWAYS
	00 00 00 00 00 00 00 00 - ALWAYS

Goal format:

	XX XX XX XX - X POSITION (FLOAT)
	YY YY YY YY - Y POSITION (FLOAT)
	ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
	XX XX - X ROTATION (INT, FULL RANGE IS 360 DEGREES)
	YY YY - Y ROTATION (INT, FULL RANGE IS 360 DEGREES)
	ZZ ZZ - Z ROTATION (INT, FULL RANGE IS 360 DEGREES)
	CC CC - GOAL COLOR (0042 IS BLUE, 0047 IS GREEN, 0052 IS RED)

Jamabar format:

	XX XX XX XX - X POSITION (FLOAT)
	YY YY YY YY - Y POSITION (FLOAT)
	ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
	XX XX - X ROTATION (INT, FULL RANGE IS 360 DEGREES)
	YY YY - Y ROTATION (INT, FULL RANGE IS 360 DEGREES)
	ZZ ZZ - Z ROTATION (INT, FULL RANGE IS 360 DEGREES)
	00 00 - ALWAYS 0
	XX XX XX XX - X SCALE (FLOAT)
	YY YY YY YY - Y SCALE (FLOAT)
	ZZ ZZ ZZ ZZ - Z SCALE (FLOAT)

Bumper format:

	XX XX XX XX - X POSITION (FLOAT)
	YY YY YY YY - Y POSITION (FLOAT)
	ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
	XX XX - X ROTATION (INT, FULL RANGE IS 360 DEGREES)
	YY YY - Y ROTATION (INT, FULL RANGE IS 360 DEGREES)
	ZZ ZZ - Z ROTATION (INT, FULL RANGE IS 360 DEGREES)
	00 00 - ALWAYS 0
	XX XX XX XX - X SCALE (FLOAT)
	YY YY YY YY - Y SCALE (FLOAT)
	ZZ ZZ ZZ ZZ - Z SCALE (FLOAT)

Banana format:

	XX XX XX XX - X POSITION (FLOAT)
	YY YY YY YY - Y POSITION (FLOAT)
	ZZ ZZ ZZ ZZ - Z POSITION (FLOAT)
	TT TT TT TT - TYPE OF BANANA (00000000 SINGLE, 00000001 BUNCH)

Model format:

	Unknown. Seems to be some kind of tree/hierarchy.

Collision header:

	0x18 zero bytes
	## ## ## ## - Size of this header minus 0x0C? (Usually 000000B8)
	## ## ## ## - Start of collision triangle data
	## ## ## ## - Start of pointers to triangle indices (4 bytes each, 256 of these) (Triangle indices are 2 bytes, lists terminated by FFFF)
	## ## ## ## - Some float
	## ## ## ## - Some float
	## ## ## ## - Some float
	## ## ## ## - Some float
	0x90 near copy of file header, starts with 00 00 00 10 00 00 00 10, then continues at 0x18 from file header. Sometimes longer?

Collision triangle format:

	(ROTATION IS Z THEN X THEN Y)
	04 X1
	04 Y1
	04 Z1
	04 Normal X
	04 Normal Y
	04 Normal Z
	02 X Angle
	02 Y Angle
	02 Z Angle
	02 Zero
	04 DX2X1
	04 DY2Y1
	04 DX3X1
	04 DY3Y1
	04 ?
	04 ?
	04 ?
	04 ?
