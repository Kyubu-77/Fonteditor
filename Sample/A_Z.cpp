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
    // A
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0xFF,0x0F,0xF0,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0xF0,0x00,0x0F,0xF0,0x00,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,
    0x00,0x00,0xFF,0xFF,0xF0,0x0F,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // B
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0xFF,0xFF,0xF0,0x0F,0xFF,0xFF,0xF0,0x00,
    0x00,0x0F,0xFF,0x0F,0xFF,0xFF,0x00,0x0F,0xF0,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // C
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xF0,0x00,0x00,0x0F,0x00,0x00,0x00,
    0x00,0x00,0xFF,0xF0,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x00,0xFF,0xFF,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0xFF,0xFF,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // D
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // E
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // F
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // G
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xF0,0x00,0xFF,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0xFF,0xF0,0x00,0xFF,0xFF,0xFF,0xF0,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0xFF,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,0x0F,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x00,0xFF,0xFF,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // H
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // I
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // J
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // K
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0x00,
    0x00,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x0F,0xFF,0xF0,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0xFF,0xF0,0x00,0x0F,0xFF,0x00,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0x0F,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // L
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // M
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // N
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // O
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0x00,0xFF,0xFF,0xF0,0x0F,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x00,0xFF,0xFF,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // P
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xF0,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // Q
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x0F,0xF0,
    0x00,0x00,0x0F,0xFF,0xFF,0xFF,0xFF,0xF0,0xFF,0x00,
    0x00,0x00,0xFF,0xF0,0x00,0x00,0x0F,0xFF,0xFF,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0xF0,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x0F,0xF0,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x00,0xFF,0xFF,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // R
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x0F,0xFF,0x0F,0xFF,0x00,0x0F,0xFF,0xF0,0x00,
    0x00,0xFF,0xF0,0x00,0xFF,0xF0,0xFF,0xF0,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // S
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0xFF,0xF0,0x00,0xFF,0xFF,0xFF,0x00,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0xFF,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xF0,0x00,0x0F,0xF0,0x00,0x0F,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0xFF,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x0F,0xF0,0x00,0xFF,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x0F,0xFF,0xF0,0x00,
    0x00,0x00,0xFF,0xFF,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // T
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // U
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xF0,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // V
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xF0,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // W
    0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0xF0,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0xFF,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0xFF,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // X
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0x00,0xFF,0xF0,0x00,0x00,0xFF,0xFF,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0x00,0x0F,0xFF,0x00,0x00,0x00,
    0x00,0x00,0x00,0x0F,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0xFF,0xF0,0x00,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0x00,0x0F,0xFF,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0xF0,0x00,0x00,0xFF,0xF0,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // Y
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x0F,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x0F,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0xF0,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    // Z
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0xFF,0x00,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0xFF,0xF0,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x0F,0xFF,0x00,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0xFF,0xF0,0x00,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0xFF,0xF0,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x0F,0xFF,0x00,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0xFF,0xF0,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x0F,0xFF,0x00,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x0F,0xFF,0xFF,0x00,
    0x00,0xFF,0x00,0x00,0x00,0x00,0x00,0xFF,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0F,0xFF,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
};

const uint8_t new_Size_GlyphDataLength = 26;
const Glyph new_Size_GlyphData[] PROGMEM = {
    {0, 20, 20, 22, 0, -20}, 
    {200, 20, 20, 22, 0, -20}, 
    {400, 20, 20, 22, 0, -20}, 
    {600, 20, 20, 22, 0, -20}, 
    {800, 20, 20, 22, 0, -20}, 
    {1000, 20, 20, 22, 0, -20}, 
    {1200, 20, 20, 22, 0, -20}, 
    {1400, 20, 20, 22, 0, -20}, 
    {1600, 20, 20, 22, 0, -20}, 
    {1800, 20, 20, 22, 0, -20}, 
    {2000, 20, 20, 22, 0, -20}, 
    {2200, 20, 20, 22, 0, -20}, 
    {2400, 20, 20, 22, 0, -20}, 
    {2600, 20, 20, 22, 0, -20}, 
    {2800, 20, 20, 22, 0, -20}, 
    {3000, 20, 20, 22, 0, -20}, 
    {3200, 20, 20, 22, 0, -20}, 
    {3400, 20, 20, 22, 0, -20}, 
    {3600, 20, 20, 22, 0, -20}, 
    {3800, 20, 20, 22, 0, -20}, 
    {4000, 20, 20, 22, 0, -20}, 
    {4200, 20, 20, 22, 0, -20}, 
    {4400, 20, 20, 22, 0, -20}, 
    {4600, 20, 20, 22, 0, -20}, 
    {4800, 20, 20, 22, 0, -20}, 
    {5000, 20, 20, 22, 0, -20}
};

const BitmapFont new_Size PROGMEM = {
	new_Size_Palette,
	16,
	new_Size_BitmapData,                                 
	20,		
	new_Size_GlyphData,                                  
	26
};


