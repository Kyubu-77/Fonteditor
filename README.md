#### Simple font editor for small pixel fonts with 8bit color palette

**Features**
- Save as xml
- Export as cpp file for use with the "Adafruit GFX Graphics Library" 
- Create character from installed font
- Paint a character pixelwise
- Add greeble to font (need it for my Arduino matrix screen saver)

Attention: there is no "UNDO" feature

**Structure**
One *font* can be edited at the same time. A font consists of several *sizes* and each size of several *characters*. Two sizes may have different character sets. 

**Workflow**
![Fonteditor screenshot](/Screenshot.png?raw=true "Fonteditor")

1. Create *font* and change name within "Font" group

2. Add a *size* to the *font*, size can be named and sized in the "Size" group

3. A *character* can now be added in two ways 
   A. To add an empty character 
      - Press the "Add Character button" and paint the character in the "character group"
	  - The color can be selected on the palette
   B. To add a character from a font please proceed with the following steps:
      - Mark the "Active" check box, the "Preview Char" should be visible in the edit box
	  - Adjust the Letter, Font, Size and Offset until the character fits into the red frame.
	  - Once the preview is ok, either add (or overwrite current character) with the "Preview Char" or 
	    add a character range (e.g. A-Z)
	  - disable the "preview" check box
	  - the character can also be edited after wards (during preview editing is disabled)

**Character sizing**
The size of an character can be modified independent from the size setting. There fore just modify the W and H textboxes in the 
"Character group" and press "Resize". I recommend to make copy of the character before.

**Palette**
- Foreground and Background for character editing can be changed with help of the palette.
- However, the palette is not stored nor exported (in the cpp file a default grayscale palette is added)
- "Palette up" and "Palette down" adds or decrements 1 from the character pixels half byte.

**Greeble**
- Adding greeble adds a random value between -2 and +2 to roughly 70% of the charcters pixels

**Load/Save**
[Savefile format](./Sample/A_Z.xml): 
```xml
<Font Name="new 7224">
    <Sizes>
        <Size Name="new_Size" Width="10" Height="10" PreviewFontFamilyName="Arial" PreviewFontSize="7" PreviewFontBold="False" PreviewFontItalic="False" PreviewOffsetX="-1" PreviewOffsetY="-2" PreviewChar="X" PalletteForegroundRed="0" PalletteForegroundGreen="0" PalletteForegroundBlue="0" PalletteBackgroundRed="255" PalletteBackgroundGreen="255" PalletteBackgroundBlue="255" GenBasePaletteIndex="15">
            <Characters>
                <Character Name="newX" Width="10" Height="10">
                    <Matrix>[[0,0,0,0,0,0,0,0,0,0],[0,0,15,0,0,0,0,15,15,0],[0,0,0,15,0,0,0,15,0,0],[0,0,0,0,15,0,15,0,0,0],[0,0,0,0,15,15,0,0,0,0],[0,0,0,0,0,15,0,0,0,0],[0,0,0,0,15,0,15,0,0,0],[0,0,0,15,0,0,15,0,0,0],[0,0,0,15,0,0,0,15,0,0],[0,0,15,0,0,0,0,0,15,0]]</Matrix>
                </Character>
            </Characters>
        </Size>
    </Sizes>
</Font>
```

Export to cpp
[CPP export format](./Sample/A_Z.cpp): 
```cpp
#pragma once

#include "BitmapFont.h"

const uint8_t new_Size_Palette[] = {
0x00,0x00,0x00,   // Background
0x11,0x11,0x11,
0x22,0x22,0x22,
0x33,0x33,0x33,
0x44,0x44,0x44,
0x55,0x55,0x55,
0x66,0x66,0x66,
0x77,0x77,0x77,
0x88,0x88,0x88,
0x99,0x99,0x99,
0xAA,0xAA,0xAA,
0xBB,0xBB,0xBB,
0xCC,0xCC,0xCC,
0xDD,0xDD,0xDD,
0xEE,0xEE,0xEE,
0xFF,0xFF,0xFF   // Foreground
};

const uint8_t new_Size_BitmapData[] PROGMEM = {
    // newX
    0x00,0x00,0x00,0x00,0x00,
    0x0F,0x00,0x00,0x00,0x0F,
    0x0F,0xF0,0x00,0x00,0xF0,
    0x00,0x0F,0x00,0xFF,0x00,
    0x00,0x00,0xFF,0x00,0x00,
    0x00,0x0F,0xF0,0xF0,0x00,
    0x00,0xF0,0x00,0x0F,0xF0,
    0x0F,0x00,0x00,0x00,0x0F,
    0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00
};

const uint8_t new_Size_GlyphDataLength = 1;
const Glyph new_Size_GlyphData[] PROGMEM = {
    {0, 10, 10, 12, 0, -10}
};

const BitmapFont new_Size PROGMEM = {
	new_Size_Palette,
	16,
	new_Size_BitmapData,                                 
	10,		
	new_Size_GlyphData,                                  
	1
};
```

