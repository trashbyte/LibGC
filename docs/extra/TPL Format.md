# TPL Format

Header:

	04 Number of Textures
	---
	10 x number of textures:
	04 Texture encoding ( see wiki.tockdom.com/wiki/TPL_(File_Format) )
	04 Offset of data
	02 Width
	02 Height
	02 Unknown (Type of texture? Just set to 0 or ignore)
	02 Always 0x1234?
	---
	~TEXTURE DATA~
